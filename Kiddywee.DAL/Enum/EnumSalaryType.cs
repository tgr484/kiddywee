using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumSalaryType
    {
        [Display(Name = "p/h")]
        PerHour,
        [Display(Name = "p/y")]
        PerYear
    }
}
