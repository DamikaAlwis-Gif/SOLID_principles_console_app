using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ReceiverManager : IReceiverManager

    {
        private static ReceiverManager firstInstance = null;
        private List<AReceiver> receivers = new List<AReceiver>();

        private ReceiverManager() { }
        public static ReceiverManager GetInstance()
        {
            if (firstInstance == null)
            {
                firstInstance = new ReceiverManager();
            }
            return firstInstance;
        }

        public List<AReceiver> GetReceivers()
        {
            return receivers;
        }


        public AReceiver CreateReceiver(String input)
        {
            AReceiver receiver = null;
            try
            {
                String[] arr = input.Split(',');
                if (arr.Length == 2)
                {
                    receiver = new Receiver(arr[0], arr[1]);
                    receivers.Add(receiver);
                    return receiver;
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return receiver;
        }

    }
}
