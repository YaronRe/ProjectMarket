using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Models;

namespace ProjectMarket.Controllers
{
    public class AcademicInstitutesController : Controller
    {
        private readonly ProjectMarketContext _context;

        public AcademicInstitutesController(ProjectMarketContext context)
        {
            _context = context;
        }

        // GET: AcademicInstitutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicInstitute.ToListAsync());
        }

        // GET: AcademicInstitutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicInstitute = await _context.AcademicInstitute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicInstitute == null)
            {
                return NotFound();
            }

            return View(academicInstitute);
        }

        // GET: AcademicInstitutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicInstitutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AcademicInstitute academicInstitute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicInstitute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(academicInstitute);
        }

        // GET: AcademicInstitutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicInstitute = await _context.AcademicInstitute.FindAsync(id);
            if (academicInstitute == null)
            {
                return NotFound();
            }
            return View(academicInstitute);
        }

        // POST: AcademicInstitutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AcademicInstitute academicInstitute)
        {
            if (id != academicInstitute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicInstitute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicInstituteExists(academicInstitute.Id))
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
            return View(academicInstitute);
        }

        // GET: AcademicInstitutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicInstitute = await _context.AcademicInstitute
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicInstitute == null)
            {
                return NotFound();
            }

            return View(academicInstitute);
        }

        // POST: AcademicInstitutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicInstitute = await _context.AcademicInstitute.FindAsync(id);
            _context.AcademicInstitute.Remove(academicInstitute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicInstituteExists(int id)
        {
            return _context.AcademicInstitute.Any(e => e.Id == id);
        }
    }
}
