using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accord.MachineLearning.Rules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;
using ProjectMarket.ViewModels;

namespace ProjectMarket.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ProjectMarketContext _context;

        public ProjectsController(ProjectMarketContext context)
        {
            _context = context;
        }

        // GET: Projects
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<FieldOfStudy> fieldsOfStudy = _context.FieldOfStudy.ToList();
            ViewData["FieldsOfStudy"] = fieldsOfStudy;
            IEnumerable<ProjectInStoreView> projects =
                (from p in _context.Project
                 join u in _context.User on p.OwnerId equals u.Id
                 join s in _context.Sale on p.Id equals s.ProjectId
                 group new { s.Grade, s.Rank } by new { s.ProjectId, p.Description, p.Name } into proj
                 select new ProjectInStoreView()
                 {
                     Id = proj.Key.ProjectId,
                     Description = proj.Key.Description,
                     Name = proj.Key.Name,
                     AvgGrade = proj.Select(x => (double)x.Grade).Average(),
                     Rank = proj.Select(x => (double)x.Rank).Average()
                 });
            return View(projects);
        }

        public async Task<IActionResult> FieldOfStudy(int id)
        {
            return View(await _context.Project.Where(x => x.FieldOfStudyId == id).ToListAsync());
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Filter(ProjectFilter filter)
        {
            bool includeDeleted = filter.IncludeDeleted && ClaimsExtension.IsAdmin(HttpContext);

            var projectsGroup =
                (from project in _context.Project
                 join user in _context.User on project.OwnerId equals user.Id
                 join sale in _context.Sale on project.Id equals sale.ProjectId into sales
                 from subsale in sales.DefaultIfEmpty()
                 where ((includeDeleted || (!project.IsDeleted && !user.IsDeleted)) &&
                        (!filter.UserId.HasValue || project.OwnerId == filter.UserId.Value) &&
                        project.Name.Contains(filter.Name ?? "") &&
                        (!filter.MaxPrice.HasValue || project.Price <= filter.MaxPrice.Value) &&
                        (!filter.MinPrice.HasValue || project.Price >= filter.MinPrice.Value) &&
                        (!filter.FieldOfStudyId.HasValue || project.FieldOfStudyId == filter.FieldOfStudyId.Value)
                     )
                 select new
                 {
                     Id = project.Id,
                     Description = project.Description,
                     Name = project.Name,
                     Grade = subsale.Grade,
                     Rank = subsale.Rank
                 })
                .GroupBy(x => new { x.Id, x.Description, x.Name });

            List<ProjectInStoreView> projects = new List<ProjectInStoreView>();
            foreach (var group in projectsGroup)
            {
                var proj = new ProjectInStoreView()
                {
                    Id = group.Key.Id,
                    Description = group.Key.Description,
                    Name = group.Key.Name
                };
                var grades = group.Where(x => x.Grade.HasValue);
                proj.AvgGrade = grades.Any() ? new double?(grades.Select(x => (double)x.Grade.Value).Average()) : null;
                var ranks = group.Where(x => x.Rank.HasValue);
                proj.Rank = ranks.Any() ? new double?(ranks.Select(x => (double)x.Rank.Value).Average()) : null;
                projects.Add(proj);
            }
            return Json(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Machine learning is awesome!

            List<IGrouping<int, int>> projectIdsPerUsersGroups = _context.Sale.Include("Project").Where(x => !x.Project.IsDeleted).GroupBy(x => x.BuyerId,y => y.ProjectId).ToList();
            SortedSet<int>[] projectsPerUserDataset = new SortedSet<int>[projectIdsPerUsersGroups.Count];
            int idx = 0;
            foreach (var group in projectIdsPerUsersGroups)
            {
                projectsPerUserDataset[idx++] = new SortedSet<int>(group);
            }

            Apriori apriori = new Apriori(threshold: 3, confidence: 0);
            AssociationRuleMatcher<int> classifier = apriori.Learn(projectsPerUserDataset);
            AssociationRule<int>[] rules = classifier.Rules;

            ViewData["suggested"] = rules.Where(x => x.Y.First() != id).Select(x => _context.Project.First(y=>y.Id == x.Y.First()));

            var project = await _context.Project
                .Include(x => x.AcademicInstitute)
                .Include(x => x.FieldOfStudy)
                .Include(x => x.Owner)
                .FirstOrDefaultAsync(m => m.Id == id &&
                                    ((!m.Owner.IsDeleted && !m.IsDeleted) || ClaimsExtension.IsAdmin(HttpContext)));
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            IEnumerable<FieldOfStudy> fieldsOfStudy = _context.FieldOfStudy.ToList();
            IEnumerable<AcademicInstitute> academicInstitutes = _context.AcademicInstitute.ToList();
            ViewBag.FieldsOfStudy = fieldsOfStudy;
            ViewBag.AcademicInstitutes = academicInstitutes;
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,FieldOfStudyId,AcademicInstituteId,Address")] Project project)
        {
            int userId = ClaimsExtension.GetUserId(HttpContext);

            // No user id redirect to login
            if (userId < 0)
            {
                return RedirectToAction("Login", "Account");
            }

            project.OwnerId = userId;
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(x => x.AcademicInstitute).Include(x => x.FieldOfStudy)
                .SingleOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            if (project == null)
            {
                return NotFound();
            }
            IEnumerable<FieldOfStudy> fieldsOfStudy = _context.FieldOfStudy.ToList();
            IEnumerable<AcademicInstitute> academicInstitutes = _context.AcademicInstitute.ToList();
            ViewBag.FieldsOfStudy = fieldsOfStudy;
            ViewBag.AcademicInstitutes = academicInstitutes;
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,FieldOfStudyId,AcademicInstituteId")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            project.IsDeleted = true;
            _context.Project.Update(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
