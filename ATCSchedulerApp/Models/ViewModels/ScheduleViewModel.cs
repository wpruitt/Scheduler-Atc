using ATCScheduler.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<ATController> ATControllers { get; set; }

        public List<Position> Positions { get; set; }

        public List<Shift> Shifts { get; set; }

        public IEnumerable<SkillLevel> SkillLevels { get; set; }

        public IEnumerable<TimeOffRequest> TORs { get; set; }

        public ScheduleViewModel(ApplicationDbContext context)
        {
            Shifts = (from s in context.Shift.Include("RequiredPositions.Position")
                         select s).ToList();
            
        }
    }
}
