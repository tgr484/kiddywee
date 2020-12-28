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

        public Guid ClassId { get; set; }

        public Guid OrganizationId { get; set; }

        public string Notes { get; set; }

        //public Dictionary<EnumDailyReportType, string> Report { get; set; }
    }
}
