using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportBathroom : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }

        public EnumBathroomDetailsType Type { get; set; }
        public DateTime Date { get; set; }

        public static DailyReportBathroom Create(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date,
                                         string time,
                                         EnumBathroomDetailsType type,
                                         string note,
                                         string createdBy)
        {
            return new DailyReportBathroom()
            {
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Date = date,
                Note = note,
                Time = time,
                Type = type,
                CreatedById = createdBy
            };
        }

        public static DailyReportBathroomViewModel Init(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date
                                         )
        {
            return new DailyReportBathroomViewModel()
            {
                ClassId = classId,
                Date = date,
                OrganizationId = organizationId,
                PersonId = personId
            };
        }

        public static List<DailyReportBathroomViewModel> Init(List<DailyReportBathroom> baths)
        {
            return baths.Select(x => new DailyReportBathroomViewModel()
            {
                ClassId = x.ClassId,
                Date = x.Date,
                Time = x.Time,
                Id = x.Id,
                Note = x.Note,
                OrganizationId = x.OrganizationId,
                PersonId = x.PersonId, 
                Type = x.Type }).ToList();
        }


    }
}
