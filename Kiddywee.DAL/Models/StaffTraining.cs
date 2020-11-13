using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class StaffTraining : BaseEntity
    {
        public Guid StaffInfoId { get; set; }
        public StaffInfo StaffInfo { get; set; }

        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
