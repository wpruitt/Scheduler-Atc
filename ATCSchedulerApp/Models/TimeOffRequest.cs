using ATCScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class TimeOffRequest
    {
        [Key]
        public int TimeOffRequestId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date/Time")]
        public DateTime Start { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date/Time")]
        public DateTime End { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public virtual ApplicationUser Approver { get; set; }

        public string ApproverNotes { get; set; }
    }
}
