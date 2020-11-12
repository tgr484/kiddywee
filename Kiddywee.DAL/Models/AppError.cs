using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class AppError : BaseEntity
    {
        public string Url { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Method { get; set; }
        public string Ip { get; set; }
    }
}
