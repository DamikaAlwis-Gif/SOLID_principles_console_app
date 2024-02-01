using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class OfficialTask : AOfficialTask
    {
        public OfficialTask(string description, string date, string project, string status, int priority) 
            : base(description, date, project, status, priority)
        {
        }
        public OfficialTask(string description, string date, string project, string status)
            : base(description, date, project, status)
        {
        }
        public override Dictionary<string, string> ShowDetails() { 
            Dictionary<string,string> dictionary = new Dictionary<string, string>();
            dictionary["Description"] = this.Description;
            dictionary["Date"] = this.Date;
            dictionary["Project"] = this.Project;
            dictionary["Status"] = this.Status;
            dictionary["Priority"] = Convert.ToString(this.Priority);
            return dictionary; 
        }

    }
}
