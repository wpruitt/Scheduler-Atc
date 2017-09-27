using ATCScheduler.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class CreatePositionViewModel
    {
        public Position Position { get; set; }

        public IEnumerable<string> SelectedSkillLevels { get; set; }

        public IEnumerable<SelectListItem> SkillLevels { get; set; }

        public List<SelectListItem> ListOfSkillLevels { get; set; }

        //public CreatePositionViewModel(ApplicationDbContext context)
        //{
        //    var skilllevels = context.SkillLevel.Select(s => new
        //    {
        //        SkillLevelId = s.SkillLevelId,
        //        SkillLevelName = s.Title
        //    }).ToList();
        //    ListOfSkillLevels = new MultiSelectList(skilllevels, "SkillLevelId", "SkillLevelName");
        //}
    }
}
