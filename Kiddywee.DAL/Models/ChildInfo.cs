using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class ChildInfo : BaseEntity
    {
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

        public Guid PersonId { get; set; }
        
        public Guid? MedicalInfoId { get; set; }
        public MedicalInfo MedicalInfo { get; set; }
        public Guid? ImmunisationId { get; set; }

        public MedicalInfo Immunisation { get; set; }

        public bool Allergies { get; set; }
        public string AllergiesNotes { get; set; }

        public bool PictureAuthorized { get; set; }

    }
}
