using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.AttendanceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Attendance : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime InDate { get; set; }

        public DateTime? OutDate { get; set; }

        //If null - checkout to school
        public Guid? ClassId { get; set; }

        public Guid OrganizationId { get; set; }

        public static Attendance Create(
            Guid personId,
            Guid? classId,
            Guid? organizationId,
            string createdById
            )
        {
            return new Attendance()
                {
                    PersonId = personId,
                    ClassId = classId,
                    OrganizationId = organizationId.Value,
                    InDate = DateTime.UtcNow,
                    CreatedById = createdById,
                };
        }

        public static List<AttendanceViewModel> Init(List<Attendance> attendancesForToday)
        {
            var result = new List<AttendanceViewModel>();

            var grouppedByPersonAttendanceList = attendancesForToday.GroupBy(x => x.PersonId);
            foreach (var item in attendancesForToday)
            {
                var attendance = new AttendanceViewModel()
                {
                    AttendanceId = item.Id,
                    Name = item.Person.FullName,
                    InDate = item.InDate,
                    OutDate = item.OutDate
                };
                result.Add(attendance);
            }
            return result;
        }
    }
}
