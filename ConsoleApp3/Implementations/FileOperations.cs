using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp3
{
    internal class FileOperations 

    {
        private string persoanlTaskLocation;
        private string officilaTaskLocation;

        public FileOperations()
        {
        
        persoanlTaskLocation = @"C:\Users\DamikaAlwis\source\repos\ConsoleApp3\ConsoleApp3\Text Files\personalTasks.txt";
        officilaTaskLocation = @"C:\Users\DamikaAlwis\source\repos\ConsoleApp3\ConsoleApp3\Text Files\officialTasks.txt";
        }

        

        public List<string> ReadTaskData(string location)
        {
            List<string> lines = new List<string>();

            try
            {
                // Read all lines from the file into a List<string>
                lines = File.ReadAllLines(location).ToList();

                Console.WriteLine("Content has been read from the file.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                // Handle the exception as needed
            }

            return lines;

        }

        public void SaveTaskData(string location, string content)
        {
            try
            {
                // Write the content to the file or create a new file if it doesn't exist
                File.AppendAllText(location, content + Environment.NewLine);

                Console.WriteLine("Content has been written to the file.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                // Handle the exception as needed
            }
        }

        public String getPersonalTaskLocation()
        {
            return persoanlTaskLocation;
        }
      
        public void setPersonalTaskLocation(String personalTaskLocation)
        {
            this.persoanlTaskLocation = personalTaskLocation;
        }
       
        public String getOfficialTaskLocation()
        {
            return officilaTaskLocation;
        }
        
        public void setOfficialTaskLocation(String officialTaskLocation)
        {
            this.officilaTaskLocation = officialTaskLocation;
        }


    }
}
