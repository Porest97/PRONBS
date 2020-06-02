using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;

namespace PRONBS.Controllers.SettingsControllers
{
    public class StageStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StageStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StageStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.StageStatus.ToListAsync());
        }

        // GET: StageStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageStatus = await _context.StageStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageStatus == null)
            {
                return NotFound();
            }

            return View(stageStatus);
        }

        // GET: StageStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StageStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StageStatusName")] StageStatus stageStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stageStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stageStatus);
        }

        // GET: StageStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageStatus = await _context.StageStatus.FindAsync(id);
            if (stageStatus == null)
            {
                return NotFound();
            }
            return View(stageStatus);
        }

        // POST: StageStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StageStatusName")] StageStatus stageStatus)
        {
            if (id != stageStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stageStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageStatusExists(stageStatus.Id))
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
            return View(stageStatus);
        }

        // GET: StageStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stageStatus = await _context.StageStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stageStatus == null)
            {
                return NotFound();
            }

            return View(stageStatus);
        }

        // POST: StageStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stageStatus = await _context.StageStatus.FindAsync(id);
            _context.StageStatus.Remove(stageStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageStatusExists(int id)
        {
            return _context.StageStatus.Any(e => e.Id == id);
        }
    }
}
