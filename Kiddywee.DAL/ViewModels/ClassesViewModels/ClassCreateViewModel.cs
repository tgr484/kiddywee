using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.ClassesViewModels
{
    public class ClassCreateViewModel
    {
        public Guid OrganizationId { get; set; } 

        public string Name { get; set; }
        public EnumStageType StageType { get; set; }

        public List<int> DailyReportTypes { get; set; } 

        public int? EnrollmentSpots { get; set; }

        public int? TeacherStudentRatio { get; set; }
    }
}
