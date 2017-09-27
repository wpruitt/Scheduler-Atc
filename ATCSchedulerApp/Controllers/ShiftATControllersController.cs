using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Data;
using ATCScheduler.Models;

namespace ATCScheduler.Controllers
{
    public class ShiftATControllersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftATControllersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ShiftATControllers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShiftATController.Include(s => s.ATController);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShiftATControllers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftATController = await _context.ShiftATController
                .Include(s => s.ATController)
                .SingleOrDefaultAsync(m => m.ShiftATControllerId == id);
            if (shiftATController == null)
            {
                return NotFound();
            }

            return View(shiftATController);
        }

        // GET: ShiftATControllers/Create
        public IActionResult Create()
        {
            ViewData["ATControllerId"] = new SelectList(_context.ATController, "ControllerId", "UserId");
            return View();
        }

        // POST: ShiftATControllers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftATControllerId,ShfitId,ATControllerId")] ShiftATController shiftATController)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftATController);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ATControllerId"] = new SelectList(_context.ATController, "ControllerId", "UserId", shiftATController.ATControllerId);
            return View(shiftATController);
        }

        // GET: ShiftATControllers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftATController = await _context.ShiftATController.SingleOrDefaultAsync(m => m.ShiftATControllerId == id);
            if (shiftATController == null)
            {
                return NotFound();
            }
            ViewData["ATControllerId"] = new SelectList(_context.ATController, "ControllerId", "UserId", shiftATController.ATControllerId);
            return View(shiftATController);
        }

        // POST: ShiftATControllers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftATControllerId,ShfitId,ATControllerId")] ShiftATController shiftATController)
        {
            if (id != shiftATController.ShiftATControllerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftATController);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftATControllerExists(shiftATController.ShiftATControllerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ATControllerId"] = new SelectList(_context.ATController, "ControllerId", "UserId", shiftATController.ATControllerId);
            return View(shiftATController);
        }

        // GET: ShiftATControllers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftATController = await _context.ShiftATController
                .Include(s => s.ATController)
                .SingleOrDefaultAsync(m => m.ShiftATControllerId == id);
            if (shiftATController == null)
            {
                return NotFound();
            }

            return View(shiftATController);
        }

        // POST: ShiftATControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftATController = await _context.ShiftATController.SingleOrDefaultAsync(m => m.ShiftATControllerId == id);
            _context.ShiftATController.Remove(shiftATController);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShiftATControllerExists(int id)
        {
            return _context.ShiftATController.Any(e => e.ShiftATControllerId == id);
        }
    }
}
