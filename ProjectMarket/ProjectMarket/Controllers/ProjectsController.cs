using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;

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
            return View(await _context.Project.ToListAsync());
        }
        
        public async Task<IActionResult> MyProjects()
        {
            int userId = ClaimsExtension.GetUserId(HttpContext);

            // No user id redirect to login
            if (userId < 0)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(await _context.Project.Where(x => x.OwnerId == userId).ToListAsync());
        }
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(x => x.AcademicInstitute).Include(x => x.FieldOfStudy)
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Description,FieldOfStudyId,AcademicInstituteId")] Project project)
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
                .SingleOrDefaultAsync(x => x.Id == id);
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
