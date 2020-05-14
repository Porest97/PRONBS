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

namespace PRONBS.Controllers.ProspectingControllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        //public double TotalProjectCost { get; private set; }

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Project
                .Include(p => p.Offer1)
                .Include(p => p.Offer2)
                .Include(p => p.Offer3)
                .Include(p => p.Offer4)
                .Include(p => p.Offer5)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectType)
                .Include(p => p.Site)
                .Include(p => p.Technichian);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListProjects -  Created
        public IActionResult ListProjectsCreated()
        {
            var dataViewModel = new DataViewModel()
            {

                Projects = _context.Project
                .Include(p => p.Offer1)
                .Include(p => p.Offer2)
                .Include(p => p.Offer3)
                .Include(p => p.Offer4)
                .Include(p => p.Offer5)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus).Where(p => p.ProjectStatusId == 1)
                .Include(p => p.ProjectType)
                .Include(p => p.Site)
                .Include(p => p.Technichian)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Offer1)
                .Include(p => p.Offer2)
                .Include(p => p.Offer3)
                .Include(p => p.Offer4)
                .Include(p => p.Offer5)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectType)
                .Include(p => p.Site)
                .Include(p => p.Technichian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Details/Log
        public async Task<IActionResult> LogDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Offer1)
                .Include(p => p.Offer2)
                .Include(p => p.Offer3)
                .Include(p => p.Offer4)
                .Include(p => p.Offer5)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectType)
                .Include(p => p.Site)
                .Include(p => p.Technichian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["OfferId"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer");
            ViewData["OfferId1"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer");
            ViewData["OfferId2"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer");
            ViewData["OfferId3"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer");
            ViewData["OfferId4"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["ProjectStatusId"] = new SelectList(_context.Set<ProjectStatus>(), "Id", "ProjectStatusName");
            ViewData["ProjectTypeId"] = new SelectList(_context.Set<ProjectType>(), "Id", "ProjectTypeName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteId,PersonId,PersonId1,ExtraPeople,OfferId,OfferId1,OfferId2,OfferId3,OfferId4,ProjectDescription,ProjectStart,ProjectEnd,ProjectTypeId,ProjectStatusId,ProjectLog,TotalProjectCost,TotalHoursCost,TotalMtrCost")] Project project)
        {
            if (ModelState.IsValid)
            {
                //var applicationContext = _context.Project
                // .Include(p => p.Offer1)
                //.Include(p => p.Offer2)
                //.Include(p => p.Offer3)
                //.Include(p => p.Offer4)
                //.Include(p => p.Offer5)
                //.Include(p => p.ProjectManager)
                //.Include(p => p.ProjectStatus)
                //.Include(p => p.ProjectType)
                //.Include(p => p.Site)
                //.Include(p => p.Technichian);



                //project.TotalProjectCost = project.Offer1.TotalOfferAmount
                //    + project.Offer2.TotalOfferAmount
                //    + project.Offer3.TotalOfferAmount
                //    + project.Offer4.TotalOfferAmount
                //    + project.Offer5.TotalOfferAmount;

                //project.TotalHoursCost = project.Offer1.KostHours
                //   + project.Offer2.KostHours
                //   + project.Offer3.KostHours
                //   + project.Offer4.KostHours
                //   + project.Offer5.KostHours;

                //project.TotalMtrCost = project.Offer1.KostMtrl
                //   + project.Offer2.KostMtrl
                //   + project.Offer3.KostMtrl
                //   + project.Offer4.KostMtrl
                //   + project.Offer5.KostMtrl;

                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListProjectsCreated));
            }
            ViewData["OfferId"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId);
            ViewData["OfferId1"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId1);
            ViewData["OfferId2"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId2);
            ViewData["OfferId3"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId3);
            ViewData["OfferId4"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId4);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId);
            ViewData["ProjectStatusId"] = new SelectList(_context.Set<ProjectStatus>(), "Id", "ProjectStatusName", project.ProjectStatusId);
            ViewData["ProjectTypeId"] = new SelectList(_context.Set<ProjectType>(), "Id", "ProjectTypeName", project.ProjectTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", project.SiteId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId1);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["OfferId"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId);
            ViewData["OfferId1"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId1);
            ViewData["OfferId2"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId2);
            ViewData["OfferId3"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId3);
            ViewData["OfferId4"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId4);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId);
            ViewData["ProjectStatusId"] = new SelectList(_context.Set<ProjectStatus>(), "Id", "ProjectStatusName", project.ProjectStatusId);
            ViewData["ProjectTypeId"] = new SelectList(_context.Set<ProjectType>(), "Id", "ProjectTypeName", project.ProjectTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", project.SiteId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId1);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteId,PersonId,PersonId1,ExtraPeople,OfferId,OfferId1,OfferId2,OfferId3,OfferId4,ProjectDescription,ProjectStart,ProjectEnd,ProjectTypeId,ProjectStatusId,ProjectLog,TotalProjectCost,TotalHoursCost,TotalMtrCost")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                //  var applicationContext = _context.Project
                // .Include(p => p.Offer1)
                // .Include(p => p.Offer1.TotalOfferAmount)
                // .Include(p => p.Offer1.KostMtrl)
                // .Include(p => p.Offer1.KostHours)
                //.Include(p => p.Offer2)
                //.Include(p => p.Offer2.TotalOfferAmount)
                // .Include(p => p.Offer2.KostMtrl)
                // .Include(p => p.Offer2.KostHours)
                //.Include(p => p.Offer3)
                //.Include(p => p.Offer3.TotalOfferAmount)
                // .Include(p => p.Offer3.KostMtrl)
                // .Include(p => p.Offer3.KostHours)
                //.Include(p => p.Offer4)
                //.Include(p => p.Offer4.TotalOfferAmount)
                // .Include(p => p.Offer4.KostMtrl)
                //.Include(p => p.Offer4.KostHours)
                //.Include(p => p.Offer5)
                //.Include(p => p.Offer5.TotalOfferAmount)
                // .Include(p => p.Offer5.KostMtrl)
                //.Include(p => p.Offer5.KostHours)
                //.Include(p => p.ProjectManager)
                //.Include(p => p.ProjectStatus)
                //.Include(p => p.ProjectType)
                //.Include(p => p.Site)
                //.Include(p => p.Technichian);

                //    project.TotalProjectCost = project.Offer1.TotalOfferAmount
                //   + project.Offer2.TotalOfferAmount
                //   + project.Offer3.TotalOfferAmount
                //   + project.Offer4.TotalOfferAmount
                //   + project.Offer5.TotalOfferAmount;

                //    project.TotalHoursCost = project.Offer1.KostHours
                //       + project.Offer2.KostHours
                //       + project.Offer3.KostHours
                //       + project.Offer4.KostHours
                //       + project.Offer5.KostHours;

                //    project.TotalMtrCost = project.Offer1.KostMtrl
                //       + project.Offer2.KostMtrl
                //       + project.Offer3.KostMtrl
                //       + project.Offer4.KostMtrl
                //       + project.Offer5.KostMtrl;

                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListProjectsCreated));
            }
            ViewData["OfferId"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId);
            ViewData["OfferId1"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId1);
            ViewData["OfferId2"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId2);
            ViewData["OfferId3"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId3);
            ViewData["OfferId4"] = new SelectList(_context.Offer, "Id", "OfferIdenifyer", project.OfferId4);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId);
            ViewData["ProjectStatusId"] = new SelectList(_context.Set<ProjectStatus>(), "Id", "ProjectStatusName", project.ProjectStatusId);
            ViewData["ProjectTypeId"] = new SelectList(_context.Set<ProjectType>(), "Id", "ProjectTypeName", project.ProjectTypeId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", project.SiteId);
            ViewData["PersonId1"] = new SelectList(_context.Person, "Id", "FullName", project.PersonId1);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Offer1)
                .Include(p => p.Offer2)
                .Include(p => p.Offer3)
                .Include(p => p.Offer4)
                .Include(p => p.Offer5)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectType)
                .Include(p => p.Site)
                .Include(p => p.Technichian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListProjectsCreated));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }
    }
}
