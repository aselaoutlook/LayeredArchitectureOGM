#region Header
///-------------------------------------------------------------------------------------------
///MAIN MODULE   : FCL.Cockerham.Ogsm.Admin.Core.Util
///MODULE        :         
///SUB MODULE    :    
///Class         : EmailSender
///AUTHOR        : Asela Chamara      
///CREATED       : 12/08/2015        
///DESCRIPTION   : Purpose is to provide methods to send emails
///COPYRIGHT : Copyright Four Corners Lanka (Pte) Ltd. All Rights Reserved.
///-------------------------------------------------------------------------------------------
#endregion

using System;
using System.Net;
using System.Net.Mail;
using FCL.Cockerham.Ogsm.Entities.CustomObjects;
using System.ComponentModel.Composition;

namespace FCL.Cockerham.Ogsm.ClientSite.Core.Util
{
    [Export(typeof(IEmailSender))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class EmailSender : IEmailSender
    {
        [Import]
        IConfigCaller ConfigCaller { get; set; }

        #region Public Properties
        string _sMTPServer = "";
        public string SMTPServer
        {
            get { return _sMTPServer; }
            set { _sMTPServer = value; }
        }

        string _sMTPPort = "";
        public string SMTPPort
        {
            get { return _sMTPPort; }
            set { _sMTPPort = value; }
        }

        string _sMTPUser = "";
        public string SMTPUser
        {
            get { return _sMTPUser; }
            set { _sMTPUser = value; }
        }

        string _sMTPPass = "";
        public string SMTPPass
        {
            get { return _sMTPPass; }
            set { _sMTPPass = value; }
        }

        bool _sMTPSsl = false;
        public bool SMTPSsl
        {
            get { return _sMTPSsl; }
            set { _sMTPSsl = value; }
        }
        #endregion

        /// <summary>
        /// Send Email Function
        /// </summary>
        /// <param name="email">Prameter EmailMessage email</param>
        /// <returns>bool</returns>
        public bool SendEmail(EmailMessage email)
        {
            GetEmailSettings();
            MailMessage msg = new MailMessage();
            msg.From = email.From;

            if (email.To != null)
                foreach (MailAddress to in email.To)
                    msg.To.Add(to);
            if (email.Cc != null)
                foreach (MailAddress cc in email.Cc)
                    msg.CC.Add(cc);
            if (email.Bcc != null)
                foreach (MailAddress bcc in email.Bcc)
                    msg.Bcc.Add(bcc);

            msg.Subject = email.Subject;
            msg.Body = email.Body;
            msg.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(
                SMTPServer,
                Convert.ToInt32(SMTPPort));
            smtp.Credentials = new NetworkCredential(SMTPUser, SMTPPass);
            smtp.EnableSsl = SMTPSsl;
            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Send Email Function
        /// </summary>
        /// <param name="email">Prameter EmailMessage email</param>
        /// <param name="attachment">Prameter email attachment</param>
        /// <returns>bool</returns>
        public bool SendEmail(EmailMessage email, string attachment)
        {
            GetEmailSettings();
            MailMessage msg = new MailMessage();
            msg.From = email.From;

            if (email.To != null)
                foreach (MailAddress to in email.To)
                    msg.To.Add(to);
            if (email.Cc != null)
                foreach (MailAddress cc in email.Cc)
                    msg.CC.Add(cc);
            if (email.Bcc != null)
                foreach (MailAddress bcc in email.Bcc)
                    msg.Bcc.Add(bcc);


            msg.Subject = email.Subject;
            msg.Body = email.Body;
            msg.IsBodyHtml = true;

            if (!string.IsNullOrEmpty(attachment))
            {
                Attachment inline = new Attachment(System.Web.HttpContext.Current.Server.MapPath(attachment));
                msg.Attachments.Add(inline);
            }

            SmtpClient smtp = new SmtpClient(
                SMTPServer,
                Convert.ToInt32(SMTPPort));
            smtp.Credentials = new NetworkCredential(SMTPUser, SMTPPass);
            smtp.EnableSsl = SMTPSsl;
            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get email settings from the config file
        /// </summary>
        private void GetEmailSettings()
        {
            SMTPServer = ConfigCaller.SMTPServer;
            SMTPPort = ConfigCaller.SMTPPort;
            SMTPUser = ConfigCaller.SMTPUser;
            SMTPPass = ConfigCaller.SMTPPass;
            SMTPSsl = Convert.ToBoolean(ConfigCaller.SMTPSsl);
        }
    }
}