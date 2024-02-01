using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal interface IDataOperations
    {
        void SaveData(ATask task); 

        List<ATask> GetTasksByDate(string date);
        ATask GetTaskById(int id);

        

    }
}
