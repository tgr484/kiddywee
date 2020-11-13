using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kiddywee.DAL.Enum
{
    public enum EnumStaffRoleType
    {
        [Display(Name = "Account Admin")]
        AccountAdmin,
        [Display(Name = "Center Admin")]
        CenterAdmin,
        [Display(Name = "Head Teacher")]
        HeadTeacher,
        [Display(Name = "Teacher")]
        Teacher,
        [Display(Name = "Teacher Assistant")]
        TeacherAssistant,
        [Display(Name = "Substitute Teacher")]
        SubstituteTeacher,
        [Display(Name = "Student Teacher")]
        StudentTeacher,
    }
}
