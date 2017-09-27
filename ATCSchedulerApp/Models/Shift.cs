using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class Shift
    {
        [Key]
        public int ShiftId { set; get; }
        
        [Required]
        public string Title { get; set; }

        public int PositionId { get; set; }

        [Required]
        public ICollection<ShiftPosition> RequiredPositions { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [DefaultValue("Uncovered")]
        public Status ShiftStatus { get; set; }

        public int ATCControllerId { get; set; }

        public ICollection<ATController> ATCControllers { get; set; }

        public enum Status
        {
            Uncovered,
            Covered
        }
    }
}
