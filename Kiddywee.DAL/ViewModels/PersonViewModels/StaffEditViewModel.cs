using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class StaffEditViewModel
    {
        public StaffEditViewModel()
        {
            Classes = new List<Class>();
            Schedule = new List<EnumWeeklyScheduleType>();
            Organizations = new List<Organization>();
            ClassId = new List<Guid>();
        }

        public Guid PersonId { get; set; }
        public List<Guid> ClassId { get; set; }
        public Guid OrganizationId { get; set; }

        public List<Class> Classes { get; set; }
        public List<Organization> Organizations { get; set; }

        public EnumStaffRoleType StaffRole { get; set; }

        public List<EnumWeeklyScheduleType> Schedule { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
        public int PhoneNumberDigitPin { get; set; }

        public DateTime? PromedicalFormDueDate { get; set; }

        public EnumEmploymentType EmploymentType { get; set; }

        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }

        public EnumSalaryType SalaryType { get; set; }

        public int Salary { get; set; }

        public DateTime? ChildAbuseCert { get; set; }
        public DateTime? FirstAidTraining { get; set; }

        public DateTime? Scr { get; set; }
        public DateTime? FingerPrinting { get; set; }

        public FileInfo MedicalInfo { get; set; }

    }
}
