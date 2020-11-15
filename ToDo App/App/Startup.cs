using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // get the connection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // register DB CONTEXT (DataAccess dependencies)
            DiModule.Register(services, connectionString);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //SWAGER:
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "V1";
                    document.Info.Title = "Homework-WebAPI: ToDo App";
                    document.Info.Description = "My First WebAPI App";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Dushko Videski",
                        Email = "dushko.videski@gmail.com"
                    };
                };
            });


        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
