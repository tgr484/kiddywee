using Kiddywee.DAL.Enum;
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
            ReportTypes = new List<EnumDailyReportType>();
        }

        public Guid PersonId { get; set; }
        public string PersonFullName { get; set; }
        public Guid ClassId { get; set; }
        public List<EnumDailyReportType> ReportTypes { get; set; }

        public static DailyReportViewModel Create(Guid personId, Guid classId, string personFullName, List<int> reportTypes)
        {
            return new DailyReportViewModel() 
            { 
                ClassId = classId,
                PersonId = personId,
                PersonFullName = personFullName,
                ReportTypes = reportTypes?.Cast<EnumDailyReportType>().ToList()
            };
        }
    }
}
