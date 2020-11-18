using Microsoft.EntityFrameworkCore;

namespace SimplifiedCollageSystem.DomainModels
{
    public class CollageDBContext : DbContext
    {
        public CollageDBContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student
            modelBuilder
                .Entity<Student>()
                .ToTable("Students")
                .HasKey(st => st.StudentNumber);

            //Subject
            modelBuilder
                .Entity<Subject>()
                .ToTable("Subjects")
                .HasKey(su => su.Name);

            //relations
            modelBuilder
                .Entity<Subject>()
                .HasOne(su => su.Student)
                .WithMany(st => st.Subjects)
                .HasForeignKey(su => su.StudentId);


            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Student>()
                .HasData(
                new Student()
                {
                    StudentNumber = 1,
                    FullName = "Dushko Videski",
                    EmailAddress = "dushko.videski@gmail.com",
                    MobilePhone = "+38971252980"
                });


            modelBuilder
                .Entity<Subject>()
                .HasData(
                 new Subject()
                 {
                     Name = "Math",
                     Credits = 170,
                     Semestar = 1,
                     StudentId = 1
                 },
                 new Subject()
                 {
                     Name = "History",
                     Credits = 200,
                     Semestar = 2,
                     StudentId = 1
                 });
        }
    }
}
