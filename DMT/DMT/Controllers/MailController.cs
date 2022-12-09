using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DMT.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        private static string email = "20-42650-1@student.aiub.edu";
        private static string pass = "Shanto12345-microsoft";

        public static bool Send(string to,string subject, string message)
        {
            MailAddress sender = new MailAddress(email);
            MailAddress reciever = new MailAddress(to);
            MailMessage msg = new MailMessage(sender, reciever);

            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;


            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                Credentials = new NetworkCredential(email, pass),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            try
            {
                client.Send(msg);
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}