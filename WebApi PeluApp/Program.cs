using LogicaAplicacion.InterfacesCU;

using Microsoft.OpenApi.Models;
using LogicaAplicacion.CasosDeUso.CUAdministrador;
using LogicaAplicacion.CasosDeUso.CUEmpleado;
using LogicaAplicacion.CasosDeUso.CUServicio;
using LogicaAplicacion.InterfacesCU.ICUAdministrador;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAccesoDatos.RepositoriosEF;
using Microsoft.EntityFrameworkCore;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using ICUGestionDeServicios = LogicaAplicacion.InterfacesCU.ICUServicio.ICUGestionDeServicios;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using LogicaNegocio.InterfacesRepositorios.InterfacesAPI;
using LogicaAccesoDatos.RepositoriosEF_API;
using LogicaAccesoDatos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


// 🔹 REGISTRAR REPOSITORIOS (INTERFACES -> IMPLEMENTACIONES)
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioServicio, RepositorioServicio>();
builder.Services.AddScoped<IRepositorioEmpleado, RepositorioEmpleado>();
builder.Services.AddScoped<IRepositorioClienteAPI, RepositorioClienteAPI>();


// 🔹 REGISTRAR CASOS DE USO (INTERFACES -> IMPLEMENTACIONES)
builder.Services.AddScoped<ICUGestionDeClientes, CUGestionDeClientes>();
builder.Services.AddScoped<ICUGestionDeServicios, CUGestionDeServicios>();
builder.Services.AddScoped<ICUGestionDeEmpleados, CUGestionDeEmpleados>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Asegurar que responde a controladores

app.Run();
