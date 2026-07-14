namespace WebApplication2.Models
{
    public class TaskModel
    {
        public string TaskName { get; set; } = string.Empty;
        public int Id{ get; set; }
        public bool IsTaskFinished { get; set; }

        public TaskModel() { }
        public TaskModel(string taskName, int id, bool isTaskFinished)
        {
            TaskName = taskName;
            Id = id;
            IsTaskFinished = isTaskFinished;
        }
    }
}
