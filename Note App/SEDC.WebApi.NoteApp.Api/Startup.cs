using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SEDC.WebApi.NoteApp.Models.SettingsModels;
using SEDC.WebApi.NoteApp.Services;
using SEDC.WebApi.NoteApp.Services.Helpers;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System.Text;

namespace SEDC.WebApi.NoteApp.Api
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });


            // get connection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            // register data access dependencies
            DiModule.RegisterModule(services, connectionString);

            // service registration
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INoteService, NoteService>();

            var jwtSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSection);
            var jwtSettings = jwtSection.Get<JwtSettings>();

            var secret = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            services.AddAuthentication(
                x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secret),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //SWAGER:
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "V1";
                    document.Info.Title = "Booking Airplane Tickets App";
                    document.Info.Description = "Nebb-Four Solutions Interview Coding Assignment";
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
            app.UseAuthentication();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
