using Kiddywee.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.AttendanceViewModels
{
    public class AttendanceViewModel
    {
        public Guid AttendanceId { get; set; } 
        public string Name { get; set; } 
        public DateTime? Date { get; set; }
        public EnumAttendanceType AttendanceType { get; set; } 

    
        //public int Hours()
        //{
          
        //}
    }
}
