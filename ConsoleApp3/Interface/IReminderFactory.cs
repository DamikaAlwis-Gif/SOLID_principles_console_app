using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IReminderFactory
    {
        AReminder CreateReminder();
        AReminder CreateReminder(string to, string subject, string content);
    }
}
