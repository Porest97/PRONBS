﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;
using PRONBS.Models.ViewModels;

namespace PRONBS.Controllers.ReportingControllers
{
    [Authorize]
    public class WLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WLog
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)
                .Include(w => w.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListWLogs
        public IActionResult ListWLogs()
        {
            var dataViewModel = new DataViewModel()
            {
                WLogs = _context.WLog
                .Include(w => w.WLogStatus)
                .Include(w => w.Incident)
                .Include(w => w.Employee)
                .ToList()
            };
            return View(dataViewModel);
        }
        // GET: ListWLogsPO
        public IActionResult ListWLogsPO()
        {
            var dataViewModel = new DataViewModel()
            {
                WLogs = _context.WLog
                .Include(w => w.WLogStatus)
                .Include(w => w.Incident)
                .Include(w => w.Employee).Where(w => w.PersonId == 3)
                .ToList()
            };
            return View(dataViewModel);
        }
        // GET: ListWLogsJM
        public IActionResult ListWLogsJM()
        {
            var dataViewModel = new DataViewModel()
            {
                WLogs = _context.WLog
                .Include(w => w.WLogStatus)
                .Include(w => w.Incident)
                .Include(w => w.Employee).Where(w => w.PersonId == 2)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: WLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLog = await _context.WLog
                .Include(w => w.Incident)                
                .Include(w => w.WLogStatus)
                .Include(w => w.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wLog == null)
            {
                return NotFound();
            }

            return View(wLog);
        }

        // GET: WLogs/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["WLogStatusId"] = new SelectList(_context.WLogStatus, "Id", "WLogStatusName");
            return View();
        }

        // POST: WLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WLNumber,Hours,DateTimeFrom,DateTimeTo,Subject,WLogStatusId,IncidentId,PersonId")] WLog wLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListWLogs));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", wLog.IncidentId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", wLog.PersonId);
            ViewData["WLogStatusId"] = new SelectList(_context.WLogStatus, "Id", "WLogStatusName", wLog.WLogStatusId);
            return View(wLog);
        }

        // GET: WLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLog = await _context.WLog.FindAsync(id);
            if (wLog == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", wLog.IncidentId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", wLog.PersonId);
            ViewData["WLogStatusId"] = new SelectList(_context.WLogStatus, "Id", "WLogStatusName", wLog.WLogStatusId);
            return View(wLog);
        }

        // POST: WLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WLNumber,Hours,DateTimeFrom,DateTimeTo,Subject,WLogStatusId,IncidentId,PersonId")] WLog wLog)
        {
            if (id != wLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WLogExists(wLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListWLogs));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", wLog.IncidentId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", wLog.PersonId);
            ViewData["WLogStatusId"] = new SelectList(_context.WLogStatus, "Id", "WLogStatusName", wLog.WLogStatusId);
            return View(wLog);
        }

        // GET: WLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLog = await _context.WLog
                .Include(w => w.Incident)
                .Include(w => w.WLogStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wLog == null)
            {
                return NotFound();
            }

            return View(wLog);
        }

        // POST: WLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wLog = await _context.WLog.FindAsync(id);
            _context.WLog.Remove(wLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListWLogs));
        }

        private bool WLogExists(int id)
        {
            return _context.WLog.Any(e => e.Id == id);
        }
    }
}
