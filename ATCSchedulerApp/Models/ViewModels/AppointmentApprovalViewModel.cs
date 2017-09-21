using ATCScheduler.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class AppointmentApprovalViewModel
    {
        public IEnumerable<Appointment> PendingAppointments { get; set; }

        public IEnumerable<Appointment> ApprovedAppointments { get; set; }

        public IEnumerable<Appointment> ConfirmedAppointments { get; set; }

        public AppointmentApprovalViewModel(ApplicationDbContext context, string UserId)
        {
            PendingAppointments = (from pa in context.Appointment
                                    where pa.RequestStatus == 0
                                    select pa).Include("User");
            ApprovedAppointments = (from aa in context.Appointment
                                    where aa.RequestStatus == Appointment.Status.Approved
                                    select aa).Include("User");
            ConfirmedAppointments = (from ca in context.Appointment
                                    where ca.RequestStatus == Appointment.Status.Confirmed
                                    select ca).Include("User");
        }
    }
}
