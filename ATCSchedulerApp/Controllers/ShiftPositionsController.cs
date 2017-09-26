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
    public class ShiftPositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftPositionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ShiftPositions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShiftPosition.Include(s => s.Position).Include(s => s.Shift);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShiftPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftPosition = await _context.ShiftPosition
                .Include(s => s.Position)
                .Include(s => s.Shift)
                .SingleOrDefaultAsync(m => m.ShiftPositionId == id);
            if (shiftPosition == null)
            {
                return NotFound();
            }

            return View(shiftPosition);
        }

        // GET: ShiftPositions/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation");
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "Title");
            return View();
        }

        // POST: ShiftPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftPositionId,ShiftId,PositionId")] ShiftPosition shiftPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", shiftPosition.PositionId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "Title", shiftPosition.ShiftId);
            return View(shiftPosition);
        }

        // GET: ShiftPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftPosition = await _context.ShiftPosition.SingleOrDefaultAsync(m => m.ShiftPositionId == id);
            if (shiftPosition == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", shiftPosition.PositionId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "Title", shiftPosition.ShiftId);
            return View(shiftPosition);
        }

        // POST: ShiftPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftPositionId,ShiftId,PositionId")] ShiftPosition shiftPosition)
        {
            if (id != shiftPosition.ShiftPositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftPositionExists(shiftPosition.ShiftPositionId))
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
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", shiftPosition.PositionId);
            ViewData["ShiftId"] = new SelectList(_context.Shift, "ShiftId", "Title", shiftPosition.ShiftId);
            return View(shiftPosition);
        }

        // GET: ShiftPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftPosition = await _context.ShiftPosition
                .Include(s => s.Position)
                .Include(s => s.Shift)
                .SingleOrDefaultAsync(m => m.ShiftPositionId == id);
            if (shiftPosition == null)
            {
                return NotFound();
            }

            return View(shiftPosition);
        }

        // POST: ShiftPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftPosition = await _context.ShiftPosition.SingleOrDefaultAsync(m => m.ShiftPositionId == id);
            _context.ShiftPosition.Remove(shiftPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShiftPositionExists(int id)
        {
            return _context.ShiftPosition.Any(e => e.ShiftPositionId == id);
        }
    }
}
