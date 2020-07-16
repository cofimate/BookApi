using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BooksApiProject.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BooksApiProject
{
    public class Startup
    {
        public static IConfiguration Configuration {get;set;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddHttpClient();
            //services.AddControllers();
            services.AddMvc();

            /// enable MVC routing 
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.MvcOptions.EnableEndpointRouting = false;
            //services.AddMvc(option => option.RequireHttpsPermanent = true);
            
            // accept the header on request
            services.AddMvc(option => option.RespectBrowserAcceptHeader = true);
            //serrvices.AddControllersWithViews().AddJsonOptions( o => o.JsonSerializerOptions.
                
                //AddNewtonsoftJson(options =>
                //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddHttpClient();


            var connectionString = Configuration["connectionStrings:bookDbConnectionString"];
            services.AddDbContext<BookDbContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICathegoryRepository, CathegoryRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //this one is to call the seeding one time to provide the database
            //context.SeedDataContext();
            

            //use MVC to the request execution pipeline
            app.UseMvc();

        }
    }
}
