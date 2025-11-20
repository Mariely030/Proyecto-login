
using SVE.IOC;
using Microsoft.EntityFrameworkCore;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;
using SVE.Application.Interfaces;
using SVE.Application.Services;
using SVE.Persistence.Repositories;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Services.Network;
using SVE.Application.Contracts.Repositories.Network;


var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con MySQL
builder.Services.AddDbContext<SVEContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 0, 1))
    )
);

// Registrar servicios con vistas
builder.Services.AddControllersWithViews();

// Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Productos
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

// Pedidos
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// DetallePedidos
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IDetallePedidoService, DetallePedidoService>();

// Promociones
builder.Services.AddScoped<IPromocionRepository, PromocionRepository>();
builder.Services.AddScoped<IPromocionService, PromocionService>();

builder.Services.AddScoped<INetworkProviderService, NetworkProviderService>();
builder.Services.AddScoped<INetworkProviderRepository, NetworkProviderRepository>();

builder.Services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();
builder.Services.AddScoped<INetworkTypeService, NetworkTypeService>();

// Si quieres mantener tus métodos IOC, puedes dejarlos también
builder.Services.AddUsuarioDependencies();
builder.Services.AddProductoDependencies();
builder.Services.AddPedidoDependencies();
builder.Services.AddDetallePedidoDependencies();
builder.Services.AddPromocionDependencies();

// Swagger (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline de la app
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();



