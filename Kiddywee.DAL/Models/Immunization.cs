using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Immunization : BaseEntity
    { 
        public Guid  PersonId { get; set; }
        public Person Person { get; set; }

        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string FileRealName { get; set; }
        public byte[] FileData { get; set; }
    }
}
