﻿using Kiddywee.DAL.Enum;
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
            PersonToChildren = new List<PersonToChild>();
            Attendances = new List<Attendance>();
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string CreatedById { get; set; }

        public Guid? ChildInfoId { get; set; }

        public ChildInfo ChildInfo { get; set; }

        public List<PersonToContact> Contacts { get; set; }

        public Guid? OrganizationId { get; set; }

        public Organization Orgnization { get; set; }
        public Guid? StaffInfoId { get; set; }
        public StaffInfo StaffInfo { get; set; }

        public List<Attendance> Attendances { get; set; }
        public List<PersonToClass> PersonToClasses { get; set; }
        public List<PersonToChild> PersonToChildren { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public byte[] ProfileImage { get; set; }

        public static Person Create(string firstName, string lastName)
        {
            return new Person() { FirstName = firstName, LastName = lastName };
        }

        public static Person Create(ChildCreateViewModel model, Guid organizationId)
        {
            return new Person()
            {
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
        public static List<PersonViewModel> Init(List<Person> people, Guid? classId)
        {
            var result = new List<PersonViewModel>();
            foreach (var item in people)
            {
                //var classId = item.PersonToClasses.FirstOrDefault(x => x.IsActive)?.ClassId;

                var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
                var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
                Attendance attendance = null;
                if (classId.HasValue)
                {
                    attendance = item.Attendances.FirstOrDefault(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate && x.ClassId == classId.Value);
                }
                else
                {
                    attendance = item.Attendances.FirstOrDefault(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate && x.ClassId == null);
                }

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
                    ClassId = classId.HasValue ? classId.Value.ToString() : "0",
                    CheckInTime = checkInTime,
                    CheckOutTime = checkOutTime
                };
                result.Add(viewModel);
            }
            return result;
        }

        public static List<ChildDailyReportViewModel> InitDailyReport(List<Person> people, Guid? classId)
        {
            List<ChildDailyReportViewModel> result = new List<ChildDailyReportViewModel>();

            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
            Attendance attendance = null;
            

            foreach (var item in people)
            {
                if (classId.HasValue)
                {
                    attendance = item.Attendances.FirstOrDefault(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate && x.ClassId == classId.Value);
                }
                else
                {
                    attendance = item.Attendances.FirstOrDefault(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate && x.ClassId == null);
                }

                DateTime? checkInTime = null;
                DateTime? checkOutTime = null;
                if (attendance != null)
                {
                    checkInTime = attendance.InDate;
                    checkOutTime = attendance.OutDate;
                }

                result.Add(new ChildDailyReportViewModel()
                {
                    ClassId = classId.HasValue ? classId.Value.ToString() : "0",
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    CheckInTime = checkInTime,
                    CheckOutTime = checkOutTime
                });
            }
            return result;
        }

        public void Update(ChildEditGeneralViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth;
            ChildInfo.Address = model.Address;
        }
        public void Update(ChildEditMedicalViewModel model)
        {
            ChildInfo.Allergies = model.Allergies;
            ChildInfo.AllergiesNotes = model.AllergiesNotes;
            ChildInfo.NextMedical = model.NextMedical;

        }

        public void Update(ChildEditEducationViewModel model)
        {
            ChildInfo.DailySchedule = model.DailySchedule?.Select(x => Convert.ToInt32(x)).ToList();
            ChildInfo.WeaklySchedule = model.WeaklySchedule?.Select(x => Convert.ToInt32(x)).ToList();
            ChildInfo.PipeLineType = model.PipeLineType;
        }

        public void Update(StaffEditGeneralViewModel model)
        {
            FirstName = model.FirstName;
            LastName = model.LastName;
            DateOfBirth = model.DateOfBirth;            
            StaffInfo.PhoneNumber = model.PhoneNumber;
            StaffInfo.PhoneNumberDigitPin = model.PhoneNumberDigitPin;
        }

        public void Update(StaffEditOtherViewModel model)
        {
            StaffInfo.Salary = model.Salary;
            StaffInfo.SalaryType = model.SalaryType;
            StaffInfo.FingerPrinting = model.FingerPrinting;
            StaffInfo.FirstAidTraining = model.FirstAidTraining;
            StaffInfo.ChildAbuseCert = model.ChildAbuseCert;
            StaffInfo.Scr = model.Scr;
            StaffInfo.StaffRole = model.StaffRole;
            StaffInfo.Schedule = model.Schedule?.Select(x => Convert.ToInt32(x)).ToList();
        }
    }
}
