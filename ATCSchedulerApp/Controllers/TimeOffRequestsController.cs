using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Data;
using ATCScheduler.Models;
using Microsoft.AspNetCore.Identity;
using ATCScheduler.Models.ViewModels;

namespace ATCScheduler.Controllers
{
    public class TimeOffRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TimeOffRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TimeOffRequests1
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetCurrentUserAsync().Result.Id;
            TORListViewModel model = new TORListViewModel
            {
                TORs = await _context.TimeOffRequest.Where(t => t.UserId.Equals(currentUserId)).ToListAsync()
            };
            return View(model);
        }

        // GET: TimeOffRequests1/Details/5
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

        //GET: TimeOffRequests/Approve/{id}
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TOR = await _context.TimeOffRequest.Include(t => t.User)
                .SingleOrDefaultAsync(t => t.TimeOffRequestId == id);

            if (TOR == null)
            {
                return NotFound();
            }

            return View(TOR);
        }

        // Post: TimeOffRequest/Approve/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("TimeOffRequestId, UserId, User, StartDate, StartTime, EndDate, EndTime, TORStatus, Approver, ApproverNotes")]TimeOffRequest TOR)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();
            if (ModelState.IsValid)
            {
                TOR.Approver = currentUser;
                TOR.TORStatus = TimeOffRequest.Status.Approved;
                _context.Update(TOR);
                await _context.SaveChangesAsync();
                return RedirectToAction("TORApproval");
            }
            return View(TOR);
        }

        // GET: TimeOffRequests1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeOffRequests1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOffRequestId,StartDate,StartTime,EndDate,EndTime,Description,Status,ApproverNotes")] TimeOffRequest timeOffRequest)
        {
            if (ModelState.IsValid)
            {
                timeOffRequest.UserId = GetCurrentUserAsync().Result.Id;
                timeOffRequest.User = await GetCurrentUserAsync();
                _context.Add(timeOffRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(timeOffRequest);
        }

        // GET: TimeOffRequests1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOffRequest = await _context.TimeOffRequest.Include(t => t.User).SingleOrDefaultAsync(m => m.TimeOffRequestId == id && m.UserId == GetCurrentUserAsync().Result.Id);
            if (timeOffRequest == null)
            {
                return NotFound();
            }
            return View(timeOffRequest);
        }

        // POST: TimeOffRequests1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeOffRequestId,User,StartDate,StartTime,EndDate,EndTime,Description,Status,ApproverNotes")] TimeOffRequest timeOffRequest)
        {
            if (id != timeOffRequest.TimeOffRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && timeOffRequest.UserId == GetCurrentUserAsync().Result.Id)
            {
                try
                {
                    timeOffRequest.TORStatus = 0;
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

        // GET: TimeOffRequests1/Delete/5
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

        // POST: TimeOffRequests1/Delete/5
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

        public IActionResult TORApproval()
        {
            var currentUserId = GetCurrentUserAsync().Result.Id;
            TORApprovalViewModel TORsToApprove = new TORApprovalViewModel(_context, currentUserId);
            return View(TORsToApprove);

        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
