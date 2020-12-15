using FluentValidation.AspNetCore;
using HealthClinic.CL.DbContextModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientWebApplication.Validators;
using System;

namespace PatientWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


       /* private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "demo";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";


            return $"server={server};port={port};database={database};user={user};password={password};";
        }*/

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            })
           .AddFluentValidation(options =>
           {
               options.RegisterValidatorsFromAssemblyContaining<Startup>();
           });

            

            services.AddDbContext<MyDbContext>(options =>
            options.UseMySql(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")).UseLazyLoadingProxies());

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,DbContext db)
        {
            db.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
