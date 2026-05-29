using PC1.CORE.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// DbContext and DI for services/repositories
builder.Services.AddDbContext<PC1.CORE.Infrastructure.Data.TallerMecanicoDbContext>();
builder.Services.AddScoped<PC1.CORE.Core.Interface.IOrdenServicioRepository, PC1.CORE.Infrastructure.Repositories.OrdenServicioRepository>();
builder.Services.AddScoped<PC1.CORE.Core.Interface.IOrdenServicioService, PC1.CORE.Infrastructure.Services.OrdenServicioService>();

// Register DbContext
builder.Services.AddDbContext<TallerMecanicoDbContext>();

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
