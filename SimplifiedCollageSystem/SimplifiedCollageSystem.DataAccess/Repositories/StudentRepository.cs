using SimplifiedCollageSystem.DomainModels;
using System.Collections.Generic;

namespace SimplifiedCollageSystem.DataAccess.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly CollageDBContext _context;

        public StudentRepository(CollageDBContext context)
        {
            _context = context;
        }




        public IEnumerable<Student> GetAll()
        {
            return _context.Students;
        }

        public void Insert(Student entity)
        {
            _context.Students.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Student entity)
        {
            _context.Students.Remove(entity);
            _context.SaveChanges();

        }

        public void Update(Student entity)
        {
            _context.Students.Update(entity);
            _context.SaveChanges();

        }
    }
}
