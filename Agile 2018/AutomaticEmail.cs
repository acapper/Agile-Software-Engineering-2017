using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Agile_2018
{
    public class AutomaticEmail
    {

        public void SendConfirmationEmail()
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.To.Add("acapper56@gmail.com");
            m.Subject = "This is the Subject line";
            m.From = new MailAddress("no-reply@acapper.tk");
            m.Body = "This is the message body";

            SmtpClient sc = new SmtpClient();
            sc.Host = "mail.acapper.tk ";
            sc.Port = 587;
            sc.Credentials = new NetworkCredential("no-reply@acapper.tk", "v{Cg{sh?FBEJ");
            sc.EnableSsl = false; // runtime encrypt the SMTP communications using SSL
            sc.Send(m);

            /*MailMessage mail = new MailMessage("no-reply@acapper.tk", "acapper56@gmail.com");
            SmtpClient client = new SmtpClient();
            client.Port = 465;
            client.Credentials = new NetworkCredential("no-reply@acapper.tk", "v{Cg{sh?FBEJ");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "cp3.tserverhq.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);*/
        }
    }
}