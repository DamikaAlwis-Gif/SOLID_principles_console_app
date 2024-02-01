using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class TaskFactory : ITaskFactory
    {
        public ATask CreateTask(string task_type, string task_details)
        {
            String[] list = task_details.Split(',');
            String[] temp = list[1].Trim().Split('-');
            
            ATask task = null;
            switch (task_type)
            {
                case "personal":
                    try
                    {
                        if (list.Length == 2)
                        {
                            task = new PersonalTask(list[0], list[1]);
                        }
                        else if (list.Length == 3)
                        {
                            task = new PersonalTask(list[0], list[1], Convert.ToInt32(list[2]));
                        }
                        else
                        {
                            // Handle the case where the length of the list is not 2 or 3
                            throw new ArgumentException("Invalid number of elements in the list.");
                        }

                        //System.out.println("Personal task created");
                    }
                    catch (ArgumentException ex){
                        Console.Error.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                    }
                   
                    catch (Exception ex) { 
                        Console.Error.WriteLine(ex.StackTrace);
                    }
                    
                    
                    break;

                case "official":
                    try
                    {
                        if (list.Length == 4)
                        {
                            task = new OfficialTask(list[0], list[1], list[2], list[3]);
                        }
                        else if (list.Length == 5)
                        {
                            task = new OfficialTask(list[0], list[1], list[2], list[3], Convert.ToInt32(list[4]));
                        }
                        else
                        {
                            throw new ArgumentException("Invalid number of elements in the list.");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    

                    //System.out.println("Official task created");

                    break;
                default:
                    //System.out.println("Invalid task type!");
                    break;

            }
            return task;
        }
    }
}
