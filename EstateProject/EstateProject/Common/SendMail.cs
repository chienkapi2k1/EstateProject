using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace EstateProject.Common
{

    public class SendMail
    {
        private static string emailHost = ConfigurationManager.AppSettings["emailHost"].ToString();
        private static int portHost = int.Parse(ConfigurationManager.AppSettings["portHost"].ToString());
        private static string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        private static string passwordEmail = ConfigurationManager.AppSettings["passwordEmail"].ToString();

        public static async Task<bool> sendMail(string toEmail, string subject, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.From = new MailAddress(fromEmail);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = emailHost;
                    smtp.Port = portHost;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(fromEmail, passwordEmail); // Enter seders User name and password
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}