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

        public static Attendance Create(
            Guid personId,
            Guid classId,
            Guid? organizationId,
            EnumAttendanceType attendanceType,
            string createdById,
            DateTime? date = null)
        {
            date = date.HasValue ? date : DateTime.UtcNow; 
            return new Attendance()
                {
                    PersonId = personId,
                    ClassId = classId,
                    OrganizationId = organizationId.Value,
                    AttendanceType = attendanceType,
                    CreatedById = createdById,
                    Date = date.Value
                };
        }

    }
}
