using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace FrontierAg
{
    public class Emailer
    {
        private string _server = "mail.frontierssi.com";
        public string LastErrorMsg = "";

        public Emailer()
        {

        }
        public Emailer(string server)
        {
            _server = server;
        }

        public bool SendEmail(string to,string from,string subject,string body)
        {
            return SendEmail(to, from, subject, body, null);
        }
        public bool SendEmail(string to,string from,string subject,string body,IEnumerable<System.Net.Mail.Attachment> attachments)
        {
            LastErrorMsg = "";
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(_server);
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(from, to, subject, body);
                if (attachments != null)
                    foreach (System.Net.Mail.Attachment attachment in attachments)
                        msg.Attachments.Add(attachment);
                client.Send(msg);
            }
            catch (Exception ex)
            {
                LastErrorMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}