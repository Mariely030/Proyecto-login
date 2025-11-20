
using SVE.IOC;
using Microsoft.EntityFrameworkCore;
using SVE.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SVEContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))
    ));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddUsuarioDependencies();
builder.Services.AddPedidoDependencies();
builder.Services.AddDetallePedidoDependencies();
builder.Services.AddProductoDependencies();
builder.Services.AddPromocionDependencies();
builder.Services.AddNetworkTypeDependencies();

builder.Services.AddControllers();

var app = builder.Build();

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

