using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class EmailFactory : IReminderFactory
    {
        public AReminder CreateReminder()
        {
            return new Email();
        }

        public AReminder CreateReminder(string to, string subject, string content)
        {
            return new Email(to, subject, content);
        }
    }
}
