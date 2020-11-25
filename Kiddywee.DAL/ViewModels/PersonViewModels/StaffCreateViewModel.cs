using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class StaffCreateViewModel
    {
        public StaffCreateViewModel()
        {
            Classes = new List<Class>();
            Organizations = new List<Organization>();
            Schedule = new List<EnumWeeklyScheduleType>();
            ClassId = new List<Guid>();
        }

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

        public IFormFile MedicalInfo { get; set; }

    }
}
