using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;

namespace PRONBS.Controllers.ReportingControllers
{
    public class TimeReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: TimeReportsSearch

        public async Task<IActionResult> IndexSearch(string searchString, string searchString1, string searchString2)
        {
            var timeReports = from t in _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)

                              select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.TimeReportName.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.Employee.FirstName.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                timeReports = timeReports
                 .Include(t => t.Creator)
                 .Include(t => t.Employee)
                 .Where(s => s.Employee.LastName.Contains(searchString2));
            }
            return View(await timeReports.ToListAsync());
        }

        // GET: TimeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // GET: TimeReports/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: TimeReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeReportName,Description,DateTimeCreated,DateTimeFrom,DateTimeTo,PersonId,PersonId1")] TimeReport timeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId1);
            return View(timeReport);
        }

        // GET: TimeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport.FindAsync(id);
            if (timeReport == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId1);
            return View(timeReport);
        }

        // POST: TimeReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeReportName,Description,DateTimeCreated,DateTimeFrom,DateTimeTo,PersonId,PersonId1")] TimeReport timeReport)
        {
            if (id != timeReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeReportExists(timeReport.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", timeReport.PersonId1);
            return View(timeReport);
        }

        // GET: TimeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // POST: TimeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeReport = await _context.TimeReport.FindAsync(id);
            _context.TimeReport.Remove(timeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool TimeReportExists(int id)
        {
            return _context.TimeReport.Any(e => e.Id == id);
        }
    }
}
