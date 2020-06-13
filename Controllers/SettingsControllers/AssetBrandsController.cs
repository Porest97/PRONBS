using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;

namespace PRONBS.Controllers.SettingsControllers
{
    [Authorize]
    public class AssetBrandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetBrandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetBrand.ToListAsync());
        }

        // GET: AssetBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetBrand == null)
            {
                return NotFound();
            }

            return View(assetBrand);
        }

        // GET: AssetBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetBrandName")] AssetBrand assetBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetBrand);
        }

        // GET: AssetBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand.FindAsync(id);
            if (assetBrand == null)
            {
                return NotFound();
            }
            return View(assetBrand);
        }

        // POST: AssetBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetBrandName")] AssetBrand assetBrand)
        {
            if (id != assetBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetBrandExists(assetBrand.Id))
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
            return View(assetBrand);
        }

        // GET: AssetBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetBrand = await _context.AssetBrand
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetBrand == null)
            {
                return NotFound();
            }

            return View(assetBrand);
        }

        // POST: AssetBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetBrand = await _context.AssetBrand.FindAsync(id);
            _context.AssetBrand.Remove(assetBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetBrandExists(int id)
        {
            return _context.AssetBrand.Any(e => e.Id == id);
        }
    }
}
