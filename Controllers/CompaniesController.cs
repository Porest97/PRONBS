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

namespace PRONBS.Controllers
{
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Company
                .Include(c => c.CompanyRole)
                .Include(c => c.CompanyStatus)
                .Include(c => c.CompanyType);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListCompanies()
        {


            var dataViewModel = new DataViewModel()
            {
                Companies = _context.Company
                .Include(c => c.CompanyRole)
                .Include(c => c.CompanyStatus)
                .Include(c => c.CompanyType)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.CompanyRole)
                .Include(c => c.CompanyStatus)
                .Include(c => c.CompanyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName");
            ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName");
            ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyNumber,CompanyName,StreetAddress,ZipCode,City,Country,CompanyRoleId,CompanyStatusId,CompanyTypeId")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListCompanies));
            }
            ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
            ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
            ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
            ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
            ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyNumber,CompanyName,StreetAddress,ZipCode,City,Country,CompanyRoleId,CompanyStatusId,CompanyTypeId")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListCompanies));
            }
            ViewData["CompanyRoleId"] = new SelectList(_context.Set<CompanyRole>(), "Id", "CompanyRoleName", company.CompanyRoleId);
            ViewData["CompanyStatusId"] = new SelectList(_context.Set<CompanyStatus>(), "Id", "CompanyStatusName", company.CompanyStatusId);
            ViewData["CompanyTypeId"] = new SelectList(_context.Set<CompanyType>(), "Id", "CompanyTypeName", company.CompanyTypeId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .Include(c => c.CompanyRole)
                .Include(c => c.CompanyStatus)
                .Include(c => c.CompanyType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListCompanies));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}
