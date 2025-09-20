using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TaskRepository : IRepository<TaskItem>
    {
        private readonly FileDatabase<TaskItem> _db;

        public TaskRepository(string filePath)
        {
            _db = new FileDatabase<TaskItem>(filePath);
        }

        public void Add(TaskItem task)
        {
            var tasks = _db.Load().ToList();
            tasks.Add(task);
            _db.SaveChanges(tasks);
        }

        public void Delete(Guid id)
        {
            var tasks = _db.Load().ToList();
            tasks.RemoveAll(t => t.TaskId == id);
            _db.SaveChanges(tasks);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _db.Load();
        }

        public TaskItem GetById(Guid id)
        {
            return _db.Load().FirstOrDefault(t => t.TaskId == id);
        }

        public void Update(TaskItem task)
        {
            var tasks = _db.Load().ToList();

            var index = tasks.FindIndex(t => t.TaskId == task.TaskId);

            if (index != null)
            {
                tasks[index] = task;
                _db.SaveChanges(tasks);
            }
        }
    }
}
