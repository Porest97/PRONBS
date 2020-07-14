using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRONBS.Data;
using PRONBS.Models.DataModels;

namespace PRONBS.Controllers.ReportingControllers
{
    public class VerificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public VerificationsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Verification
        public async Task<IActionResult> Index()
        {
            return View(await _context.Verification.ToListAsync());
        }

        // GET: Verification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verification = await _context.Verification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verification == null)
            {
                return NotFound();
            }

            return View(verification);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Verification/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ImageFile")] Verification verification)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwwroot/Image !
                string wwwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(verification.ImageFile.FileName);
                string extension = Path.GetExtension(verification.ImageFile.FileName);
                verification.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath + "/Verifications/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await verification.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record !
                _context.Add(verification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verification);
        }

        // GET: Verification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verification = await _context.Verification.FindAsync(id);
            if (verification == null)
            {
                return NotFound();
            }
            return View(verification);
        }

        // POST: Verification/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ImageName")] Verification verification)
        {
            if (id != verification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(verification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificationExists(verification.Id))
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
            return View(verification);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verification = await _context.Verification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verification == null)
            {
                return NotFound();
            }

            return View(verification);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verification = await _context.Verification.FindAsync(id);

            //Delete verification from wwwwroot/Verifications/ !

            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "verification", verification.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            //Deletes the reccourd !
            _context.Verification.Remove(verification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VerificationExists(int id)
        {
            return _context.Verification.Any(e => e.Id == id);
        }
    }
    //public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
}
