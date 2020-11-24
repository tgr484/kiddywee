using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Person
    {
        //Add CreatedById
        public Person()
        {
            Contacts = new List<PersonToContact>();
            PersonToClasses = new List<PersonToClass>();
            Attendances = new List<Attendance>();
            MedicalInfos = new List<MedicalInfo>();
            Immunizations = new List<Immunization>();
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? ChildInfoId { get; set; }

        public ChildInfo ChildInfo { get; set; }

        public List<PersonToContact> Contacts { get; set; }

        public Guid? OrganizationId { get; set; } 

        public Organization Orgnization { get; set; }
        public Guid? StaffInfoId { get; set; }
        public StaffInfo StaffInfo { get; set; }

        public List<Attendance> Attendances { get; set; }
        public List<PersonToClass> PersonToClasses { get; set; }

        public List<MedicalInfo> MedicalInfos { get; set; }

        public List<Immunization> Immunizations { get; set; }

        public string FullName { get {return $"{FirstName} {LastName}";}}


        public static Person Create(string firstName, string lastName)
        {
            return new Person() { FirstName = firstName, LastName = lastName };
        }

        public static Person Create(ChildCreateViewModel model, Guid organizationId)
        {
            return new Person() {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                OrganizationId = organizationId
            };
        }
        public static Person Create(StaffCreateViewModel model, Guid organizationId)
        {
            return new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                OrganizationId = organizationId,
            };
        }
        public static List<PersonViewModel> Init(List<Person> people)
        {
            var result = new List<PersonViewModel>();
            foreach (var item in people)
            {
                var classId = item.PersonToClasses.FirstOrDefault(x => x.IsActive)?.ClassId;

                var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                var attendance = item.Attendances.FirstOrDefault(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate);

                DateTime? checkInTime = null;
                DateTime? checkOutTime = null;
                if (attendance != null)
                {
                    checkInTime = attendance.InDate;
                    checkOutTime = attendance.OutDate;
                }


                var viewModel = new PersonViewModel()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    DateOfBirth = item.DateOfBirth,
                    StaffInfo = item.StaffInfo,
                    ChildInfo = item.ChildInfo,
                    ClassId = classId,
                    CheckInTime = checkInTime,
                    CheckOutTime = checkOutTime
                };
                result.Add(viewModel);
            } 
            return result;
        }        

        public void Update(ChildEditViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth;
            ChildInfo.Address = model.Address;
            ChildInfo.Allergies = model.Allergies;
            ChildInfo.AllergiesNotes = model.AllergiesNotes;
            ChildInfo.DailySchedule = model.DailySchedule?.Select(x => Convert.ToInt32(x)).ToList();
            ChildInfo.WeaklySchedule = model.WeaklySchedule?.Select(x => Convert.ToInt32(x)).ToList();
            ChildInfo.PipeLineType = model.PipeLineType;
            ChildInfo.NextMedical = model.NextMedical;
            ChildInfo.Notes = model.Notes;             
        }

        public void Update(StaffEditViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth;
            StaffInfo.CheckInTime = model.CheckInTime;
            StaffInfo.CheckOutTime = model.CheckOutTime;
            StaffInfo.ChildAbuseCert = model.ChildAbuseCert;
            StaffInfo.EmploymentType = model.EmploymentType;
            StaffInfo.FingerPrinting = model.FingerPrinting;
            StaffInfo.FirstAidTraining = model.FirstAidTraining;
            StaffInfo.PhoneNumber = model.PhoneNumber;
            StaffInfo.PhoneNumberDigitPin = model.PhoneNumberDigitPin;
            StaffInfo.PromedicalFormDueDate = model.PromedicalFormDueDate;
            StaffInfo.Salary = model.Salary;
            StaffInfo.SalaryType = model.SalaryType;
            StaffInfo.Schedule = model.Schedule?.Select(x => Convert.ToInt32(x)).ToList();
            StaffInfo.Scr = model.Scr;
            StaffInfo.StaffRole = model.StaffRole;
        }
    }
}
