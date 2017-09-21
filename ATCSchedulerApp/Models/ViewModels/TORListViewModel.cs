using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class TORListViewModel
    {
        public IEnumerable<TimeOffRequest> TORs { get; set; }
    }
}
