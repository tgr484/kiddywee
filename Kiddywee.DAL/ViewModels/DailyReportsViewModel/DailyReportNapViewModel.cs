using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportNapViewModel
    {
        public Guid? Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Note { get; set; }

        public static DailyReportNapViewModel Create(DailyReportNap nap)
        {
            return new DailyReportNapViewModel()
            {
                ClassId = nap.ClassId,
                Id = nap.Id,
                Date = nap.Date,
                Note = nap.Note,
                OrganizationId = nap.OrganizationId,
                PersonId = nap.PersonId,
                EndTime = nap.EndTime,
                StartTime = nap.StartTime
            };
        }
    }
}
