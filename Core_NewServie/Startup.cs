using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Core_NewServie.Models;
using Microsoft.EntityFrameworkCore;
using Core_NewServie.Services;
using Core_NewServie.CustomMiddleware;
namespace Core_NewServie
{
    public class Startup
    {
        /// <summary>
        /// IConfiguration: Contract interface used to read application configurations
        /// from appsetings.json
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        ///This method is invoked by HostBuilder imediately after the ctor 
        /// IServiceCollection: Contract used to register all depednencies
        /// This method provides a DI COntainer to register all services
        /// using 'ServiceDescriptor' class
        /// Singleton, register an instance at application level (Global)
        /// and only one instance is availbale throught the app  
        /// Scoped:, register an instance in DI, but for each new session the new instance
        /// is created and injected in verious classes
        /// Transient, register an instance in DI, but for every new request
        /// new instance is created and injected
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // define the Registration of DbContext in DI COntainer
            // pass the ConnectionString to be used
            // by default 128 connection in ObjectPool
            // default is Scopped instances
            services.AddDbContext<CompanyDbContext>(options=> {
                // read the connection string from appsettings.json
                options.UseSqlServer(Configuration.GetConnectionString("CompanyConnection"));
            });

            // enable service for CORS
            services.AddCors(policy=> {
                policy.AddPolicy("corspolicy", options =>
                {
                    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                     
                });
            });

            // register services in DI Container
            // IMPORTANT: Decide the Object Instantiation wisely

            services.AddScoped<IService<Department,int>, DepartmentService>();
            services.AddScoped<IService<Employee, int>, EmployeeService>();

            // MVC and Views + API Controllers 
            // services.AddControllersWithViews();
            // for Razor WebForms
          //  services.AddRazorPages();

            // The method for handling request for API Controllers in the Application
            // enable Pascal Case or serialze the Entity class in
            // original property names in JSON
            services.AddControllers().AddJsonOptions(options => {
                // disable the property namping policy so that Entity class
                // properties will be JSON serialized in
                // original property names
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Configure the CORS policy for the curret application
            app.UseCors("corspolicy");



            app.UseRouting();

            app.UseAuthorization();


            // the custom middlewares
            app.UseCustomException();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
