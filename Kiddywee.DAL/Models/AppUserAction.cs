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

        public static AppUserAction Create(string url, string value, string method, string ip, string applicationUserId)
        {
            return new AppUserAction() { Url = url, Value = value, Method = method, Ip = ip, CreatedById = applicationUserId};
        }
    }
}
