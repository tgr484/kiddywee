using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class StaffInfo : BaseEntity
    {
        public StaffInfo()
        {
            StaffTrainings = new List<StaffTraining>();
        }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public Guid PersonId { get; set; }

        public EnumStaffRoleType StaffRole { get; set; }

        public List<int> Schedule { get; set; }

        public Guid? MedicalInfoId { get; set; }
        public MedicalInfo MedicalInfo { get; set; }

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

        public List<StaffTraining> StaffTrainings { get; set; }
    }
}
