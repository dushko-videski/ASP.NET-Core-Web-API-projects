﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DomainModels.Migrations
{
    [DbContext(typeof(ToDoDBContext))]
    partial class ToDoDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DomainModels.SubTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("SubTaskName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ToDoId");

                    b.HasKey("Id");

                    b.HasIndex("ToDoId");

                    b.ToTable("SubTask");

                    b.HasData(
                        new { Id = 1, IsCompleted = true, SubTaskName = "pushups", ToDoId = 1 },
                        new { Id = 2, IsCompleted = false, SubTaskName = "bench", ToDoId = 1 },
                        new { Id = 3, IsCompleted = true, SubTaskName = "arms", ToDoId = 1 },
                        new { Id = 4, IsCompleted = true, SubTaskName = "swagger", ToDoId = 2 },
                        new { Id = 5, IsCompleted = false, SubTaskName = "postman", ToDoId = 2 },
                        new { Id = 6, IsCompleted = true, SubTaskName = "attend a meeting", ToDoId = 3 },
                        new { Id = 7, IsCompleted = false, SubTaskName = "read the e-mail", ToDoId = 3 },
                        new { Id = 8, IsCompleted = true, SubTaskName = "take a lunch brae at noon", ToDoId = 3 }
                    );
                });

            modelBuilder.Entity("DomainModels.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCompleted");

                    b.Property<string>("TaskDescription");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Task");

                    b.HasData(
                        new { Id = 1, IsCompleted = true, TaskDescription = "regular exercise", TaskName = "exercise", UserId = 1 },
                        new { Id = 2, IsCompleted = false, TaskDescription = "webapi", TaskName = "study", UserId = 2 },
                        new { Id = 3, IsCompleted = false, TaskDescription = "first shift", TaskName = "go to work", UserId = 1 }
                    );
                });

            modelBuilder.Entity("DomainModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, Firstname = "Dushko", Lastname = "Videski", Password = "??9I?Y??V?W??>", Username = "dusvid01" },
                        new { Id = 2, Firstname = "Ilija", Lastname = "Pecevski", Password = "???&s?x?m?uH]?", Username = "ilipec01" }
                    );
                });

            modelBuilder.Entity("DomainModels.SubTask", b =>
                {
                    b.HasOne("DomainModels.ToDo", "ToDo")
                        .WithMany("SubTasks")
                        .HasForeignKey("ToDoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DomainModels.ToDo", b =>
                {
                    b.HasOne("DomainModels.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
