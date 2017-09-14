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
    public class TimeOffRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeOffRequestsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TimeOffRequests
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeOffRequest.ToListAsync());
        }

        // GET: TimeOffRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffRequest = await _context.TimeOffRequest
                .SingleOrDefaultAsync(m => m.TimeOffRequestId == id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }

            return View(timeOffRequest);
        }

        // GET: TimeOffRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeOffRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOffRequestId,Start,End,Description,Status,ApproverNotes")] TimeOffRequest timeOffRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeOffRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(timeOffRequest);
        }

        // GET: TimeOffRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffRequest = await _context.TimeOffRequest.SingleOrDefaultAsync(m => m.TimeOffRequestId == id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }
            return View(timeOffRequest);
        }

        // POST: TimeOffRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeOffRequestId,Start,End,Description,Status,ApproverNotes")] TimeOffRequest timeOffRequest)
        {
            if (id != timeOffRequest.TimeOffRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOffRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOffRequestExists(timeOffRequest.TimeOffRequestId))
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
            return View(timeOffRequest);
        }

        // GET: TimeOffRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffRequest = await _context.TimeOffRequest
                .SingleOrDefaultAsync(m => m.TimeOffRequestId == id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }

            return View(timeOffRequest);
        }

        // POST: TimeOffRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeOffRequest = await _context.TimeOffRequest.SingleOrDefaultAsync(m => m.TimeOffRequestId == id);
            _context.TimeOffRequest.Remove(timeOffRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TimeOffRequestExists(int id)
        {
            return _context.TimeOffRequest.Any(e => e.TimeOffRequestId == id);
        }
    }
}
