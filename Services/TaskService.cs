using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using WebApplication2.Models;
namespace WebApplication2.Services
{
    public class TaskService
    {
        public TaskService()
        {
            if (File.Exists("tasks.json"))
            {
                string json = File.ReadAllText("tasks.json");
                _tasks = JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
                _nextid = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            }
        }

        private static List<TaskModel> _tasks = new List<TaskModel>();
        private static int _nextid = 1;

        public List<TaskModel> GetAll() => _tasks;

        public TaskModel? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public TaskModel AddTask(string title)
        {
            var task = new TaskModel(title, _nextid, false);

            _tasks.Add(task);
            _nextid++;
            SaveToFile();
            return task;
        }

        public bool RemoveTask(int id)
        {
            var taskId = GetById(id);
            if(taskId == null)
            {
                return false;
            }
            _tasks.Remove(taskId);
            SaveToFile();
            return true;
        }

        public TaskModel? MarkFinished(int id)
        {
            var task = GetById(id);
            if (task == null)
            {
                return null;
            }

            if(task.IsTaskFinished == true)
            {
                task.IsTaskFinished = false;
            }
            else
            {
                task.IsTaskFinished = true;
            }
            SaveToFile();
            return task;
        }

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(_tasks);
            File.WriteAllText("tasks.json", json);
        }
    }
}
