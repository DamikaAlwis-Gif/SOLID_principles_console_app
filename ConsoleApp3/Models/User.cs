using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class User : AUser
    {
        public User(string name, string email, string password) : base(name, email, password)
        {
        }
    }
}
