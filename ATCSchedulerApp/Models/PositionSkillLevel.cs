using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class PositionSkillLevel
    {
        [Key]
        public int PositionSkillLevelId { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public int SkillLevelId { get; set; }

        public Position Position { get; set; }

        public SkillLevel SkillLevel { get; set; }
    }
}
