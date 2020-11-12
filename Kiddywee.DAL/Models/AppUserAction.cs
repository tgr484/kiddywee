using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class AppUserAction : BaseEntity
    {
        public string Url { get; set; } 
        public string Value { get; set; } 
        public string Method { get; set; } 
        public string Ip { get; set; } 
    }
}
