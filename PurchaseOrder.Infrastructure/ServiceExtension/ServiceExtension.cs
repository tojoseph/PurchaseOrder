using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurchaseOrder.Core.Interfaces;
using PurchaseOrder.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PurchaseOrder.Core.Models;

namespace PurchaseOrder.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            //Resolve repository dependancy 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            services.AddScoped<ICustomerScubscriptionRepository, CustomerScubscriptionRepository>();
            
            //Resolve Validators Model classes dependancy 
            services.AddScoped<IValidator<OrderViewModel>, OrderViewModelValidator>();
            services.AddScoped<IValidator<OrderItemsModel>, OrderItemsModelValidator>();



            return services;
        }
    }
}
