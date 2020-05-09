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
    public class PersonAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonAccounts.ToListAsync());
        }


        // GET: PersonAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAccounts = await _context.PersonAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personAccounts == null)
            {
                return NotFound();
            }

            return View(personAccounts);
        }

        // GET: PersonAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SwishNumber,BankAccount,BankName")] PersonAccounts personAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personAccounts);
        }

        // GET: PersonAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAccounts = await _context.PersonAccounts.FindAsync(id);
            if (personAccounts == null)
            {
                return NotFound();
            }
            return View(personAccounts);
        }

        // POST: PersonAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SwishNumber,BankAccount,BankName")] PersonAccounts personAccounts)
        {
            if (id != personAccounts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonAccountsExists(personAccounts.Id))
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
            return View(personAccounts);
        }

        // GET: PersonAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personAccounts = await _context.PersonAccounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personAccounts == null)
            {
                return NotFound();
            }

            return View(personAccounts);
        }

        // POST: PersonAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personAccounts = await _context.PersonAccounts.FindAsync(id);
            _context.PersonAccounts.Remove(personAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonAccountsExists(int id)
        {
            return _context.PersonAccounts.Any(e => e.Id == id);
        }
    }
}
