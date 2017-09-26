using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class ShiftATController
    {
        [Key]
        public int ShiftATControllerId { get; set; }

        [Required]
        public int ShfitId { get; set; }

        [Required]
        public int ATControllerId { get; set; }

        public Shift Shift { get; set; }

        public ATController ATController {get; set;}

    }
}
