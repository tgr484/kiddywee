using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportViewModel
    {
        public DailyReportViewModel()
        {
            Notes = new List<DailyReportNoteViewModel>();
        }

        public Guid PersonId { get; set; }
        public string PersonFullName { get; set; }
        public Guid ClassId { get; set; }

        public Guid OrganizationId { get; set; }

        public List<EnumDailyReportType> ReportTypes { get; set; }
        public List<DailyReportNoteViewModel> Notes { get; set; }

        public static DailyReportViewModel Create(Guid personId, Guid classId, Guid organizationId,string personFullName, List<int> reportTypes, List<DailyReportNote> reports)
        {
            var notes = reports?.Select(x => new DailyReportNoteViewModel() { ClassId = x.ClassId, Date = x.Date, Id = x.Id, Note = x.Note, OrganizationId = x.OrganizationId, PersonId = x.PersonId }).ToList();
            return new DailyReportViewModel()
            {
                ClassId = classId,
                PersonId = personId,
                PersonFullName = personFullName,
                ReportTypes = reportTypes?.Cast<EnumDailyReportType>().ToList(),
                OrganizationId = organizationId,
                Notes = notes
            };
        }
    }
}
