using ConsoleApp3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class UserFactory : IUserFactory
    {
        public AUser CreateUser(string username, string email, string password)
        {
            return new User(username, email, password);
        }
    }
}
