using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Xml;
using log4net;


namespace CodeNote.Common.Net.Mail
{
    public class EmailWrap
    {

        protected ILog log = LogManager.GetLogger(typeof(EmailWrap));

        public EmailWrap()
        {
            this.Smtp = SmtpList["default"];
        }

        private IDictionary<string, MailConfig.SmtpConfig> SmtpList
        {
            get
            {
                IDictionary<string, MailConfig.SmtpConfig> dic = new Dictionary<string, MailConfig.SmtpConfig>();
                dic = ConfigurationManager.GetSection("mail") as IDictionary<string, MailConfig.SmtpConfig>;
                return dic;
            }
        }

        public MailConfig.SmtpConfig Smtp { get; set; }

        public EmailWrap(string smtpName)
        {
            this.Smtp = SmtpList[smtpName];
        }

        private static EmailWrap _defalt;
        public static EmailWrap Default
        {
            get
            {
                if (_defalt == null)
                {
                    _defalt = new EmailWrap();
                }
                return _defalt;
            }
        }

        public void Send(string email, string subject, string body)
        {
            SmtpClient client = new SmtpClient(this.Smtp.Smtp, this.Smtp.Port);
            NetworkCredential nc = new NetworkCredential(this.Smtp.UserName, this.Smtp.PassWord);
            client.Credentials = nc;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(this.Smtp.UserName, this.Smtp.DisplyName, Encoding.UTF8);

            mail.To.Add(email);
            mail.Priority = MailPriority.High;
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = body;
            mail.BodyEncoding = Encoding.UTF8;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("{0}=>{3} :{4}", this.Smtp, email, ex.Message));
            }
        }
    }




}

namespace CodeNote.Common.Net.MailConfig
{
    public class SectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            IDictionary<string, SmtpConfig> dic = new Dictionary<string, SmtpConfig>();
            foreach (XmlNode item in section)
            {
                SmtpConfig smtp = new SmtpConfig();
                smtp.Smtp = item.Attributes["value"].Value;
                smtp.Port = ConvertWrap.ToInt(item.Attributes["port"].Value, 25);
                smtp.UserName = item.Attributes["username"].Value;
                smtp.PassWord = item.Attributes["password"].Value;
                smtp.DisplyName = item.Attributes["displyname"].Value;
                dic.Add(item.Attributes["name"].Value, smtp);
            }
            return dic;
        }
    }

    public struct SmtpConfig
    {
        public string Smtp { get; set; }
        public string UserName { get; set; }
        public string DisplyName { get; set; }
        public string PassWord { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1} {2}{3}{4}", this.Smtp, this.Port, this.UserName, this.PassWord, this.DisplyName);
        }
    }
}
