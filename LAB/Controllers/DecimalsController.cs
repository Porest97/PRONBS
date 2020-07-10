using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.LAB.Models.DataModels;

namespace PRONBS.LAB.Controllers
{
    public class DecimalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DecimalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Decimals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Decimals.ToListAsync());
        }

        // GET: Decimals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decimals = await _context.Decimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decimals == null)
            {
                return NotFound();
            }

            return View(decimals);
        }

        // GET: Decimals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Decimals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value1,Value2,Value3,ProductDecimals,SumDecimals")] Decimals decimals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decimals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(decimals);
        }

        // GET: Decimals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decimals = await _context.Decimals.FindAsync(id);
            if (decimals == null)
            {
                return NotFound();
            }
            return View(decimals);
        }

        // POST: Decimals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value1,Value2,Value3,ProductDecimals,SumDecimals")] Decimals decimals)
        {
            if (id != decimals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(decimals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DecimalsExists(decimals.Id))
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
            return View(decimals);
        }

        // GET: Decimals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var decimals = await _context.Decimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (decimals == null)
            {
                return NotFound();
            }

            return View(decimals);
        }

        // POST: Decimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var decimals = await _context.Decimals.FindAsync(id);
            _context.Decimals.Remove(decimals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DecimalsExists(int id)
        {
            return _context.Decimals.Any(e => e.Id == id);
        }
    }
}
