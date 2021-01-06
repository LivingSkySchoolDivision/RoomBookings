using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingSky.RoomBookings;
using LivingSky.RoomBookings.Rooms;
using LivingSky.RoomBookings.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace RoomBookings.API
{
    public class Startup
    {
        private bool HostedInContainer => Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

        public Startup(IConfiguration configuration)
        {
            Configuration = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RoomBookings.API", Version = "v1" });
            });
            
            services.AddScoped<MongoDbConnection>();
            services.AddScoped<IRepository<Room>, MongoRepository<Room>>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomBookings.API v1"));

            if (HostedInContainer)
            {
                Console.WriteLine("We appear to be running in a container");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Open");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
