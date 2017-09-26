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
    public class ShiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Shifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shift.ToListAsync());
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // GET: Shifts/Create
        public IActionResult Create()
        {
            CreateShiftViewModel model = new CreateShiftViewModel();
            var positions = _context.Position.Select(p => new
            {
                PositionId = p.PositionId,
                PositionsName = p.Title
            }).ToList();

            model.ListOfPositions = new List<SelectListItem>();
            foreach (var position in positions)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = position.PositionsName,
                    Value = position.PositionId.ToString()
                };
                model.ListOfPositions.Add(selectList);
            }
            model.Positions = model.ListOfPositions;
            return View(model);
        }

        // POST: Shifts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateShiftViewModel model)
        {
            ModelState.Remove("Shift.RequiredPositions");
            if (ModelState.IsValid)
            {
                ShiftPosition shiftpos = new ShiftPosition();
                
                foreach (var p in model.SelectedPostions)
                {
                    var position = await (from po in _context.Position
                                          where p == po.PositionId.ToString()
                                          select po).ToListAsync();
                    shiftpos.ShiftId = model.Shift.ShiftId;
                    shiftpos.PositionId = position[0].PositionId;
                    Position pos = new Position()
                    {
                        PositionId = position[0].PositionId,
                        Abbreviation = position[0].Abbreviation,
                        Title = position[0].Title                        
                    };
                    _context.ShiftPosition.Add(shiftpos);
                }
                //var reqshifts = from rs in _context.ShiftPosition 
            }
            return View(model);
        }

        // GET: Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }
            return View(shift);
        }

        // POST: Shifts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftId,Title,StartTime,EndTime,Status,ATControllerId")] Shift shift)
        {
            if (id != shift.ShiftId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftExists(shift.ShiftId))
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
            return View(shift);
        }

        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .SingleOrDefaultAsync(m => m.ShiftId == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shift = await _context.Shift.SingleOrDefaultAsync(m => m.ShiftId == id);
            _context.Shift.Remove(shift);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ShiftExists(int id)
        {
            return _context.Shift.Any(e => e.ShiftId == id);
        }
    }
}
