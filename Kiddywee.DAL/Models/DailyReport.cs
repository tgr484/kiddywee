using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReport : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public string Report { get; set; }
        public string Notes { get; set; }

        public EnumDailyReportType Type { get; set; }

        public DateTime Date { get; set; }

        public static DailyReport Create(Guid personId, 
                                         Guid classId, 
                                         Guid organizationId, 
                                         EnumDailyReportType type, 
                                         DateTime date, 
                                         string report, 
                                         string notes,
                                         string createdBy)
        {
            return new DailyReport() 
            { 
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Type = type,
                Date = date,
                Report = report,
                Notes = notes,
                CreatedById = createdBy
            };
        }
    }
}
