using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCL.Cockerham.Ogsm.Entities.CustomObjects
{
    public class EmailMessage
    {
        System.Net.Mail.MailAddressCollection _to;

        public System.Net.Mail.MailAddressCollection To
        {
            get { return _to; }
            set { _to = value; }
        }

        System.Net.Mail.MailAddress _from;

        public System.Net.Mail.MailAddress From
        {
            get { return _from; }
            set { _from = value; }
        }

        System.Net.Mail.MailAddressCollection _cc;

        public System.Net.Mail.MailAddressCollection Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }

        System.Net.Mail.MailAddressCollection _bcc;

        public System.Net.Mail.MailAddressCollection Bcc
        {
            get { return _bcc; }
            set { _bcc = value; }
        }

        string _subject;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        string _body;

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }
    }
}
