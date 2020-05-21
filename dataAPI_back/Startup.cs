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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using dataAPI_back.Models;

namespace dataAPI_back
{
    public class Startup
    {
        private string _connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // user secrets
            _connectionString = Configuration["secretConnectionString"];

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddEntityFrameworkNpgsql().AddDbContext<ApiContext>(
                opt => opt.UseNpgsql(_connectionString));    

            // call DataSeed during Startup
            // only one time
            // transient instance og a service
            services.AddTransient<DataSeed>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seedData)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // pass number of clients, and number of orders -> random data
            var nClients = 20;
            var nOrders = 1000;
            seedData.SeedData(nClients, nOrders);

            app.UseHttpsRedirection();
            // app.UseMvc();
            
            // routes customization
            // lambda expression -> template to the route
            app.UseMvc(routes => routes.MapRoute(
                // url estructure
                "default", "api/{controller}/{action}/{id?}"
            ));

            
        }
    }
}
