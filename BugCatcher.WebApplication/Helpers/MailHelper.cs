using BugCatcher.BusinessLayer.Managers;
using System;
using System.Net;
using System.Net.Mail;

namespace BugCatcher.WebApplication.Helpers
{
    public static class MailHelper
    {
        public static async System.Threading.Tasks.Task SendMailAsync(string subject, string body, int? projectId, int? itemId, string toEmail)
        {

            if (projectId != null)
            {
                var projectSubs = new EfProjectSubcribersRepository().GetProjectSubscribersOrNull(Convert.ToInt32(projectId));

                foreach (var sub in projectSubs)
                {
                    await SendMailAsync(subject, body, sub.Email);
                }
            }

            if (itemId != null)
            {
                var itemSubs = new EfItemSubcribersRepository().GetItemSubscribersOrNull(Convert.ToInt32(itemId));

                foreach (var sub in itemSubs)
                {
                    await SendMailAsync(subject, body, sub.Email);
                }
            }

            if (!string.IsNullOrEmpty(toEmail))
            {
                await SendMailAsync(subject, body, toEmail);
            }
        }

        private static async System.Threading.Tasks.Task SendMailAsync(string subject, string body, string email)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.live.com", // set your SMTP server name here
                Port = 587, // Port 
                EnableSsl = true,
                Credentials = new NetworkCredential("erdem_ozdemir34@hotmail.com.tr", "8426159753e")
            };

            using (var message = new MailMessage("erdem_ozdemir34@hotmail.com.tr", email)
            {
                Subject = subject,
                Body = body
            })

            {
                await smtpClient.SendMailAsync(message);
            }

            smtpClient.Dispose();
        }
    }
}
