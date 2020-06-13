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
using PRONBS.Models.ViewModels;

namespace PRONBS.Controllers.ProspectingControllers
{
    [Authorize]
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Plan
                .Include(p => p.Incident)
                .Include(p => p.PlanStatus)
                .Include(p => p.Stage1)
                .Include(p => p.Stage2)
                .Include(p => p.Stage3)
                .Include(p => p.Stage4)
                .Include(p => p.Stage5)
                .Include(p => p.Stage6);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NABLogs with Inc# - search
        public async Task<IActionResult> IndexSearch(string searchString)
        {
            var plans = from p in _context.Plan
                .Include(p => p.Incident)
                .Include(p => p.PlanStatus)
                .Include(p => p.Stage1)
                .Include(p => p.Stage2)
                .Include(p => p.Stage3)
                .Include(p => p.Stage4)
                .Include(p => p.Stage5)
                .Include(p => p.Stage6)

                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                 plans = plans
                .Include(s => s.Incident)
                .Include(s => s.PlanStatus)
                .Include(s => s.Stage1)
                .Include(s => s.Stage2)
                .Include(s => s.Stage3)
                .Include(s => s.Stage4)
                .Include(s => s.Stage5)
                .Include(s => s.Stage6)
                .Where(s => s.Incident.IncidentNumber.Contains(searchString));

            }
            return View(await plans.ToListAsync());
        }

        // GET: ListPlansCreated
        public IActionResult ListPlansCreated()
        {
            var dataViewModel = new DataViewModel()
            {
                 Plans = _context.Plan
                 .Include(p => p.Incident)
                .Include(p => p.PlanStatus)
                .Include(p => p.Stage1)
                .Include(p => p.Stage2)
                .Include(p => p.Stage3)
                .Include(p => p.Stage4)
                .Include(p => p.Stage5)
                .Include(p => p.Stage6).Where(p => p.PlanStatusId == 1)

                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Plans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .Include(p => p.Incident)
                .Include(p => p.Incident.Site)
                .Include(p => p.PlanStatus)
                .Include(p => p.Stage1)
                .Include(p => p.Stage2)
                .Include(p => p.Stage3)
                .Include(p => p.Stage4)
                .Include(p => p.Stage5)
                .Include(p => p.Stage6)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plans/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["PlanStatusId"] = new SelectList(_context.Set<PlanStatus>(), "Id", "PlanStatusName");
            ViewData["StageId"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            ViewData["StageId1"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            ViewData["StageId2"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            ViewData["StageId3"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            ViewData["StageId4"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            ViewData["StageId5"] = new SelectList(_context.Set<Stage>(), "Id", "Description");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlanDescription,IncidentId,StageId,StageId1,StageId2,StageId3,StageId4,StageId5,PlanStatusId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListPlansCreated));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", plan.IncidentId);
            ViewData["PlanStatusId"] = new SelectList(_context.Set<PlanStatus>(), "Id", "PlanStatusName", plan.PlanStatusId);
            ViewData["StageId"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId);
            ViewData["StageId1"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId1);
            ViewData["StageId2"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId2);
            ViewData["StageId3"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId3);
            ViewData["StageId4"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId4);
            ViewData["StageId5"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId5);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", plan.IncidentId);
            ViewData["PlanStatusId"] = new SelectList(_context.Set<PlanStatus>(), "Id", "PlanStatusName", plan.PlanStatusId);
            ViewData["StageId"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId);
            ViewData["StageId1"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId1);
            ViewData["StageId2"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId2);
            ViewData["StageId3"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId3);
            ViewData["StageId4"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId4);
            ViewData["StageId5"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId5);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanDescription,IncidentId,StageId,StageId1,StageId2,StageId3,StageId4,StageId5,PlanStatusId")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListPlansCreated));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", plan.IncidentId);
            ViewData["PlanStatusId"] = new SelectList(_context.Set<PlanStatus>(), "Id", "PlanStatusName", plan.PlanStatusId);
            ViewData["StageId"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId);
            ViewData["StageId1"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId1);
            ViewData["StageId2"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId2);
            ViewData["StageId3"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId3);
            ViewData["StageId4"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId4);
            ViewData["StageId5"] = new SelectList(_context.Set<Stage>(), "Id", "Description", plan.StageId5);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .Include(p => p.Incident)
                .Include(p => p.PlanStatus)
                .Include(p => p.Stage1)
                .Include(p => p.Stage2)
                .Include(p => p.Stage3)
                .Include(p => p.Stage4)
                .Include(p => p.Stage5)
                .Include(p => p.Stage6)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _context.Plan.FindAsync(id);
            _context.Plan.Remove(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListPlansCreated));
        }

        private bool PlanExists(int id)
        {
            return _context.Plan.Any(e => e.Id == id);
        }
    }
}
