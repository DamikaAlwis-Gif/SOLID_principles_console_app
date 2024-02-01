using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class ConsoleOperations: IConsoleOperations
    {
        

        public ConsoleOperations()
        {
            
        }

        public String GetPersonalTaskDetails()
        {
            Console.Write("Use this format for your input \n" +
                    "<Description>,<Scheduled  Date>,<Priority> or <Description>,<Scheduled  Date> \n" +
                    ":");
            String personalTaskDetail = Console.ReadLine(); // get the input
            return personalTaskDetail;
        }
        public String GetOfficialTaskDetails()
        {
            Console.Write("Use this format for your input \n" +
                    "<Description>,<Scheduled  Date>,<Project>,<Status>,<Priority> or \n" + "<Description>,<Scheduled  Date><Project>,<Status> \n" +
                    ":");
            String officialTaskDetail = Console.ReadLine(); // get the input
            return officialTaskDetail;
        }


        public void ShowInvalidTaskTypeMessage()
        {
            Console.WriteLine("Invalid Task Type");
        }
        public void ShowInvalidInputMessage()
        {
            Console.WriteLine("Invalid Input!");
        }
        public String GetBaseOptionType()
        {
            Console.Write(
                    "1 - Adding a new Task.\n" +
                            "2 - See task list on a date.\n" +
                            "3 - See task details by task id.\n" +
                            "4 - Send task list to a another person.\n" +
                            "Enter your option type:");

            String option = Console.ReadLine();
            return option;
        }
        public String GetTaskType()
        {
            Console.Write("1 - Personal task \n" +
                    "2 - Official Task \n" +
                    "Enter your choice:");
            String task_choice = Console.ReadLine();
            return task_choice;
        }
        public void ShowWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Task Manager Application!");// welcome msg
        }

        public String GetDateInput()
        {
            Console.Write("Enter a date:");
            String dateInput = Console.ReadLine(); // getting inputs
            return dateInput;

        }
        public int GetIDInput()
        {
            Console.Write("Enter task id:");
            bool valid = false;
            int id = 0;
            do
            {
                try
                {
                    String taskIdInput = Console.ReadLine();// getting inputs
                    id = Convert.ToInt32(taskIdInput);
                    valid = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Enter a integer! Invalid input! ", e);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            while (!valid);

            return id;

        }
        public String GetReceiverDetails()
        {
            Console.Write("Use this format for your input \n" +
                    "<name>,<email> \n" +
                    ":");
            String receiverDetailInput = Console.ReadLine();// getting inputs
            return receiverDetailInput;

        }
    }
}
