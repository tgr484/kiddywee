using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumPipeLineType
    {
        Interested,
        Touring,
        Visited,
        [Display(Name = "Wait list")]
        WaitList,
        Scheduled,
        Active,
        Inactive,
        Disenrolling,
    }
}
