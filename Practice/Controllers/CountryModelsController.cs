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
    public class CountryModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CountryModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CountryModel.ToListAsync());
        }

        // GET: CountryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.CountryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // GET: CountryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(countryModel);
        }

        // GET: CountryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.CountryModel.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }
            return View(countryModel);
        }

        // POST: CountryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name")] CountryModel countryModel)
        {
            if (id != countryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryModelExists(countryModel.Id))
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
            return View(countryModel);
        }

        // GET: CountryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryModel = await _context.CountryModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryModel == null)
            {
                return NotFound();
            }

            return View(countryModel);
        }

        // POST: CountryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryModel = await _context.CountryModel.FindAsync(id);
            if (countryModel != null)
            {
                _context.CountryModel.Remove(countryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryModelExists(int id)
        {
            return _context.CountryModel.Any(e => e.Id == id);
        }
    }
}
