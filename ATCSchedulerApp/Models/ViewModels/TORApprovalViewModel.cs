using ATCScheduler.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class TORApprovalViewModel
    {
        public IEnumerable<TimeOffRequest> PendingTORs { get; set; }

        public IEnumerable<TimeOffRequest> ApprovedTORs { get; set; }

        public IEnumerable<TimeOffRequest> ConfirmedTORs { get; set; }

        public IEnumerable<TimeOffRequest> DeniedTORs { get; set; }

        public TORApprovalViewModel(ApplicationDbContext context, string UserId)
        {
            PendingTORs = (from pt in context.TimeOffRequest
                           where pt.TORStatus == TimeOffRequest.Status.Pending
                           select pt).Include("User");
            ApprovedTORs = (from at in context.TimeOffRequest
                            where at.TORStatus == TimeOffRequest.Status.Approved
                            select at).Include("User");
            ConfirmedTORs = (from ct in context.TimeOffRequest
                            where ct.TORStatus == TimeOffRequest.Status.Confirmed
                            select ct).Include("User");
            DeniedTORs = (from dt in context.TimeOffRequest
                            where dt.TORStatus == TimeOffRequest.Status.Denied
                            select dt).Include("User");
        }
    }
}
