using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Interface
{
    internal interface IUserFactory
    {
        AUser CreateUser(string username,string email , string password);
    }
}
