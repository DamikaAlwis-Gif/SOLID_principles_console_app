using ConsoleApp3.Implementations;
using ConsoleApp3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class TaskManagerApplication

    {
        private Controller controller;
        private IConsoleOperations consoleOperations;
        private IUserFactory userFactory;
        private IReminderFactory reminderFactory;
        
        public TaskManagerApplication()
        {
            this.IntializeDependencies();
        }

        private void IntializeDependencies()
        {
            MongoDBService mongoDBService = new MongoDBService();
            TaskFactory taskFactory = new TaskFactory();// for creating new tasks
            TaskDataOperations taskDataOperations = new TaskDataOperations(mongoDBService,taskFactory);
            //FileOperations fileOperations = new FileOperations();// do file operations (data operations)
            EmailOperations emailOperations = new EmailOperations(); // class for email operaions
            ReceiverManager receiverManager = ReceiverManager.GetInstance();// class for managing receivers
            TodayTaskSender automaticReminderOperations = new TodayTaskSender(taskDataOperations, emailOperations);

            this.userFactory = new UserFactory();
            this.reminderFactory = new EmailFactory();
            

            this.controller = new Controller(
                taskFactory, 
                taskDataOperations, 
                automaticReminderOperations, 
                emailOperations,
                receiverManager);

            this.consoleOperations = new ConsoleOperations(); // handle console inputs and outputs

        }
        public void Run()
        {
          
            controller.HandleSendingTodayTaskListUser(userFactory, reminderFactory);
            consoleOperations.ShowWelcomeMessage();

            while (true)
            {

                try
                {

                    String option = consoleOperations.GetBaseOptionType();
                    switch (option)
                    {

                        case "1":

                            String task_choice = consoleOperations.GetTaskType();

                            switch (task_choice)
                            {
                                case "1":
                                    String personalTaskDetail = consoleOperations.GetPersonalTaskDetails(); // get the input
                                    controller.HandleAddingAPersonalTask(personalTaskDetail);
                                    break;

                                case "2":

                                    String officialTaskDetail = consoleOperations.GetOfficialTaskDetails(); // get the input
                                    controller.HandleAddingAOfficialTask(officialTaskDetail);
                                    break;

                                default:
                                    consoleOperations.ShowInvalidTaskTypeMessage();
                                    break;
                            }

                            break;
                        case "2":
                            String dateInput = consoleOperations.GetDateInput(); // getting inputs
                            controller.HandleSeeTaskDetailsByDate(dateInput);
                            break;

                        case "3":

                            int id = consoleOperations.GetIDInput();
                            controller.HandleSeeTaskDetailsById(id);

                            break;
                        case "4":
                            String receiverDetailInput = consoleOperations.GetReceiverDetails();
                            controller.HandleSendingTaskDetails(receiverDetailInput);
                            break;

                        default:
                            consoleOperations.ShowInvalidInputMessage();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }

        }

    }
}
