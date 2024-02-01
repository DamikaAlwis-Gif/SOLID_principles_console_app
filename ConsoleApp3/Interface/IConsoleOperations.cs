using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IConsoleOperations
    {
        String GetPersonalTaskDetails();
        String GetOfficialTaskDetails();
        void ShowInvalidTaskTypeMessage();
        void ShowInvalidInputMessage();
        String GetBaseOptionType();
        String GetTaskType();
        void ShowWelcomeMessage();
        String GetDateInput();
        int GetIDInput();
        String GetReceiverDetails();

    }
}
