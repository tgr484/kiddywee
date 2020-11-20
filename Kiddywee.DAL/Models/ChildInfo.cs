using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class ChildInfo : BaseEntity
    {
        public ChildInfo()
        {
            WeaklySchedule = new List<int>();
            DailySchedule = new List<int>();
        }

        public string Address { get; set; }

        public DateTime? NextMedical { get; set; }

        public string Notes { get; set; }

        public List<int> WeaklySchedule { get; set; }
        public List<int> DailySchedule { get; set; }

        public Guid? CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }

        public EnumPipeLineType PipeLineType { get; set; }

        public bool Allergies { get; set; }
        public string AllergiesNotes { get; set; }

        public bool PictureAuthorized { get; set; }

        public static ChildInfo Create(ChildCreateViewModel model, string userId)
        {
            return new ChildInfo()
            {
                Address = model.Address,
                WeaklySchedule = model.WeaklySchedule?.Select(x => Convert.ToInt32(x)).ToList(),
                DailySchedule = model.DailySchedule?.Select(x => Convert.ToInt32(x)).ToList(),
                PipeLineType = model.PipeLineType,
                NextMedical = model.NextMedical,
                CreatedById = userId
            };
        }

        public static ChildEditViewModel Init(Person person, List<Class> classes)
        {
            var ci = person.ChildInfo != null ? person.ChildInfo : new ChildInfo();

            var classId = person.PersonToClasses.FirstOrDefault(x => x.PersonId == person.Id && x.IsActive == true) 
                != null ? person.PersonToClasses.FirstOrDefault(x => x.PersonId == person.Id && x.IsActive == true).ClassId 
                        : new Guid();
            return new ChildEditViewModel()
            {
                Classes = classes,
                Address = ci.Address,
                Allergies = ci.Allergies,
                AllergiesNotes = ci.AllergiesNotes,
                ClassId = classId,
                DailySchedule =  ci.DailySchedule?.Cast<EnumDailyScheduleType>().ToList(),
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                LastName = person.LastName,
                NextMedical = ci.NextMedical,
                Notes = ci.Notes,
                PipeLineType = ci.PipeLineType,
                WeaklySchedule = ci.WeaklySchedule?.Cast<EnumWeeklyScheduleType>().ToList(),
                PersonId = person.Id
            };
        }
    }
}
