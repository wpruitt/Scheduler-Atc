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
    public class PositionSkillLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionSkillLevelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PositionSkillLevels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PositionSkillLevel.Include(p => p.Position).Include(p => p.SkillLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PositionSkillLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionSkillLevel = await _context.PositionSkillLevel
                .Include(p => p.Position)
                .Include(p => p.SkillLevel)
                .SingleOrDefaultAsync(m => m.PositionSkillLevelId == id);
            if (positionSkillLevel == null)
            {
                return NotFound();
            }

            return View(positionSkillLevel);
        }

        // GET: PositionSkillLevels/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation");
            ViewData["SkillLevelId"] = new SelectList(_context.SkillLevel, "SkillLevelId", "SkillLevelId");
            return View();
        }

        // POST: PositionSkillLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PositionSkillLevelId,PositionId,SkillLevelId")] PositionSkillLevel positionSkillLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionSkillLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", positionSkillLevel.PositionId);
            ViewData["SkillLevelId"] = new SelectList(_context.SkillLevel, "SkillLevelId", "SkillLevelId", positionSkillLevel.SkillLevelId);
            return View(positionSkillLevel);
        }

        // GET: PositionSkillLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionSkillLevel = await _context.PositionSkillLevel.SingleOrDefaultAsync(m => m.PositionSkillLevelId == id);
            if (positionSkillLevel == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", positionSkillLevel.PositionId);
            ViewData["SkillLevelId"] = new SelectList(_context.SkillLevel, "SkillLevelId", "SkillLevelId", positionSkillLevel.SkillLevelId);
            return View(positionSkillLevel);
        }

        // POST: PositionSkillLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionSkillLevelId,PositionId,SkillLevelId")] PositionSkillLevel positionSkillLevel)
        {
            if (id != positionSkillLevel.PositionSkillLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionSkillLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionSkillLevelExists(positionSkillLevel.PositionSkillLevelId))
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
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "Abbreviation", positionSkillLevel.PositionId);
            ViewData["SkillLevelId"] = new SelectList(_context.SkillLevel, "SkillLevelId", "SkillLevelId", positionSkillLevel.SkillLevelId);
            return View(positionSkillLevel);
        }

        // GET: PositionSkillLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionSkillLevel = await _context.PositionSkillLevel
                .Include(p => p.Position)
                .Include(p => p.SkillLevel)
                .SingleOrDefaultAsync(m => m.PositionSkillLevelId == id);
            if (positionSkillLevel == null)
            {
                return NotFound();
            }

            return View(positionSkillLevel);
        }

        // POST: PositionSkillLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionSkillLevel = await _context.PositionSkillLevel.SingleOrDefaultAsync(m => m.PositionSkillLevelId == id);
            _context.PositionSkillLevel.Remove(positionSkillLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PositionSkillLevelExists(int id)
        {
            return _context.PositionSkillLevel.Any(e => e.PositionSkillLevelId == id);
        }
    }
}
