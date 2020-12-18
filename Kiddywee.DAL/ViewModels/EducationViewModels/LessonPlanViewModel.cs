using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.EducationViewModels
{
    public class LessonPlanViewModel
    {
        public string Theme { get; set; }
        public string Notes { get; set; }

        public Guid? ClassId { get; set; }
        public DateTime Date { get; set; }
        public string WeeklyTheme { get; set; }
        public Guid? LessonPlanId { get; set; }
        public Guid? LessonPlanWeeklyId { get; set; }

    }
}
