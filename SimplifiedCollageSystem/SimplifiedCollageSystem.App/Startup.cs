using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimplifiedCollageSystem.Services;
using SimplifiedCollageSystem.Services.Interfaces;

namespace SimplifiedCollageSystem.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }




        public void ConfigureServices(IServiceCollection services)
        {
            // CORS
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // get the connection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // DB CONTEXT and REPOSITORIES registration
            DiModule.Register(services, connectionString);


            // SERVICES registration
            services.AddTransient<IStudentService, StudentService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //SWAGER:
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "V1";
                    document.Info.Title = "Polar Cape test assignment";
                    document.Info.Description = "Simplified Collage System App";
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

            app.UseCors("CorsPolicy");

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
