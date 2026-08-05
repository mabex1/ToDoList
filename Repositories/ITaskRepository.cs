using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface ITaskRepository
    {
        List<TaskModel> GetAll();
        TaskModel? GetById(int id);
        TaskModel AddTask(string title);
        bool RemoveTask(int id);
        TaskModel? MarkFinished(int id);
    }
}
