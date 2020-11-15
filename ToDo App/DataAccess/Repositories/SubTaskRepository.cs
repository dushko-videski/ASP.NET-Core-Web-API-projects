using DomainModels;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class SubTaskRepository : IRepository<SubTask>
    {
        private readonly ToDoDBContext _context;

        public SubTaskRepository(ToDoDBContext context)
        {
            _context = context;
        }


        public IEnumerable<SubTask> GetAll()
        {
            return _context.SubTasks;
        }

        public void Insert(SubTask entity)
        {
            _context.SubTasks.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(SubTask entity)
        {
            _context.SubTasks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(SubTask entity)
        {
            _context.SubTasks.Update(entity);
            _context.SaveChanges();
        }

    }
}
