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

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public string AttendanceCssClass
        {
            get
            {
                if (CheckInTime.HasValue && CheckOutTime.HasValue)
                {
                    return "person-was";
                }
                return (CheckInTime.HasValue && !CheckOutTime.HasValue) ? "person-in" : "person-out";
            }
        }
    }
}
