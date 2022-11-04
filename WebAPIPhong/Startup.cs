using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebAPIPhong.DbContext;
using WebAPIPhong.Extensions;
using WebAPIPhong.Middleware;
using WebAPIPhong.Services;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            Configuration = InitConfiguration(env);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddDatabaseDeveloperPageExceptionFilter();
            services
                .AddDataBase()
                .AddServices()
                .AddSwaggerGen()
                .AddMapping();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIPhong v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandleMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private IConfiguration InitConfiguration(IWebHostEnvironment env)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables().Build();

            // mapping AppSettings section in appsettings.json file value to AppSettings model
            configuration.GetSection("AppSettings").Get<AppSettings>(options => options.BindNonPublicProperties = true);
            return configuration;
        }
    }
}