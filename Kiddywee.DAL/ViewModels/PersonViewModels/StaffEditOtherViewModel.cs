using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class StaffEditOtherViewModel
    {
        public Guid PersonId { get; set; }
        public List<Class> Classes { get; set; }
        public List<Guid> InClasses { get; set; }
        public EnumStaffRoleType StaffRole { get; set; }

        public List<EnumWeeklyScheduleType> Schedule { get; set; }
        public DateTime? PromedicalFormDueDate { get; set; }

        public EnumEmploymentType EmploymentType { get; set; }


        public EnumSalaryType SalaryType { get; set; }

        public int Salary { get; set; }

        public DateTime? ChildAbuseCert { get; set; }
        public DateTime? FirstAidTraining { get; set; }

        public DateTime? Scr { get; set; }
        public DateTime? FingerPrinting { get; set; }

        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
    }
}
