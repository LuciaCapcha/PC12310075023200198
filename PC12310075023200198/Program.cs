using PC1.CORE.Infrastructure.Data;
using PC1.CORE.Core.Interface;
using PC1.CORE.Infrastructure.Repositories;
using PC1.CORE.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// DbContext and DI for services/repositories
builder.Services.AddDbContext<TallerMecanicoDbContext>();
builder.Services.AddScoped<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddScoped<IOrdenServicioService, OrdenServicioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
