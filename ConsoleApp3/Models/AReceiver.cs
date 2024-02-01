using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class AReceiver
    {
        private string name;
        private string email;

        public AReceiver(string name, string email)
        {
            this.name = name;
            this.email = email;
        }
        
        public string Name { get { return name; } set { name = value; } }

        public string Email { get { return email; } set { email = value; } }


    }
}
