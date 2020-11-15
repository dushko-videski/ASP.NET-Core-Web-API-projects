using DataAccess;
using DataAccess.Repositories;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Services
{
    public static class DiModule
    {

        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {
            // registering DB CONTEXT
            services.AddDbContext<ToDoDBContext>(x => x.UseSqlServer(connectionString));

            // register REPOSITORIES
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<ToDo>, ToDoRepository>();
            services.AddTransient<IRepository<SubTask>, SubTaskRepository>();

            //register SERVICES
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IToDoService, ToDoService>();

            return services;
        }


    }
}
