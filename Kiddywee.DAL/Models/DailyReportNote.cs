using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportNote : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public static DailyReportNote Create(Guid personId, 
                                         Guid classId, 
                                         Guid organizationId, 
                                         DateTime date, 
                                         string note,
                                         string createdBy)
        {
            return new DailyReportNote() 
            { 
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Date = date,
                Note = note,
                CreatedById = createdBy
            };
        }

        public static DailyReportNoteViewModel Init(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date
                                         )
        {
            return new DailyReportNoteViewModel()
            {
                ClassId = classId,
                Date = date,
                OrganizationId = organizationId,
                PersonId = personId
            };
        }
    }
}
