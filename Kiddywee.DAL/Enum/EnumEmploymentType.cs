using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumEmploymentType
    {
        [Display(Name = "Full time")]
        FullTime,
        [Display(Name = "Part time")]
        PartTime

    }
}
