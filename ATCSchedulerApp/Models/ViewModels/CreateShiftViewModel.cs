using ATCScheduler.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class CreateShiftViewModel
    {
        public Shift Shift { get; set; }

        public IEnumerable<string> SelectedPostions { get; set; }

        public IEnumerable<SelectListItem> Positions { get; set; }

        public List<SelectListItem> ListOfPositions { get; set;}

        //public CreateShiftViewModel(ApplicationDbContext context)
        //{
            //List<SelectListItem> ListOfPositions = new List<SelectListItem>();
            //var positions = context.Position.Select(p => new {
            //    PositionId = p.PositionId,
            //    PositionsName = p.Title
            //}).ToList();


            //foreach (var position in positions)
            //{
            //    SelectListItem selectList = new SelectListItem()
            //    {
            //        Text = position.PositionsName,
            //        Value = position.PositionId.ToString()
            //    };
            //    ListOfPositions.Add(selectList);
            //    Positions = ListOfPositions;
            //}
        //}
    }
}
