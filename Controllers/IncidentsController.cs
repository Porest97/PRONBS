﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;
using PRONBS.Models.ViewModels;

namespace PRONBS.Controllers
{
    public class IncidentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncidentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        //ListIncidents - All
        public IActionResult ListIncidents()
        {
            var dataViewModel = new DataViewModel()
            {
                Incidents = _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .Include(i => i.PurchaseOrder)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Details/Print
        public async Task<IActionResult> DetailsPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName");
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName");
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName");
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber");
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName");
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite");
            return View();
        }

        // POST: Incidents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId")] Incident incident)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incident);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListIncidents));
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident.FindAsync(id);
            if (incident == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // POST: Incidents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentPriorityId,IncidentStatusId,IncidentTypeId,IncidentNumber,Created,PersonId,SiteId,Received,PersonId1,FEScheduled,PersonId2,Description,FEEntersSite,FEEExitsSite,Logg,IssueResolved,Resolution,PurchaseOrderId")] Incident incident)
        {
            if (id != incident.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incident);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentExists(incident.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListIncidents));
            }
            ViewData["PersonId"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId);
            ViewData["PersonId2"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId2);
            ViewData["IncidentPriorityId"] = new SelectList(_context.Set<IncidentPriority>(), "Id", "IncidentPriorityName", incident.IncidentPriorityId);
            ViewData["IncidentStatusId"] = new SelectList(_context.Set<IncidentStatus>(), "Id", "IncidentStatusName", incident.IncidentStatusId);
            ViewData["IncidentTypeId"] = new SelectList(_context.Set<IncidentType>(), "Id", "IncidentTypeName", incident.IncidentTypeId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.Set<PurchaseOrder>(), "Id", "PONumber", incident.PurchaseOrderId);
            ViewData["PersonId1"] = new SelectList(_context.Set<Person>(), "Id", "FullName", incident.PersonId1);
            ViewData["SiteId"] = new SelectList(_context.Set<Site>(), "Id", "NoSite", incident.SiteId);
            return View(incident);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incident = await _context.Incident
                .Include(i => i.Creator)
                .Include(i => i.FEAssigned)
                .Include(i => i.IncidentPriority)
                .Include(i => i.IncidentStatus)
                .Include(i => i.IncidentType)
                .Include(i => i.PurchaseOrder)
                .Include(i => i.Receiver)
                .Include(i => i.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incident = await _context.Incident.FindAsync(id);
            _context.Incident.Remove(incident);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListIncidents));
        }

        private bool IncidentExists(int id)
        {
            return _context.Incident.Any(e => e.Id == id);
        }
    }
}