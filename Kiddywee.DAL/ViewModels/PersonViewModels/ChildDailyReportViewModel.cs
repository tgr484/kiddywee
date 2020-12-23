using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildDailyReportViewModel
    {
        public Guid Id { get; set; }
        public string ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => this.FirstName + " " + this.LastName;

    }
}
