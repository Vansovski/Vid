using Microsoft.EntityFrameworkCore;
using Vidly.App;
using Vidly.App.Contratos;
using Vidly.Data;
using Vidly.Data.Persistence;
using Vidly.Data.Persistence.Contratos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DataContext>(
    context=> context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);


// Add services to the container.
builder.Services.AddControllersWithViews();

//Serviço do Cliente / Injeção de Dependica
builder.Services.AddScoped<IGeneralPersistence,GeneralPersistence>(); //Context

builder.Services.AddScoped<IClientePersistence,ClientePersistence>();//Serviços Cliente
builder.Services.AddScoped<IClienteService,ClienteServicos>();//Serviços Cliente



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


/*
//Custom Rotas 
app.MapControllerRoute(
    "MoviesByReleaseDate",
    "movies/released/{year}/{month}",
    new { controller = "Movies", action = "ByReleaseDate"}
    );
*/
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}");


app.Run();
