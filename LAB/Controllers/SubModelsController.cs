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
    public class SubModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubModel.ToListAsync());
        }

        public IActionResult ListSubModels()
        {
            var viewModel = new ViewModel()
            {
                SubModels = _context.SubModel              
                .ToList()
            };
            return View(viewModel);
        }

        // GET: SubModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subModel = await _context.SubModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subModel == null)
            {
                return NotFound();
            }

            return View(subModel);
        }

        // GET: SubModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Hours,Price,Mtr,TotalCost")] SubModel subModel)
        {
            if (ModelState.IsValid)
            {
                var applicationContext = _context.SubModel;
                   
                subModel.TotalCost = (subModel.Hours * subModel.Price) + subModel.Mtr;               


                _context.Add(subModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListSubModels));
            }
            return View(subModel);
        }

        // GET: SubModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subModel = await _context.SubModel.FindAsync(id);
            if (subModel == null)
            {
                return NotFound();
            }
            return View(subModel);
        }

        // POST: SubModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Hours,Price,Mtr,TotalCost")] SubModel subModel)
        {
            if (id != subModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var applicationContext = _context.SubModel;


                subModel.TotalCost = (subModel.Hours * subModel.Price) + subModel.Mtr;

                    _context.Update(subModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubModelExists(subModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListSubModels));
            }
            return View(subModel);
        }

        // GET: SubModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subModel = await _context.SubModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subModel == null)
            {
                return NotFound();
            }

            return View(subModel);
        }

        // POST: SubModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subModel = await _context.SubModel.FindAsync(id);
            _context.SubModel.Remove(subModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListSubModels));
        }

        private bool SubModelExists(int id)
        {
            return _context.SubModel.Any(e => e.Id == id);
        }
    }
}
