using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Models;
using ATCScheduler.Data;
using ATCScheduler.Models.ViewModels;

namespace ATCScheduler.Controllers
{
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Position.ToListAsync());
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .SingleOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            CreatePositionViewModel model = new CreatePositionViewModel();
            var skilllevels = _context.SkillLevel.Select(s => new
            {
                SkillLevelId = s.SkillLevelId,
                SkillLevelName = s.Title
            }).ToList();
            model.ListOfSkillLevels = new List<SelectListItem>();
            foreach (var skilllevel in skilllevels)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = skilllevel.SkillLevelName,
                    Value = skilllevel.SkillLevelId.ToString()
                };
                model.ListOfSkillLevels.Add(selectList);
            }
            model.SkillLevels = model.ListOfSkillLevels;
            return View(model);
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePositionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var s in model.SelectedSkillLevels)
                {
                    var skilllevel = await (from sl in _context.SkillLevel
                                     where s == sl.SkillLevelId.ToString()
                                     select sl).ToListAsync();
                    //model.Position.SkillLevelId = skilllevel[0].SkillLevelId;
                }

                _context.Add(model.Position);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position.SingleOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PositionId,Title,Abbreviation")] Position position)
        {
            if (id != position.PositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(position);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.PositionId))
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
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _context.Position
                .SingleOrDefaultAsync(m => m.PositionId == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _context.Position.SingleOrDefaultAsync(m => m.PositionId == id);
            _context.Position.Remove(position);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PositionExists(int id)
        {
            return _context.Position.Any(e => e.PositionId == id);
        }
    }
}
