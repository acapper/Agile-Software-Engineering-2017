using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace Agile_2018
{
    public class AutomaticEmail
    {
        /// <summary>
        /// Sends the passed mailmessage using no-reply@acapper.tk email account
        /// </summary>
        /// <param name="m">Mailmessage that you wish to send. From gets overwritten with no-reply@acapper.tk</param>
        /// <returns>True on send success. False on fail.</returns>
        public bool SendConfirmationEmail(MailMessage m)
        {
            JObject secrets = JObject.Parse(File.ReadAllText("SECRETS.json"));
            m.From = new MailAddress(secrets["email"]["address"].ToString());

            SmtpClient sc = new SmtpClient();
            sc.UseDefaultCredentials = false;
            sc.Host = "cp3.tserverhq.com";
            sc.Port = 587;
            sc.Credentials = new NetworkCredential(secrets["email"]["address"].ToString(), secrets["email"]["pass"].ToString());
            sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
            try
            {
                sc.Send(m);
                return true;
            }
            catch (SmtpException)
            {
                return false;
            }
        }

        /// <summary>
        /// Sends the passed body to the passed email with the passed subject as the subject
        /// </summary>
        /// <param name="email">The email address of the recipent</param>
        /// <param name="subject">The email subject</param>
        /// <param name="body">The email body text</param>
        /// <returns>True on send success. False on fail.</returns>
        public bool SendConfirmationEmail(String email, String subject, String body)
        {
            MailMessage m = new MailMessage();
            m.To.Add(email);
            m.Subject = subject;
            m.Body = body;

            return SendConfirmationEmail(m);
        }
    }
}