using DomainModels;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ToDoDBContext _context;

        public UserRepository(ToDoDBContext context)
        {
            _context = context;
        }


        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
