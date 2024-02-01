using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class AReminder
    {

        private string to;
        private string subject;
        private string content;

        public AReminder(String to, String subject, String content)
        {
            this.to = to;
            this.subject = subject;
            this.content = content;
        }

        public AReminder()
        {
        }

        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
    }


}
