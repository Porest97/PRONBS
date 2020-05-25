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
    public class ProjectReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectReports
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProjectReport
                .Include(p => p.Project)                
                .Include(p => p.ReportStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProjectReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectReport = await _context.ProjectReport
                .Include(p => p.Project)                
                .Include(p => p.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectReport == null)
            {
                return NotFound();
            }

            return View(projectReport);
        }

        // GET: ProjectReports/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectDescription");
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName");
            return View();
        }

        // POST: ProjectReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportName,ReportConclusions,ProjectId,ReportStatusId")] ProjectReport projectReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectDescription", projectReport.ProjectId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", projectReport.ReportStatusId);
            return View(projectReport);
        }

        // GET: ProjectReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectReport = await _context.ProjectReport.FindAsync(id);
            if (projectReport == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectDescription", projectReport.ProjectId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", projectReport.ReportStatusId);
            return View(projectReport);
        }

        // POST: ProjectReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReportName,ReportConclusions,ProjectId,ReportStatusId")] ProjectReport projectReport)
        {
            if (id != projectReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectReportExists(projectReport.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "Id", "ProjectDescription", projectReport.ProjectId);
            ViewData["ReportStatusId"] = new SelectList(_context.Set<ReportStatus>(), "Id", "ReportStatusName", projectReport.ReportStatusId);
            return View(projectReport);
        }

        // GET: ProjectReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectReport = await _context.ProjectReport
                .Include(p => p.Project)
                .Include(p => p.ReportStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectReport == null)
            {
                return NotFound();
            }

            return View(projectReport);
        }

        // POST: ProjectReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectReport = await _context.ProjectReport.FindAsync(id);
            _context.ProjectReport.Remove(projectReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectReportExists(int id)
        {
            return _context.ProjectReport.Any(e => e.Id == id);
        }
    }
}
