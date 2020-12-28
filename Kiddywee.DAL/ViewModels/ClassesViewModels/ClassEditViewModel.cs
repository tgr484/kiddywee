using System;
using System.Collections.Generic;
using System.Text;
using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;

namespace Kiddywee.DAL.ViewModels.ClassesViewModels
{
    public class ClassEditViewModel
    {
        public ClassEditViewModel()
        {
            Classes = new List<Class>();
            DailyReportTypes = new List<EnumDailyReportType>();
        }
        public bool IsMove { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public Guid? MoveClassId { get; set; }
        public Guid OrganizationId { get; set; }

        public List<Class> Classes { get; set; }
        public Guid ClassId { get; set; }
        public string Name { get; set; }
        public EnumStageType StageType { get; set; }

        public List<EnumDailyReportType> DailyReportTypes { get; set; }

        public int? EnrollmentSpots { get; set; }

        public int? TeacherStudentRatio { get; set; }
    }
}
