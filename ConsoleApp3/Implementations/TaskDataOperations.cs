using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.Implementations
{
    internal class TaskDataOperations: IDataOperations
    {
        private IMongoDatabase _database;
        private ITaskFactory taskFactory;
        public TaskDataOperations(MongoDBService mondoDBService,ITaskFactory taskFactory)
        {
            _database = mondoDBService.GetDatabase();
            this.taskFactory = taskFactory;

        }

        public ATask GetTaskById(int id)
        {
            var collection = _database.GetCollection<BsonDocument>("Task");

            
            // Build a filter to find documents with the specified task_id
            var filter = Builders<BsonDocument>.Filter.Eq("task_id", id);

            // Use the filter to find the document(s) matching the criteria
            var result = collection.Find(filter).ToList();
            var firstDocument = result.FirstOrDefault();
            string sampleInput = "";
            ATask task = null;
            if (firstDocument["type"] == "personal")
            {
                sampleInput = $"{firstDocument["description"]},{firstDocument["date"]},{firstDocument["priority"]}";
                task = taskFactory.CreateTask("personal",sampleInput);
            }
            else
            {
                sampleInput = $"{firstDocument["description"]},{firstDocument["date"]},{firstDocument["project"]},{firstDocument["status"]},{firstDocument["priority"]}";
                task = taskFactory.CreateTask("official", sampleInput);
            }
            
            return task;
        }

        

        public List<ATask> GetTasksByDate(string date)
        {
            var collection = _database.GetCollection<BsonDocument>("Task");


            // Build a filter to find documents with the specified task_id
            var filter = Builders<BsonDocument>.Filter.Eq("date", date);

            // Use the filter to find the document(s) matching the criteria
            var result = collection.Find(filter).ToList();
            
            ATask task = null;
            string sampleInput ;
            List<ATask> tasks = new List<ATask>();
            
            foreach (var document in result) {
                sampleInput = "";
                if (document["type"] == "personal")
            {
                sampleInput = $"{document["description"]},{document["date"]},{document["priority"]}";
                task = taskFactory.CreateTask("personal", sampleInput);

            }
            else
            {
                sampleInput = $"{document["description"]},{document["date"]},{document["project"]},{document["status"]},{document["priority"]}";
                task = taskFactory.CreateTask("official", sampleInput);
            }
                tasks.Add(task);
            }

            return tasks;
        }

        

        public void SaveData(ATask task)
        {
            var collection = _database.GetCollection<BsonDocument>("Task");

            var document = new BsonDocument
        {
            { "description", task.Description },
            { "date", task.Date },
            { "priority", task.Priority },
            { "task_id", task.Task_id},
            {"completed", task.Completed },
            {"type",task.Type},
           
        };
            if (task is AOfficialTask temp_task)
            {
                document.Add( "status",temp_task.Status);
                document.Add("project", temp_task.Project);
            }

            try
            {
                collection.InsertOne(document);
                Console.WriteLine("Document inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
