using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.BLL.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string recipient, string subject, string body);
        void SendEmail(string recipient, string subject, string body);
    }
}
