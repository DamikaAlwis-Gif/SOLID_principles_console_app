using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class AUser: AReceiver
    {
        private string password;

        protected AUser(string name, string email, string password) : base(name, email)
        {
            this.password = password;
        }
    }
}
