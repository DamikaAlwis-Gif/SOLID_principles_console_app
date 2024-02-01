using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class TodayTaskSender: ITodayTaskSender
    {
        private IDataOperations dataOperations;
        private IReminderOperations reminderOperations;

        public TodayTaskSender(IDataOperations dataOperations, IReminderOperations reminderOperations)
        {
            this.dataOperations = dataOperations;
            this.reminderOperations = reminderOperations;

        }

        public void SendTodayTasks(AReceiver receiver, AReminder reminder)
        {
            
            DateTime now = DateTime.Today;
            string today = now.ToString("yyyy-MM-dd");
            List<ATask> todayTaskList = dataOperations.GetTasksByDate(today);
            String subject = "Today's tasks";
            String content = "";
            if (!(todayTaskList.Count == 0))
            {
                
                foreach (ATask task in todayTaskList)
                {
                    content = $"Task ID: {task.Task_id} \n" +
                    $"Type : {task.Type} \n" +
                    $"Description: {task.Description} \n" +
                    $"Date : {task.Date} \n" +
                    $"Completed : {task.Completed} \n" +
                    $"Priority : {task.Priority} \n";
                    if (task is OfficialTask officialTask)
                    {
                        content += $"Project : {officialTask.Project} \n" +
                            $"Status : {officialTask.Status} \n";
                    }

                }
                //Email mail = new Email(receiver.getEmail(), subject,content);
                reminder.To= receiver.Email;
                reminder.Content = content;
                reminder.Subject = subject;

                reminderOperations.Send(reminder);
            }
            else
            {
               Console.WriteLine("No tasks for today! " + DateTime.Now);
            }
           
        }

    }
}
