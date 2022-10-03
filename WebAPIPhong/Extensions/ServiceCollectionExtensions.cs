using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebAPIPhong.DbContext;
using WebAPIPhong.Services;
using WebAPIPhong.Services.IServices;

namespace WebAPIPhong.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(AppSettings.ConnectionStrings));

            return service;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IJwtUtils, JwtUtils>();

            return services;
        }
        
        public static IServiceCollection AddSwaggerGen(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "WebAPIPhong", Version = "v1" });
            });

            return service;
        }
        
        public static IServiceCollection AddMapping(this IServiceCollection service)
        {
            // mapping configuration
            var mapper = MappingConfig.RegisterMap().CreateMapper();
            service.AddSingleton(mapper);
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return service;
        }
        
        
    }
}