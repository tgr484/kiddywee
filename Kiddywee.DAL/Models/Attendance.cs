using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Attendance : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime Date { get; set; }

        public EnumAttendanceType AttendanceType { get; set; }

        public Guid ClassId { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
