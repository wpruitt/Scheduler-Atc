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
    public class ATControllersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ATControllersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ATControllers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ATController.Include(a => a.SkillLevel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ATControllers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aTController = await _context.ATController
                .Include(a => a.SkillLevel)
                .SingleOrDefaultAsync(m => m.ControllerId == id);
            if (aTController == null)
            {
                return NotFound();
            }

            return View(aTController);
        }

        // GET: ATControllers/Create
        public IActionResult Create()
        {
            ViewData["SkillLevelId"] = new SelectList(_context.Set<SkillLevel>(), "SkillLevelId", "SkillLevelId");
            return View();
        }

        // POST: ATControllers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ControllerId,SkillLevelId,FlyingStatus")] ATController aTController)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aTController);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SkillLevelId"] = new SelectList(_context.Set<SkillLevel>(), "SkillLevelId", "SkillLevelId", aTController.SkillLevelId);
            return View(aTController);
        }

        // GET: ATControllers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aTController = await _context.ATController.SingleOrDefaultAsync(m => m.ControllerId == id);
            if (aTController == null)
            {
                return NotFound();
            }
            ViewData["SkillLevelId"] = new SelectList(_context.Set<SkillLevel>(), "SkillLevelId", "SkillLevelId", aTController.SkillLevelId);
            return View(aTController);
        }

        // POST: ATControllers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ControllerId,SkillLevelId,FlyingStatus")] ATController aTController)
        {
            if (id != aTController.ControllerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aTController);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ATControllerExists(aTController.ControllerId))
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
            ViewData["SkillLevelId"] = new SelectList(_context.Set<SkillLevel>(), "SkillLevelId", "SkillLevelId", aTController.SkillLevelId);
            return View(aTController);
        }

        // GET: ATControllers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aTController = await _context.ATController
                .Include(a => a.SkillLevel)
                .SingleOrDefaultAsync(m => m.ControllerId == id);
            if (aTController == null)
            {
                return NotFound();
            }

            return View(aTController);
        }

        // POST: ATControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aTController = await _context.ATController.SingleOrDefaultAsync(m => m.ControllerId == id);
            _context.ATController.Remove(aTController);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ATControllerExists(int id)
        {
            return _context.ATController.Any(e => e.ControllerId == id);
        }
    }
}
