using ATCScheduler.Data;
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

        public AppointmentApprovalViewModel(ApplicationDbContext context, string user)
        {
            PendingAppointments = from pa in context.Appointment
                                    where pa.RequestStatus == 0
                                    join u in context.ApplicationUser on pa.UserId equals u.Id into pau
                                    select pa;
            ApprovedAppointments = from aa in context.Appointment
                                    where aa.RequestStatus == Appointment.Status.Approved
                                    select aa;
            ConfirmedAppointments = from ca in context.Appointment
                                    where ca.RequestStatus == Appointment.Status.Confirmed
                                    select ca;
        }
    }
}
