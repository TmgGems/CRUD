using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Data;
using Practice.Models;

namespace Practice.Controllers
{
    public class ProvinceModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProvinceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProvinceModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProvinceModel.Include(p => p.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProvinceModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinceModel = await _context.ProvinceModel
                .Include(p => p.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinceModel == null)
            {
                return NotFound();
            }

            return View(provinceModel);
        }

        // GET: ProvinceModels/Create
        public IActionResult Create()
        {
            ViewData["Message"] = "This is the message for creating Province";
            ViewData["CountryId"] = new SelectList(_context.CountryModel, "Id", "Name");
            ViewData["provinces"] = _context.ProvinceModel.ToList();
            return View();
        }

        // POST: ProvinceModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,CountryId")] ProvinceModel provinceModel)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Province Created Successfully";
                _context.Add(provinceModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.CountryModel, "Id", "Id", provinceModel.CountryId);
            return View(provinceModel);
        }

        // GET: ProvinceModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinceModel = await _context.ProvinceModel.FindAsync(id);
            if (provinceModel == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.CountryModel, "Id", "Id", provinceModel.CountryId);
            return View(provinceModel);
        }

        // POST: ProvinceModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,CountryId")] ProvinceModel provinceModel)
        {
            if (id != provinceModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provinceModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinceModelExists(provinceModel.Id))
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
            ViewData["CountryId"] = new SelectList(_context.CountryModel, "Id", "Id", provinceModel.CountryId);
            return View(provinceModel);
        }

        // GET: ProvinceModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provinceModel = await _context.ProvinceModel
                .Include(p => p.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provinceModel == null)
            {
                return NotFound();
            }

            return View(provinceModel);
        }

        // POST: ProvinceModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provinceModel = await _context.ProvinceModel.FindAsync(id);
            if (provinceModel != null)
            {
                _context.ProvinceModel.Remove(provinceModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinceModelExists(int id)
        {
            return _context.ProvinceModel.Any(e => e.Id == id);
        }
    }
}
