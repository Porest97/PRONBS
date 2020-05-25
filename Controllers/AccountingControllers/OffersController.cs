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
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Offers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ListQuotations -  Created
        public IActionResult ListQuotationsCreated()
        {
            var dataViewModel = new DataViewModel()
            {

                Quotations = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus).Where(o=>o.OfferStatusId == 1)
                .Include(o => o.Site)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListQuotations -  Sent
        public IActionResult ListQuotationsSent()
        {
            var dataViewModel = new DataViewModel()
            {
                Quotations = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus).Where(o => o.OfferStatusId == 2)
                .Include(o => o.Site)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListQuotations -  Accepted
        public IActionResult ListQuotationsAccepted()
        {
            var dataViewModel = new DataViewModel()
            {
                Quotations = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus).Where(o => o.OfferStatusId == 3)
                .Include(o => o.Site)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: ListQuotations -  Rejected
        public IActionResult ListQuotationsRejected()
        {
            var dataViewModel = new DataViewModel()
            {
                Quotations = _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus).Where(o => o.OfferStatusId == 4)
                .Include(o => o.Site)
                .ToList()
            };
            return View(dataViewModel);
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Details/5
        public async Task<IActionResult> DetailsPrint(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);

            offer.KostMtrl /= 10;
            offer.PricePerHour /= 10;

            offer.KostHours = (offer.HoursOnSite * offer.PricePerHour);
            
            offer.TotalOfferAmount = ((offer.KostHours + offer.KostMtrl) * offer.Riskfaktor);

            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offers/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "NumberDescription");
            ViewData["OfferStatusId"] = new SelectList(_context.Set<OfferStatus>(), "Id", "OfferStatusName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            return View();
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferIdenifyer,DateTimeOffered,OfferStatusId,PersonId,SiteId,IncidentId,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount,File")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.Offer
                    .Include(o => o.Employee)
                    .Include(o => o.Incident)
                     .Include(o => o.OfferStatus)                
                    .Include(o => o.Site);
                offer.KostHours = offer.HoursOnSite * offer.PricePerHour;

                offer.TotalOfferAmount = (offer.KostHours + offer.KostMtrl) * offer.Riskfaktor;

                _context.Add(offer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListQuotationsCreated));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "NumberDescription", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.Set<OfferStatus>(), "Id", "OfferStatusName", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "NumberDescription", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.Set<OfferStatus>(), "Id", "OfferStatusName", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", offer.SiteId);
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfferIdenifyer,DateTimeOffered,OfferStatusId,PersonId,SiteId,IncidentId,DateTimeScheduledStart,DateTimeScheduledEnd,HoursOnSite,PricePerHour,KostHours,KostMtrl,Riskfaktor,TotalOfferAmount,File")] Offer offer)
        {
            if (id != offer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.Offer
                    .Include(o => o.Employee)
                    .Include(o => o.Incident)
                     .Include(o => o.OfferStatus)
                    .Include(o => o.Site);
                    offer.KostHours = offer.HoursOnSite * offer.PricePerHour;

                    offer.TotalOfferAmount = (offer.KostHours + offer.KostMtrl) * offer.Riskfaktor;


                    _context.Update(offer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferExists(offer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListQuotationsCreated));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", offer.PersonId);
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "NumberDescription", offer.IncidentId);
            ViewData["OfferStatusId"] = new SelectList(_context.Set<OfferStatus>(), "Id", "OfferStatusName", offer.OfferStatusId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", offer.SiteId);
            return View(offer);
        }

        // GET: Offers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer
                .Include(o => o.Employee)
                .Include(o => o.Incident)
                .Include(o => o.OfferStatus)
                .Include(o => o.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offer == null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offer = await _context.Offer.FindAsync(id);
            _context.Offer.Remove(offer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListQuotationsCreated));
        }

        private bool OfferExists(int id)
        {
            return _context.Offer.Any(e => e.Id == id);
        }
    }
}
