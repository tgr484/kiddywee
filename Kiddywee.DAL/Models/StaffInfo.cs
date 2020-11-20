using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class StaffInfo : BaseEntity
    {
        public StaffInfo()
        {
            StaffTrainings = new List<StaffTraining>();
            Schedule = new List<int>();
        }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public EnumStaffRoleType StaffRole { get; set; }

        public List<int> Schedule { get; set; } 

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

        public static StaffInfo Create(StaffCreateViewModel model, string createdBy)
        {
            return new StaffInfo()
            {
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,
                ChildAbuseCert = model.ChildAbuseCert,
                CreatedById = createdBy,
                EmploymentType = model.EmploymentType,
                FingerPrinting = model.FingerPrinting,
                FirstAidTraining = model.FirstAidTraining,
                OrganizationId = model.OrganizationId,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberDigitPin = model.PhoneNumberDigitPin,
                PromedicalFormDueDate = model.PromedicalFormDueDate,
                Salary = model.Salary,
                SalaryType = model.SalaryType,
                Schedule = model.Schedule?.Select(x => Convert.ToInt32(x)).ToList(),
                Scr = model.Scr,
                StaffRole = model.StaffRole,        

            };
        }

        public static StaffEditViewModel Init(Person person, List<Class> classes)
        {
            var si = person.StaffInfo != null ? person.StaffInfo : new StaffInfo();

            var classId = person.PersonToClasses.FirstOrDefault(x => x.PersonId == person.Id && x.IsActive == true)
                != null ? person.PersonToClasses.FirstOrDefault(x => x.PersonId == person.Id && x.IsActive == true).ClassId
                        : new Guid();
            return new StaffEditViewModel()
            {
                PersonId = person.Id,
                Classes = classes,               
                ClassId = classId,
                Schedule = si.Schedule?.Cast<EnumWeeklyScheduleType>().ToList(),
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                LastName = person.LastName,
                CheckInTime = si.CheckInTime,
                CheckOutTime = si.CheckOutTime,
                ChildAbuseCert = si.ChildAbuseCert,
                EmploymentType = si.EmploymentType,
                FingerPrinting = si.FingerPrinting,
                FirstAidTraining = si.FirstAidTraining,
                PhoneNumber = si.PhoneNumber,
                PhoneNumberDigitPin = si.PhoneNumberDigitPin,
                PromedicalFormDueDate = si.PromedicalFormDueDate,
                Salary = si.Salary,
                SalaryType = si.SalaryType,
                Scr = si.Scr,
                StaffRole = si.StaffRole
                
            };
        }
    }
}
