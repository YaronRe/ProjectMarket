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
    public class FieldOfStudiesController : Controller
    {
        private readonly ProjectMarketContext _context;

        public FieldOfStudiesController(ProjectMarketContext context)
        {
            _context = context;
        }

        // GET: FieldOfStudies
        public async Task<IActionResult> Index()
        {
            return View(await _context.FieldOfStudy.ToListAsync());
        }

        // GET: FieldOfStudies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }

            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldOfStudies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FieldOfStudy fieldOfStudy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldOfStudy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudy.FindAsync(id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }
            return View(fieldOfStudy);
        }

        // POST: FieldOfStudies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FieldOfStudy fieldOfStudy)
        {
            if (id != fieldOfStudy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldOfStudy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldOfStudyExists(fieldOfStudy.Id))
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
            return View(fieldOfStudy);
        }

        // GET: FieldOfStudies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fieldOfStudy = await _context.FieldOfStudy
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fieldOfStudy == null)
            {
                return NotFound();
            }

            return View(fieldOfStudy);
        }

        // POST: FieldOfStudies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fieldOfStudy = await _context.FieldOfStudy.FindAsync(id);
            _context.FieldOfStudy.Remove(fieldOfStudy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Statistics() {
            
            return Json(new object [] { new {Product = "Shoes2",Count = 3},new {Product = "Shoes", Count= 5}, new {Product= "Shoes1",Count= 8}, new {Product= "Ssh",Count= 8}, new {Product= "Sh",Count= 8}, new {Product= "Sho",Count= 8}});
        }
        
        private bool FieldOfStudyExists(int id)
        {
            return _context.FieldOfStudy.Any(e => e.Id == id);
        }


    }
}
