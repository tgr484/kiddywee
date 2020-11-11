using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.BLL.Core
{
    public class EmailSettings
    {
        public string EmailSenderSmtpServer { get; set; }
        public int EmailSenderPort { get; set; }
        public bool EmailSenderEnableSsl { get; set; }
        public string EmailSenderLogin { get; set; }
        public string EmailSenderPassword { get; set; }
    }
}
