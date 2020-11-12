using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Class : BaseEntity
    {
        public Class()
        {
            Curriculums = new List<Curriculum>();
            DailyReportTypes = new List<int>();
            Subjects = new List<Subject>();
        }

        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public string Name { get; set; }
        public EnumStageType StageType { get; set; }    

        public List<int> DailyReportTypes { get; set; }

        public List<Curriculum> Curriculums { get; set; }
        public List<Subject> Subjects { get; set; }

        public int? EnrollmentSpots { get; set; }

        public int? TeacherStudentRatio { get; set; }
     

    }
}
