using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class ShiftPosition
    {
        [Key]
        public int ShiftPositionId { get; set; }

        [Required]
        public int ShiftId { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Shift Shift { get; set; }

        public Position Position { get; set; }
    }
}
