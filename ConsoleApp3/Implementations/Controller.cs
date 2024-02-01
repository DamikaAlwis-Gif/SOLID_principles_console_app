using ConsoleApp3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Controller
    {
        private ITaskFactory taskFactory;
       
        private IDataOperations taskDataOperations;
        private ITodayTaskSender todayTaskSender;
        private IReminderOperations reminderOperations;
        private IReceiverManager receiverManager;
        


        public Controller(ITaskFactory taskFactory,
                          IDataOperations taskDataOperations,
                          ITodayTaskSender todayTaskSender, 
                          IReminderOperations reminderOperations,
                          IReceiverManager receiverManager)
        {

            
          
            // for creating new tasks
            this.taskFactory = taskFactory;

            // do file operations (data operations)
            this.taskDataOperations = taskDataOperations;

            

            // class for email operaions
            this.reminderOperations = reminderOperations;

            // class for managing receivers
            this.receiverManager = receiverManager;

            this.todayTaskSender = todayTaskSender;


        }

        public void HandleSeeTaskDetailsByDate(String input)
        {
            List<ATask> arr = taskDataOperations.GetTasksByDate(input);
            foreach (ATask task in arr)
            {
                PrintTaskDetails(task); 
            }
            

        }
        public void HandleSeeTaskDetailsById(int taskId)
        {

            ATask tempTask = taskDataOperations.GetTaskById(taskId);
            if (tempTask == null)
            {
                Console.WriteLine("There is no task with " + taskId + ".");
            }
            else
            {
                PrintTaskDetails(tempTask);

            }
        }



        public void HandleSendingTaskDetails(String receiverInput)
        {

            AReceiver receiver = receiverManager.CreateReceiver(receiverInput);
            todayTaskSender.SendTodayTasks(receiver, new Email());
        }

        public void HandleAddingAPersonalTask(String userInput)
        {

            // create a new task
            ATask task = taskFactory.CreateTask("personal", userInput);
            if (task != null)
            {
                // have to change this class to a service
                //taskRepository.Add(task);// add a new task to the task Repo
                taskDataOperations.SaveData(task);// save data
            }
        }

        public void HandleAddingAOfficialTask(String userInput)
        {

            // create a new task
            ATask task = taskFactory.CreateTask("official", userInput);
            if (task != null)
            {
                // have to change this class to a service
                //taskRepository.Add(task);// add a new task to the task Repo
                taskDataOperations.SaveData(task);// save data
            }
        }

        
        public void HandleSendingTodayTaskListUser(IUserFactory userFactory, IReminderFactory reminderFactory)
        {

            //create the current user of the application
            AUser user = userFactory.CreateUser("Kasun", "damika7alwis@gmail.com", "password123");
            AReminder reminder = reminderFactory.CreateReminder();
            todayTaskSender.SendTodayTasks(user, reminder);// send today tasks to the user
        }

        private void PrintTaskDetails(ATask task) {
            string details = "";
            if (task != null)
            {
                details = $"Task ID: {task.Task_id} \n" +
                    $"Type : {task.Type} \n" +
                    $"Description: {task.Description} \n" +
                    $"Date : {task.Date} \n" +
                    $"Completed : {task.Completed} \n" +
                    $"Priority : {task.Priority} \n";
                if ( task is OfficialTask officialTask)
                {
                    details += $"Project : {officialTask.Project} \n" +
                        $"Status : {officialTask.Status} \n";
                }
                    
            }
            Console.WriteLine(details);
        }
    }
}
