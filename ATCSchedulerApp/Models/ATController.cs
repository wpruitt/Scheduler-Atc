using ATCScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class ATController
    {
        [Key]
        public int ControllerId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int SkillLevelId { get; set; }

        public SkillLevel SkillLevel { get; set; }

        public List<Position> QualifiedPositions { get; set; }

        public bool FlyingStatus { get; set; }
    }
}
