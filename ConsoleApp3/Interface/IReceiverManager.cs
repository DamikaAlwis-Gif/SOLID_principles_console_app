using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IReceiverManager
    {
        AReceiver CreateReceiver(String input);// creating a receiver
        List<AReceiver> GetReceivers();// get list of all the receivers
    }
}
