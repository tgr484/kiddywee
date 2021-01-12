using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumDailyReportType
    {
        [Display(Name = "Naps/Sleep")]
        NapsSleep,
        Meals,
        Bathroom,
        Medication,
        Activities,
        Snapshots
        
    }
}
