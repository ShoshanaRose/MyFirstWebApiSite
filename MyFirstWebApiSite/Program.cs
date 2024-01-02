using Entities;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite.Middlewares;
using NLog.Web;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

//public IConfiguration
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, userRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductrepository, Productrepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IRaitingRepository, RaitingRepository>();
builder.Services.AddTransient<IRaitingService, RaitigService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseNLog();

builder.Services.AddDbContext<MyshopWebApiContext>(option => option.UseSqlServer(builder.Configuration["ConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseErrorHandlingMiddleware();

app.UseRatingMiddleware();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
