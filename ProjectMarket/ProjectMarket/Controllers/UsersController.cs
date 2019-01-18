using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;
using ProjectMarket.ViewModels;

namespace ProjectMarket.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly ProjectMarketContext _context;

        public UsersController(ProjectMarketContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.Where(m => !m.IsDeleted).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id && (!m.IsDeleted || ClaimsExtension.IsAdmin(HttpContext)));
            if (user == null)
            {
                return NotFound();
            }
            IEnumerable<FieldOfStudy> fieldsOfStudy = _context.FieldOfStudy.ToList();
            ViewData["FieldsOfStudy"] = fieldsOfStudy;

            return View(user);
        }

        // GET: Users/Create
        [Authorize(Roles = ClaimsExtension.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ClaimsExtension.Admin)]
        public async Task<IActionResult> Create([Bind("Id,UserName,EMail,Password,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = ClaimsExtension.Admin)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ClaimsExtension.Admin)]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,EMail,Password,IsAdmin")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = ClaimsExtension.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = ClaimsExtension.Admin)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            user.IsDeleted = true;
            var userProjects = await _context.Project.Where(x => x.OwnerId == id && !x.IsDeleted).ToListAsync();
            userProjects.ForEach(x => x.IsDeleted = true);
            _context.Project.UpdateRange(userProjects);
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Filter(UsersFilter filter)
        {
            bool includeDeleted = filter.IncludeDeleted && ClaimsExtension.IsAdmin(HttpContext);
            var users = (
                from u in _context.User
                where u.FirstName.Contains(filter.FirstName ?? "") &&
                      u.LastName.Contains(filter.LastName ?? "") &&
                      u.UserName.Contains(filter.UserName ?? "") &&
                      (includeDeleted || !u.IsDeleted)
                select new { u.Id, u.UserName, u.FullName, u.EMail, u.IsAdmin,u.IsDeleted }
                );

            return Json(users);
        }
    }
}
