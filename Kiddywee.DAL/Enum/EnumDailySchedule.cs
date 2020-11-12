using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumDailySchedule
    {
        [Display(Name = "Full Time")]
        FullTime,
        [Display(Name = "Part Time")]
        PartTime,
        [Display(Name = "Early Session")]
        EarlySession,
        [Display(Name = "Morning Session")]
        MorningSession,
        [Display(Name = "Afternoon Session")]
        AfternoonSession,
        [Display(Name = "Late Stay")]
        LateStay
    }
}
