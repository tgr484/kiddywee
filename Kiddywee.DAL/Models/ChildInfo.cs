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

        public Guid ClassId { get; set; }

        public Class Class { get; set; }

        public Guid? CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }

        public EnumPipeLineType PipeLineType { get; set; }
         
        public Guid? MedicalInfoId { get; set; }
        public MedicalInfo MedicalInfo { get; set; }
        public Guid? ImmunisationId { get; set; }

        public MedicalInfo Immunisation { get; set; }

        public bool Allergies { get; set; }
        public string AllergiesNotes { get; set; }

        public bool PictureAuthorized { get; set; }

        public static ChildInfo Create(PersonCreateViewModel model, Guid classId, string userId)
        {
            return new ChildInfo()
            {
                Address = model.Address,
                ClassId = classId,
                WeaklySchedule = model.WeaklySchedule.Select(x => Convert.ToInt32(x)).ToList(),
                DailySchedule = model.DailySchedule.Select(x => Convert.ToInt32(x)).ToList(), 
                PipeLineType = model.PipeLineType,
                NextMedical = model.NextMedical,
                CreatedById = userId
            };
        }
    }
}
