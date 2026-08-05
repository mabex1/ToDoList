using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Repositories
{
    public class PostgresTaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public PostgresTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskModel> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskModel? GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskModel AddTask(string title)
        {
            var task = new TaskModel
            {
                TaskName = title,
                IsTaskFinished = false
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public bool RemoveTask(int id)
        {
            var task = GetById(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }

        public TaskModel? MarkFinished(int id)
        {
            var task = GetById(id);
            if (task == null) return null;

            task.IsTaskFinished = !task.IsTaskFinished;
            _context.SaveChanges();
            return task;
        }
    }
}
