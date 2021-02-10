using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Localization;
using MimeKit;
using TCYDMWebApp.Repositories.Lang;
using TCYDMWebApp.ViewModels;

namespace TCYDMWebApp.Helper
{
    public class MailSender
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        public MailSender(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
        }
        
        public static void SendEmail(string FromUser, string FromEmail,string ToUser, string ToEmail,string Subject,string Body,string SmtpEmail,string SmtpPassword)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromUser, FromEmail));
            message.To.Add(new MailboxAddress(ToUser,ToEmail));
            message.Subject = Subject;
            message.Body = new TextPart("html") {
             Text = Body
            };
            using (var client = new SmtpClient()) {
                client.Connect("smtp.mail.ru",587,false);
                client.Authenticate(SmtpEmail, SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        

    }
   
}
