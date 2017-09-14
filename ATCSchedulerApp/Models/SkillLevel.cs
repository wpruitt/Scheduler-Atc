using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models
{
    public class SkillLevel
    {
        [Key]
        public int SkillLevelId { get; set; }

        public string Title { get; set; }
    }
}
