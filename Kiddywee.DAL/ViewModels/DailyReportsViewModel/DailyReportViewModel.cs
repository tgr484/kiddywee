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
            Reports = new Dictionary<EnumDailyReportType, string>();
        }

        public Guid PersonId { get; set; }
        public string PersonFullName { get; set; }
        public Guid ClassId { get; set; }
        public List<EnumDailyReportType> ReportTypes { get; set; }
        public Dictionary<EnumDailyReportType, string> Reports { get; set; }

        public static DailyReportViewModel Create(Guid personId, Guid classId, string personFullName, List<int> reportTypes, List<DailyReport> reports)
        {
            Dictionary<EnumDailyReportType, string> resultReports = new Dictionary<EnumDailyReportType, string>();
            foreach(var item in reports)
            {
                resultReports.Add((EnumDailyReportType)item.Type, item.Report);
            }
            return new DailyReportViewModel()
            {
                ClassId = classId,
                PersonId = personId,
                PersonFullName = personFullName,
                Reports = resultReports,
                ReportTypes = reportTypes?.Cast<EnumDailyReportType>().ToList()
            };
        }
    }
}
