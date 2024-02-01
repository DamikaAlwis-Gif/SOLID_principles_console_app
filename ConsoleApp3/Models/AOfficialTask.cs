using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal abstract class AOfficialTask: ATask
       
    {
        private string status;
        private string project;
        
        
        public AOfficialTask(string description,string date, string project, string status, int priority)
            : base(description, date, priority)
        {
            
            this.status = status;
            this.project = project;
            base.Type = "official" + base.Type; // set the type
        }

        public AOfficialTask(string description, string date, string project, string status)
            :base(description, date)
        {
            
            this.status = status;
            this.project = project;
            base.Type = "official" + base.Type; // set the type

        }

        public string Status
        {
            get { return status; }
        }
        public string Project
        {
            get { return project; }
        }
    }
}
