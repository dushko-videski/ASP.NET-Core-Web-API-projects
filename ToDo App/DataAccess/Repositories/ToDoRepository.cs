using DomainModels;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class ToDoRepository : IRepository<ToDo>
    {
        private readonly ToDoDBContext _context;

        public ToDoRepository(ToDoDBContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _context.Tasks;
        }

        public void Insert(ToDo entity)
        {
            _context.Tasks.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(ToDo entity)
        {
            _context.Tasks.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ToDo entity)
        {
            _context.Tasks.Update(entity);
            _context.SaveChanges();
        }
    }
}
