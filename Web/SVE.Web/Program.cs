
using SVE.IOC;
using Microsoft.EntityFrameworkCore;
using SVE.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SVEContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 0, 1))
    )
);

builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<INetworkProviderApi, NetworkProviderApi>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5291/");
});

builder.Services.AddHttpClient<INetworkTypeApi, NetworkTypeApi>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5291/");
});


builder.Services.AddUsuarioDependencies();
builder.Services.AddProductoDependencies();
builder.Services.AddPedidoDependencies();
builder.Services.AddDetallePedidoDependencies();
builder.Services.AddPromocionDependencies();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Index}/{id?}");

app.Run();




