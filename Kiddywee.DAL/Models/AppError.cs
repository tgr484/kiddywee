using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class AppError : BaseEntity
    {
        public string Url { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string Method { get; set; }
        public string Ip { get; set; }

        public static AppError Create(string url, string stackTrace, string exception, string innerException, string method, string ip, string applicationUserId)
        {
            return new AppError() { Url = url, StackTrace = stackTrace, Exception = exception, InnerException = innerException, Method = method, Ip = ip, CreatedById = applicationUserId };
        }
    }
}
