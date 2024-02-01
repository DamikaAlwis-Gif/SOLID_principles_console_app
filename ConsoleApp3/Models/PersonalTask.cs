using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class PersonalTask : ATask
    {
        public PersonalTask(string description, string date, int priority) : 
            base(description, date, priority)
        {
            base.Type = "personal" + base.Type; // set the type
        }
        public PersonalTask(string description, string date) : base(description, date)
        {
            base.Type = "personal" + base.Type; // set the type
        }

        public override Dictionary<string, string> ShowDetails()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary["Description"] = this.Description;
            dictionary["Date"] = this.Date;
            dictionary["Priority"] = Convert.ToString(this.Priority);
            return dictionary;
        }
    }
}
