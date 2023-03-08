using AutoMapper;
using FluentValidation.AspNetCore;
using PurchaseOrder.API.Extensions;
using PurchaseOrder.API.Middleware;
using PurchaseOrder.Infrastructure.ServiceExtension;
using PurchaseOrder.Services;
using PurchaseOrder.Services.Interfaces;
using Serilog;
using FluentValidation.AspNetCore;
using System.Reflection;
using FluentValidation;
using PurchaseOrder.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog.Events;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .WriteTo.CustomSink()
        .Enrich.FromLogContext()
        .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddDIServices(builder.Configuration);

builder.Services.AddScoped<IValidator<OrderViewModel>, OrderViewModelValidator>();
builder.Services.AddScoped<IValidator<OrderItemsModel>, OrderItemsModelValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<OrderViewModel>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<OrderItemsModel>(ServiceLifetime.Transient);
builder.Services.AddValidatorsFromAssemblyContaining<ProductDetailsModel>(ServiceLifetime.Transient);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

var automapper = new MapperConfiguration(item => item.AddProfile(new MappingProfile()));
IMapper mapper = automapper.CreateMapper();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.WithMethods("GET", "POST", "DELETE", "PUT");
        policy.AllowAnyHeader(); // <--- list the allowed headers here
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddSingleton(mapper);
builder.Services.AddControllers().AddFluentValidation(options =>
                 {
                     // Validate child properties and root collection elements
                     options.ImplicitlyValidateChildProperties = true;
                     options.ImplicitlyValidateRootCollectionElements = true;

                     // Automatic registration of validators in assembly
                     options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                 });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(string.Format(@"{0}\PurchaseOrder.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Books & Video Shop API",
    });

});

var app = builder.Build();
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
