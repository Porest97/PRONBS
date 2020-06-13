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
    public class PlanStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlanStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanStatus.ToListAsync());
        }

        // GET: PlanStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planStatus = await _context.PlanStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planStatus == null)
            {
                return NotFound();
            }

            return View(planStatus);
        }

        // GET: PlanStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlanStatusName")] PlanStatus planStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planStatus);
        }

        // GET: PlanStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planStatus = await _context.PlanStatus.FindAsync(id);
            if (planStatus == null)
            {
                return NotFound();
            }
            return View(planStatus);
        }

        // POST: PlanStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanStatusName")] PlanStatus planStatus)
        {
            if (id != planStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanStatusExists(planStatus.Id))
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
            return View(planStatus);
        }

        // GET: PlanStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planStatus = await _context.PlanStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planStatus == null)
            {
                return NotFound();
            }

            return View(planStatus);
        }

        // POST: PlanStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planStatus = await _context.PlanStatus.FindAsync(id);
            _context.PlanStatus.Remove(planStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanStatusExists(int id)
        {
            return _context.PlanStatus.Any(e => e.Id == id);
        }
    }
}
