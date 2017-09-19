using ATCScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class TimeOffRequest
    {
        [Key]
        public int TimeOffRequestId { get; set; }

        public string userId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public string Description { get; set; }

        [DefaultValue(0)]
        [Display(Name = "Status")]
        public Status TORStatus { get; set; }

        public virtual ApplicationUser Approver { get; set; }

        public string ApproverNotes { get; set; }

        public enum Status
        {
            Pending,
            Approved,
            Denied,
            Confirmed
        }
    }
}
