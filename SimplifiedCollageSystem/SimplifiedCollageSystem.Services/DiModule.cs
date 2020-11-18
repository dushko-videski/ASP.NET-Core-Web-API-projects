using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplifiedCollageSystem.DataAccess;
using SimplifiedCollageSystem.DataAccess.Repositories;
using SimplifiedCollageSystem.DomainModels;

namespace SimplifiedCollageSystem.Services
{
    public static class DiModule
    {

        public static IServiceCollection Register(IServiceCollection services, string connectionString)
        {

            //registering DB CONTEXT
            services.AddDbContext<CollageDBContext>(x => x.UseSqlServer(connectionString));

            //register REPOSITORIES
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IRepository<Subject>, SubjectRepository>();


            return services;

        }



    }
}
