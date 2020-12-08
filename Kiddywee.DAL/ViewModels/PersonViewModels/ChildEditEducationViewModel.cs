using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildEditEducationViewModel
    {
        public ChildEditEducationViewModel()
        {
            WeaklySchedule = new List<EnumWeeklyScheduleType>();
            DailySchedule = new List<EnumDailyScheduleType>();
            InClasses = new List<Guid>();
            Classes = new List<Class>();
        }

        public EnumPipeLineType PipeLineType { get; set; }
        public List<EnumWeeklyScheduleType> WeaklySchedule { get; set; }
        public List<EnumDailyScheduleType> DailySchedule { get; set; }
        public List<Class> Classes { get; set; }
        public List<Guid> InClasses { get; set; }

        public Guid PersonId { get; set; }
    }
}
