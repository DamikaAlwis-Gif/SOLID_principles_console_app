using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Email: AReminder
    {
        public Email(): base() { }
        public Email(String to, String subject, String content): base(to, subject, content) { }
        
    }
}
