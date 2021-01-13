using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportNap : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Note { get; set; }


        public DateTime Date { get; set; }

        public static DailyReportNap Create(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date,
                                         string startTime,
                                         string endTime,
                                         string note,
                                         string createdBy)
        {
            return new DailyReportNap()
            {
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Date = date,
                Note = note,
                StartTime = startTime,
                EndTime = endTime,
                CreatedById = createdBy
            };
        }

        public static DailyReportNapViewModel Init(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date
                                         )
        {
            return new DailyReportNapViewModel()
            {
                ClassId = classId,
                Date = date,
                OrganizationId = organizationId,
                PersonId = personId
            };
        }

        public static List<DailyReportNapViewModel> Init(List<DailyReportNap> naps)
        {
            return naps.Select(x => new DailyReportNapViewModel()
            {
                ClassId = x.ClassId,
                Date = x.Date,
                EndTime = x.EndTime,
                Id = x.Id,
                Note = x.Note,
                OrganizationId = x.OrganizationId,
                PersonId = x.PersonId, 
                StartTime = x.StartTime }).ToList();
        }


    }
}
