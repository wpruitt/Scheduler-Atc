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

        public string userId { get; set; }
        
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

        [DefaultValue(0)]
        public Status RequestStatus { get; set; }

        public virtual ApplicationUser Approver { get; set; }

        public string ApproverNote { get; set; }

        public enum Status
        {
            Pending,
            Approved,
            Confirmed
        }
    }
}
