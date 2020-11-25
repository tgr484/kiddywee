using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildCreateViewModel
    {
        public ChildCreateViewModel()
        {
            Classes = new List<Class>();
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

        public IFormFile MedicalInfo { get; set; }
    }
}
