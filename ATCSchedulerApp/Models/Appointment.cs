using ATCScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [DefaultValue(false)]
        public bool Medical { get; set; }

        public string Description { get; set; }

        public virtual ApplicationUser Approver { get; set; }

        public string ApproverNote { get; set; }
    }
}
