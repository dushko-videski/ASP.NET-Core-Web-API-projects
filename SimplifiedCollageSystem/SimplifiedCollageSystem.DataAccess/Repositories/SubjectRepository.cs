using SimplifiedCollageSystem.DomainModels;
using System.Collections.Generic;

namespace SimplifiedCollageSystem.DataAccess.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private readonly CollageDBContext _context;

        public SubjectRepository(CollageDBContext context)
        {
            _context = context;
        }




        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects;
        }

        public void Insert(Subject entity)
        {
            _context.Subjects.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(Subject entity)
        {
            _context.Subjects.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Subject entity)
        {
            _context.Subjects.Update(entity);
            _context.SaveChanges();
        }
    }
}
