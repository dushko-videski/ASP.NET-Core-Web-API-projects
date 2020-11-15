using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DomainModels
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions options)
            : base(options)
        {
        }
        //==============================================

        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        //=============================================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //------------------ USER ------------------
            modelBuilder
                .Entity<User>()
                .ToTable(nameof(User))
                .HasKey(u => u.Id);
            modelBuilder
                .Entity<User>()
                .Property(u => u.Username)
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder
                .Entity<User>()
                .Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();
            //----------------- ToDo --------------------
            modelBuilder
                .Entity<ToDo>()
                .ToTable("Task")
                .HasKey(t => t.Id);
            modelBuilder
                .Entity<ToDo>()
                .Property(t => t.TaskName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder
                .Entity<ToDo>()
                .Property(t => t.IsCompleted)
                .IsRequired();

            //--------------- SubTask ------------------
            modelBuilder
                .Entity<SubTask>()
                .ToTable(nameof(SubTask))
                .HasKey(s => s.Id);
            modelBuilder
                .Entity<SubTask>()
                .Property(s => s.SubTaskName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder
                .Entity<SubTask>()
                .Property(s => s.IsCompleted)
                .IsRequired();

            //------------- relations ------------------
            modelBuilder
                .Entity<ToDo>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);

            modelBuilder
                .Entity<SubTask>()
                .HasOne(s => s.ToDo)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(s => s.ToDoId);
            //=====================================

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
        //====================================================================

        //seeding
        public void Seed(ModelBuilder modelBuilder)
        {
            //hashing passwords:
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456"));
            var hashedPasswordU1 = Encoding.ASCII.GetString(md5data);

            var md6 = new MD5CryptoServiceProvider();
            var md6data = md6.ComputeHash(Encoding.ASCII.GetBytes("789abc"));
            var hashedPasswordU2 = Encoding.ASCII.GetString(md6data);
            //--------------------------------------------------------------

            modelBuilder
                .Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    Firstname = "Dushko",
                    Lastname = "Videski",
                    Username = "dusvid01",
                    Password = hashedPasswordU1
                },
                new User()
                {
                    Id = 2,
                    Firstname = "Ilija",
                    Lastname = "Pecevski",
                    Username = "ilipec01",
                    Password = hashedPasswordU2
                });
            //----------------------------------
            modelBuilder
                .Entity<ToDo>()
                .HasData(
                new ToDo()
                {
                    Id = 1,
                    TaskName = "exercise",
                    TaskDescription = "regular exercise",
                    IsCompleted = true,
                    UserId = 1,
                },
                new ToDo()
                {
                    Id = 2,
                    TaskName = "study",
                    TaskDescription = "webapi",
                    IsCompleted = false,
                    UserId = 2
                },
                new ToDo()
                {
                    Id = 3,
                    TaskName = "go to work",
                    TaskDescription = "first shift",
                    IsCompleted = false,
                    UserId = 1
                });
            //---------------------------------
            modelBuilder
                .Entity<SubTask>()
                .HasData(
                new SubTask()
                {
                    Id = 1,
                    SubTaskName = "pushups",
                    IsCompleted = true,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 2,
                    SubTaskName = "bench",
                    IsCompleted = false,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 3,
                    SubTaskName = "arms",
                    IsCompleted = true,
                    ToDoId = 1
                },
                new SubTask()
                {
                    Id = 4,
                    SubTaskName = "swagger",
                    IsCompleted = true,
                    ToDoId = 2
                },
                new SubTask()
                {
                    Id = 5,
                    SubTaskName = "postman",
                    IsCompleted = false,
                    ToDoId = 2
                },
                new SubTask()
                {
                    Id = 6,
                    SubTaskName = "attend a meeting",
                    IsCompleted = true,
                    ToDoId = 3
                },
                new SubTask()
                {
                    Id = 7,
                    SubTaskName = "read the e-mail",
                    IsCompleted = false,
                    ToDoId = 3
                },
                new SubTask()
                {
                    Id = 8,
                    SubTaskName = "take a lunch brae at noon",
                    IsCompleted = true,
                    ToDoId = 3
                });
        }
    }
}
