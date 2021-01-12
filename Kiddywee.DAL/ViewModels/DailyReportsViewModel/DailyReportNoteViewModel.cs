using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportNoteViewModel
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Note { get; set; }
    }
}
