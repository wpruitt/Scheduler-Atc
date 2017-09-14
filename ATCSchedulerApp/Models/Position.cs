using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        public ICollection<SkillLevel> SkillLevels { get; set; }
    }
}
