using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ATCScheduler.Models;
using ATCScheduler.Data;
using Microsoft.AspNetCore.Identity;
using ATCScheduler.Models.ViewModels;

namespace ATCScheduler.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var currentUserId = GetCurrentUserAsync().Result.Id;
            AppointmentListViewModel model = new AppointmentListViewModel
            {
                Appointments = await _context.Appointment.Where(a => a.UserId.Equals(currentUserId)).ToListAsync()
            };

            return View(model);
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .SingleOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/AADetails/5
        public async Task<IActionResult> AADetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .SingleOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // Post: Appointment/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("ApproverNote")]Appointment appointment)
        {
            ApplicationUser currentUser = await GetCurrentUserAsync();
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                appointment.Approver = currentUser;
                appointment.RequestStatus = Appointment.Status.Confirmed;
                _context.Update(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("AppointmentApproval");
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,Date,StartTime,EndTime,Medical,Description,ApproverNote")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.UserId = GetCurrentUserAsync().Result.Id;
                appointment.User = await GetCurrentUserAsync();
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.SingleOrDefaultAsync(m => m.AppointmentId == id && m.UserId == GetCurrentUserAsync().Result.Id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentId,Date,StartTime,EndTime,Medical,Description,ApproverNote,UserId,User")] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && appointment.UserId == GetCurrentUserAsync().Result.Id)
            {
                try
                {
                    appointment.RequestStatus = 0;
                    appointment.User = await GetCurrentUserAsync();
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentId))
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
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .SingleOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.SingleOrDefaultAsync(m => m.AppointmentId == id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.AppointmentId == id);
        }

        public IActionResult AppointmentApproval()
        {
            var currentUserId = GetCurrentUserAsync().Result.Id;
            AppointmentApprovalViewModel appointmentsToApprove = new AppointmentApprovalViewModel(_context, currentUserId);
            return View(appointmentsToApprove);
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
