using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;
using PRONBS.Models.ViewModels;

namespace PRONBS.Controllers.ReportingControllers
{
    public class NABLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NABLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NABLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListNABLogsCreated
        public IActionResult ListNABLogsCreated()
        {
            var dataViewModel = new DataViewModel()
            {
                NABLogs = _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog).Where(n => n.NABLogStatusId == 1)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListNABLogsReported
        public IActionResult ListNABLogsReported()
        {
            var dataViewModel = new DataViewModel()
            {
                NABLogs = _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog).Where(n => n.NABLogStatusId == 2)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListNABLogsBilled
        public IActionResult ListNABLogsBilled()
        {
            var dataViewModel = new DataViewModel()
            {
                NABLogs = _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog).Where(n => n.NABLogStatusId == 3)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: NABLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLog == null)
            {
                return NotFound();
            }

            return View(nABLog);
        }

        // GET: NABLogs/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName");
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber");
            return View();
        }

        // POST: NABLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,NABLogStatusId")] NABLog nABLog)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.NABLog
                   .Include(nl => nl.Incident)
                   .Include(nl => nl.NABLogStatus)
                   .Include(nl => nl.WLog);                   
                nABLog.TotalCost = (nABLog.Hours * nABLog.PriceHour) + nABLog.MtrCost;
                

                _context.Add(nABLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListNABLogsCreated));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
            return View(nABLog);
        }

        // GET: NABLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog.FindAsync(id);
            if (nABLog == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
            return View(nABLog);
        }

        // POST: NABLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,NABLogStatusId")] NABLog nABLog)
        {
            if (id != nABLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.NABLog
                   .Include(nl => nl.Incident)
                   .Include(nl => nl.NABLogStatus)
                   .Include(nl => nl.WLog);
                    nABLog.TotalCost = (nABLog.Hours * nABLog.PriceHour) + nABLog.MtrCost;

                    _context.Update(nABLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NABLogExists(nABLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListNABLogsCreated));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
            return View(nABLog);
        }

        // GET: NABLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLog == null)
            {
                return NotFound();
            }

            return View(nABLog);
        }

        // POST: NABLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nABLog = await _context.NABLog.FindAsync(id);
            _context.NABLog.Remove(nABLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListNABLogsCreated));
        }

        private bool NABLogExists(int id)
        {
            return _context.NABLog.Any(e => e.Id == id);
        }
    }
}
