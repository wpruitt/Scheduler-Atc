using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Models;
using ATCScheduler.Data;

namespace ATCScheduler.Controllers
{
    public class SkillLevelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillLevelsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SkillLevels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkillLevel.ToListAsync());
        }

        // GET: SkillLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillLevel = await _context.SkillLevel
                .SingleOrDefaultAsync(m => m.SkillLevelId == id);
            if (skillLevel == null)
            {
                return NotFound();
            }

            return View(skillLevel);
        }

        // GET: SkillLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillLevelId,Title")] SkillLevel skillLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(skillLevel);
        }

        // GET: SkillLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillLevel = await _context.SkillLevel.SingleOrDefaultAsync(m => m.SkillLevelId == id);
            if (skillLevel == null)
            {
                return NotFound();
            }
            return View(skillLevel);
        }

        // POST: SkillLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillLevelId,Title")] SkillLevel skillLevel)
        {
            if (id != skillLevel.SkillLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillLevelExists(skillLevel.SkillLevelId))
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
            return View(skillLevel);
        }

        // GET: SkillLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillLevel = await _context.SkillLevel
                .SingleOrDefaultAsync(m => m.SkillLevelId == id);
            if (skillLevel == null)
            {
                return NotFound();
            }

            return View(skillLevel);
        }

        // POST: SkillLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillLevel = await _context.SkillLevel.SingleOrDefaultAsync(m => m.SkillLevelId == id);
            _context.SkillLevel.Remove(skillLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SkillLevelExists(int id)
        {
            return _context.SkillLevel.Any(e => e.SkillLevelId == id);
        }
    }
}
