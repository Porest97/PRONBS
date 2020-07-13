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
    public class TimeLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeLog
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> IndexSearch(string searchString, string searchString1, string searchString2, string searchString3)
        {


            var timeLogs = from t in _context.TimeLog
               .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                           select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                timeLogs = timeLogs
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .Where(s => s.Incident.IncidentNumber.Contains(searchString));

            }           
            if (!String.IsNullOrEmpty(searchString1))
            {
                timeLogs = timeLogs
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .Where(s => s.Employee.FirstName.Contains(searchString1));

            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                timeLogs = timeLogs
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .Where(s => s.Employee.LastName.Contains(searchString2));

            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                timeLogs = timeLogs
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .Where(s => s.TimeLogStatus.TimeLogStatusName.Contains(searchString3));

            }


            return View(await timeLogs.ToListAsync());
        }

        // GET: TimeLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLog
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLog == null)
            {
                return NotFound();
            }

            return View(timeLog);
        }

        // GET: TimeLogs/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["TimeLogStatusId"] = new SelectList(_context.Set<TimeLogStatus>(), "Id", "TimeLogStatusName");
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber");
            return View();
        }

        // POST: TimeLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,TimeLogStatusId,PersonId")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.TimeLog
                 .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog);
                timeLog.TotalCost = (timeLog.Hours * timeLog.PriceHour) + timeLog.MtrCost;


                _context.Add(timeLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeLog.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", timeLog.IncidentId);
            ViewData["TimeLogStatusId"] = new SelectList(_context.Set<TimeLogStatus>(), "Id", "TimeLogStatusName", timeLog.TimeLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLogNumber", timeLog.WLogId);
            return View(timeLog);
        }

        // GET: TimeLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLog.FindAsync(id);
            if (timeLog == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeLog.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", timeLog.IncidentId);
            ViewData["TimeLogStatusId"] = new SelectList(_context.Set<TimeLogStatus>(), "Id", "TimeLogStatusName", timeLog.TimeLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", timeLog.WLogId);
            return View(timeLog);
        }

        // POST: TimeLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,TimeLogStatusId,PersonId")] TimeLog timeLog)
        {
            if (id != timeLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.TimeLog
                       .Include(t => t.Employee)
                       .Include(t => t.Incident)
                       .Include(t => t.TimeLogStatus)
                       .Include(t => t.WLog);
                    timeLog.TotalCost = (timeLog.Hours * timeLog.PriceHour) + timeLog.MtrCost;

                    _context.Update(timeLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeLogExists(timeLog.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", timeLog.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", timeLog.IncidentId);
            ViewData["TimeLogStatusId"] = new SelectList(_context.Set<TimeLogStatus>(), "Id", "TimeLogStatusName", timeLog.TimeLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", timeLog.WLogId);
            return View(timeLog);
        }

        // GET: TimeLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLog = await _context.TimeLog
                .Include(t => t.Employee)
                .Include(t => t.Incident)
                .Include(t => t.TimeLogStatus)
                .Include(t => t.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLog == null)
            {
                return NotFound();
            }

            return View(timeLog);
        }

        // POST: TimeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeLog = await _context.TimeLog.FindAsync(id);
            _context.TimeLog.Remove(timeLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool TimeLogExists(int id)
        {
            return _context.TimeLog.Any(e => e.Id == id);
        }
    }
}
