using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumStageType
    {
        Infant,
        Toddler,
        Preschool,
        School,
        [Display(Name = "Any age")]
        AnyAge,
    }
}
