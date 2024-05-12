using appWeb.BLL.Services;
using appWeb.BLL.Services.Contracts;
using appWeb.DAL.DataContext;
using appWeb.DAL.Repositories;
using appWeb.DAL.Repositories.Contracts;
using appWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbTienda2Context>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repostories
builder.Services.AddScoped<IGenericRepository<Producto>, ProductoRepository>();

//Services
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
