using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class ATask
    {
        private int task_id ;
        private string description;
        private int priority;
        private bool completed;
        private string date;
        private static int count = 0;// start from 0
        private string type;
        private const int defualt_priority= 3;
        

        // constructor for ATask
        public ATask(string description, string date, int priority)
        {
            this.description = description;
            this.priority = priority;
            this.date = date;
            completed = false;
            count++;
            task_id = count;
            type = "";
            
        }

        //constructor for ATask get only two parameters
        public ATask(String description,string date)
        {
            this.description = description;
            this.date = date;
            this.priority = defualt_priority; // default priority
            completed = false;
            count++;
            task_id = count;
            type = "";
        }


        //public abstract string showDetails(); // return the details of the task
        public abstract Dictionary<string,string> ShowDetails();
        
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        


        public string Description
        {
            get{
                return description;
            }
            set { description = value; }
        }


        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }


        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Task_id
        {
            get { return task_id;}
            set { task_id = value; }
        }

        


    }
}
