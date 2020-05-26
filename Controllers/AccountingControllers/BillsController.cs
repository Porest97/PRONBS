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

namespace PRONBS.Controllers.AccountingControllers
{
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListBillsCreated
        public IActionResult ListBillsCreated()
        {
            var dataViewModel = new DataViewModel()
            {
                Bills = _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5).Where(b => b.BillStatusId == 1)

                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog1.WLog)                
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName");
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,CompanyId1,BillingDate,DueDate,NABLogId,NABLogId1,NABLogId2,NABLogId3,NABLogId4,BillingTerms,Hours,PriceHour,MtrCost,TotalCost,BillStatusId")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListBillsCreated));
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyId,CompanyId1,BillingDate,DueDate,NABLogId,NABLogId1,NABLogId2,NABLogId3,NABLogId4,BillingTerms,Hours,PriceHour,MtrCost,TotalCost,BillStatusId")] Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListBillsCreated));
            }
            ViewData["BillStatusId"] = new SelectList(_context.BillStatus, "Id", "BillStatusName", bill.BillStatusId);
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", bill.CompanyId);
            ViewData["NABLogId"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId);
            ViewData["NABLogId1"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId1);
            ViewData["NABLogId2"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId2);
            ViewData["NABLogId3"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId3);
            ViewData["NABLogId4"] = new SelectList(_context.NABLog, "Id", "LogNotes", bill.NABLogId4);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.BillStatusStatus)
                .Include(b => b.CompanyBilling)
                .Include(b => b.CompanyToBill)
                .Include(b => b.NABLog1)
                .Include(b => b.NABLog1.WLog)
                .Include(b => b.NABLog1.WLog.WLNumber)
                .Include(b => b.NABLog2)
                .Include(b => b.NABLog3)
                .Include(b => b.NABLog4)
                .Include(b => b.NABLog5)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bill.FindAsync(id);
            _context.Bill.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListBillsCreated));
        }

        private bool BillExists(int id)
        {
            return _context.Bill.Any(e => e.Id == id);
        }
    }
}
