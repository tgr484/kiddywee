using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class LessonPlanWeakly : BaseEntity
    {
        public Guid OrgnizationId { get; set; }
        public Organization Orgnization { get; set; }

        public Guid? ClassId { get; set; }

        public Class Class { get; set; }

        public Guid? SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid? CurriculumToSubjectId { get; set; }
        public CurriculumToSubject CurriculumToSubject { get; set; }

        public DateTime WeekDateSunday { get; set; }
        public string Theme { get; set; }
        public string Notes { get; set; }
        public string TeacherNotes { get; set; }
    }
}
