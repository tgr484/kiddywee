using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildEditViewModel
    {
        public ChildEditViewModel()
        {
            Classes = new List<Class>();
            WeaklySchedule = new List<EnumWeeklyScheduleType>();
            DailySchedule = new List<EnumDailyScheduleType>();
        }

        public List<Class> Classes { get; set; }

        public List<Guid> ClassId { get; set; }

        public string Address { get; set; }

        public DateTime? NextMedical { get; set; }

        public string Notes { get; set; }

        public List<EnumWeeklyScheduleType> WeaklySchedule { get; set; }
        public List<EnumDailyScheduleType> DailySchedule { get; set; }

        public EnumPipeLineType PipeLineType { get; set; }

        public bool Allergies { get; set; }
        public string AllergiesNotes { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid PersonId { get; set; }
        public FileInfo MedicalInfo { get; set; }

    }
}
