using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.LAB.Models.DataModels;
using PRONBS.LAB.Models.ViewModels;

namespace PRONBS.LAB.Controllers
{
    [Authorize]
    public class TestModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TestModel
                .Include(t => t.Offer1)
                .Include(t => t.Offer2);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult ListTestModels()
        {
            var viewModel = new ViewModel()
            {
                TestModels = _context.TestModel
                .Include(t => t.Offer1)
                .Include(t => t.Offer2)
                .ToList()
            };
            return View(viewModel);
        }

        // GET: TestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel
                .Include(t => t.Offer1)
                .Include(t => t.Offer2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // GET: TestModels/Create
        public IActionResult Create()
        {
            ViewData["SubModelId"] = new SelectList(_context.Set<SubModel>(), "Id", "Description");
            ViewData["SubModelId1"] = new SelectList(_context.Set<SubModel>(), "Id", "Description");
            return View();
        }

        // POST: TestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,TotalHours,TotalMtr,TotalAmount,SubModelId,SubModelId1")] TestModel testModel)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.TestModel
                   .Include(t => t.Offer1)
                   .Include(t => t.Offer2);



                //testModel.Offer1.TotalCost = (testModel.Offer1.Hours * testModel.Offer1.Price) + testModel.Offer1.Mtr;

                //testModel.Offer2.TotalCost = (testModel.Offer2.Hours * testModel.Offer2.Price) + testModel.Offer2.Mtr;

                testModel.TotalAmount = testModel.Offer1.TotalCost + testModel.Offer2.TotalCost;


                _context.Add(testModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListTestModels));
            }
            ViewData["SubModelId"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId);
            ViewData["SubModelId1"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId1);
            return View(testModel);
        }

        // GET: TestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }
            ViewData["SubModelId"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId);
            ViewData["SubModelId1"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId1);
            return View(testModel);
        }

        // POST: TestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,TotalHours,TotalMtr,TotalAmount,SubModelId,SubModelId1")] TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.TestModel
                   .Include(t => t.Offer1)
                   .Include(t => t.Offer2);



                    //testModel.Offer1.TotalCost = (testModel.Offer1.Hours * testModel.Offer1.Price) + testModel.Offer1.Mtr;

                    //testModel.Offer2.TotalCost = (testModel.Offer2.Hours * testModel.Offer2.Price) + testModel.Offer2.Mtr;

                    testModel.TotalAmount = testModel.Offer1.TotalCost + testModel.Offer2.TotalCost;

                    _context.Update(testModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestModelExists(testModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListTestModels));
            }
            ViewData["SubModelId"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId);
            ViewData["SubModelId1"] = new SelectList(_context.Set<SubModel>(), "Id", "Description", testModel.SubModelId1);
            return View(testModel);
        }

        // GET: TestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testModel = await _context.TestModel
                .Include(t => t.Offer1)
                .Include(t => t.Offer2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testModel == null)
            {
                return NotFound();
            }

            return View(testModel);
        }

        // POST: TestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testModel = await _context.TestModel.FindAsync(id);
            _context.TestModel.Remove(testModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ViewModel));
        }

        private bool TestModelExists(int id)
        {
            return _context.TestModel.Any(e => e.Id == id);
        }
    }
}
