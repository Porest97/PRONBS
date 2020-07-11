using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;

namespace PRONBS.Controllers.AccountingControllers
{
    public class InvoicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invoices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invoice
                .Include(i => i.InvoiceFrom)
                .Include(i => i.InvoiceTo)
                .Include(i => i.OurReference)
                .Include(i => i.WL1).Include(i => i.WL10).Include(i => i.WL11).Include(i => i.WL12).Include(i => i.WL13)
                .Include(i => i.WL14).Include(i => i.WL15).Include(i => i.WL16).Include(i => i.WL17).Include(i => i.WL18)
                .Include(i => i.WL19).Include(i => i.WL2).Include(i => i.WL20).Include(i => i.WL3).Include(i => i.WL4)
                .Include(i => i.WL5).Include(i => i.WL6).Include(i => i.WL7).Include(i => i.WL8).Include(i => i.WL9);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.InvoiceFrom)
                .Include(i => i.InvoiceTo)
                .Include(i => i.OurReference)
                .Include(i => i.WL1)
                .Include(i => i.WL1.Incident)
                .Include(i => i.WL10)
                .Include(i => i.WL10.Incident)
                .Include(i => i.WL11)
                .Include(i => i.WL11.Incident)
                .Include(i => i.WL12)
                .Include(i => i.WL12.Incident)
                .Include(i => i.WL13)
                .Include(i => i.WL13.Incident)
                .Include(i => i.WL14)
                .Include(i => i.WL14.Incident)
                .Include(i => i.WL15)
                .Include(i => i.WL15.Incident)
                .Include(i => i.WL16)
                .Include(i => i.WL16.Incident)
                .Include(i => i.WL17)
                .Include(i => i.WL17.Incident)
                .Include(i => i.WL18)
                .Include(i => i.WL18.Incident)
                .Include(i => i.WL19)
                .Include(i => i.WL19.Incident)
                .Include(i => i.WL2)
                .Include(i => i.WL2.Incident)
                .Include(i => i.WL20)
                .Include(i => i.WL20.Incident)
                .Include(i => i.WL3)
                .Include(i => i.WL3.Incident)
                .Include(i => i.WL4)
                .Include(i => i.WL4.Incident)
                .Include(i => i.WL5)
                .Include(i => i.WL5.Incident)
                .Include(i => i.WL6)
                .Include(i => i.WL6.Incident)
                .Include(i => i.WL7)
                .Include(i => i.WL7.Incident)
                .Include(i => i.WL8)
                .Include(i => i.WL8.Incident)
                .Include(i => i.WL9)
                .Include(i => i.WL9.Incident)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: Invoices/Create
        public IActionResult Create()
        {
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["WorkLogId"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId9"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId10"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId11"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId12"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId13"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId14"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId15"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId16"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId17"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId18"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId1"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId19"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId2"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId3"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId4"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId5"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId6"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId7"] = new SelectList(_context.WLog, "Id", "WLNumber");
            ViewData["WorkLogId8"] = new SelectList(_context.WLog, "Id", "WLNumber");
            return View();
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InvoiceDate,InvoiceNumber,OCRNumber,CustomerNumber,TermsOfDelivery," +
            "YourVATNumber,PersonId,PaymentConditions,InvoiceDueDate,PenaltyInetrest,CompanyId,CompanyId1,WorkLogId,WorkLogId1," +
            "WorkLogId2,WorkLogId3,WorkLogId4,WorkLogId5,WorkLogId6,WorkLogId7,WorkLogId8,WorkLogId9,WorkLogId10,WorkLogId11,WorkLogId12," +
            "WorkLogId13,WorkLogId14,WorkLogId15,WorkLogId16,WorkLogId17,WorkLogId18,WorkLogId19")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", invoice.PersonId);
            ViewData["WorkLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId);
            ViewData["WorkLogId9"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId9);
            ViewData["WorkLogId10"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId10);
            ViewData["WorkLogId11"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId11);
            ViewData["WorkLogId12"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId12);
            ViewData["WorkLogId13"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId13);
            ViewData["WorkLogId14"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId14);
            ViewData["WorkLogId15"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId15);
            ViewData["WorkLogId16"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId16);
            ViewData["WorkLogId17"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId17);
            ViewData["WorkLogId18"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId18);
            ViewData["WorkLogId1"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId1);
            ViewData["WorkLogId19"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId19);
            ViewData["WorkLogId2"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId2);
            ViewData["WorkLogId3"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId3);
            ViewData["WorkLogId4"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId4);
            ViewData["WorkLogId5"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId5);
            ViewData["WorkLogId6"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId6);
            ViewData["WorkLogId7"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId7);
            ViewData["WorkLogId8"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId8);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", invoice.PersonId);
            ViewData["WorkLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId);
            ViewData["WorkLogId9"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId9);
            ViewData["WorkLogId10"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId10);
            ViewData["WorkLogId11"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId11);
            ViewData["WorkLogId12"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId12);
            ViewData["WorkLogId13"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId13);
            ViewData["WorkLogId14"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId14);
            ViewData["WorkLogId15"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId15);
            ViewData["WorkLogId16"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId16);
            ViewData["WorkLogId17"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId17);
            ViewData["WorkLogId18"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId18);
            ViewData["WorkLogId1"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId1);
            ViewData["WorkLogId19"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId19);
            ViewData["WorkLogId2"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId2);
            ViewData["WorkLogId3"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId3);
            ViewData["WorkLogId4"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId4);
            ViewData["WorkLogId5"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId5);
            ViewData["WorkLogId6"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId6);
            ViewData["WorkLogId7"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId7);
            ViewData["WorkLogId8"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId8);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InvoiceDate,InvoiceNumber,OCRNumber,CustomerNumber,TermsOfDelivery," +
            "YourVATNumber,PersonId,PaymentConditions,InvoiceDueDate,PenaltyInetrest,CompanyId,CompanyId1,WorkLogId,WorkLogId1," +
            "WorkLogId2,WorkLogId3,WorkLogId4,WorkLogId5,WorkLogId6,WorkLogId7,WorkLogId8,WorkLogId9,WorkLogId10,WorkLogId11,WorkLogId12," +
            "WorkLogId13,WorkLogId14,WorkLogId15,WorkLogId16,WorkLogId17,WorkLogId18,WorkLogId19")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["CompanyId1"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId1);
            ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "CompanyName", invoice.CompanyId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", invoice.PersonId);
            ViewData["WorkLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId);
            ViewData["WorkLogId9"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId9);
            ViewData["WorkLogId10"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId10);
            ViewData["WorkLogId11"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId11);
            ViewData["WorkLogId12"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId12);
            ViewData["WorkLogId13"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId13);
            ViewData["WorkLogId14"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId14);
            ViewData["WorkLogId15"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId15);
            ViewData["WorkLogId16"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId16);
            ViewData["WorkLogId17"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId17);
            ViewData["WorkLogId18"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId18);
            ViewData["WorkLogId1"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId1);
            ViewData["WorkLogId19"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId19);
            ViewData["WorkLogId2"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId2);
            ViewData["WorkLogId3"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId3);
            ViewData["WorkLogId4"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId4);
            ViewData["WorkLogId5"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId5);
            ViewData["WorkLogId6"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId6);
            ViewData["WorkLogId7"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId7);
            ViewData["WorkLogId8"] = new SelectList(_context.WLog, "Id", "WLNumber", invoice.WorkLogId8);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .Include(i => i.InvoiceFrom)
                .Include(i => i.InvoiceTo)
                .Include(i => i.OurReference)
                .Include(i => i.WL1)
                .Include(i => i.WL10)
                .Include(i => i.WL11)
                .Include(i => i.WL12)
                .Include(i => i.WL13)
                .Include(i => i.WL14)
                .Include(i => i.WL15)
                .Include(i => i.WL16)
                .Include(i => i.WL17)
                .Include(i => i.WL18)
                .Include(i => i.WL19)
                .Include(i => i.WL2)
                .Include(i => i.WL20)
                .Include(i => i.WL3)
                .Include(i => i.WL4)
                .Include(i => i.WL5)
                .Include(i => i.WL6)
                .Include(i => i.WL7)
                .Include(i => i.WL8)
                .Include(i => i.WL9)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }
    }
}
