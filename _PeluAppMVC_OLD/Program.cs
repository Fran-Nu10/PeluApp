using LogicaAccesoDatos.RepositoriosEF;

using LogicaAplicacion.CasosDeUso.CUAdministrador;

using LogicaAplicacion.CasosDeUso.CUCita;
using LogicaAplicacion.CasosDeUso.CUCliente;
using LogicaAplicacion.CasosDeUso.CUEmpleado;
using LogicaAplicacion.CasosDeUso.CUServicio;
using LogicaAplicacion.CasosDeUso.CUUsuario;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using LogicaAplicacion.InterfacesCU.ICUUsuario;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using Microsoft.EntityFrameworkCore;

namespace PeluAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSession(); //agrego esto para session

            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");//DefaultConnection debe coincidir con el nombre designado en el JSON.

            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));



            // Registrar servicios CORS
            builder.Services.AddCors(options =>
            { 
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()      // Permitir cualquier origen
                        .AllowAnyMethod()       // Permitir cualquier método (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader();     // Permitir cualquier encabezado
                });
            });

            //INYECION DE DEPENDENCIAS

            //REPOSITORIOS



            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //REPOSITORIO CLIENTE
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();

            //REPOSITORIO USUARIO
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            //REPOSITORIO ADMINISTRADOR
            builder.Services.AddScoped<IRepositorioAdministrador, RepositorioAdministrador>();

            //REPOSITORIO CITA
            builder.Services.AddScoped<IRepositorioCita, RepositorioCita>();

            //REPOSITORIO EMPLEADO
            builder.Services.AddScoped<IRepositorioEmpleado, RepositorioEmpleado>();

            //REPOSITORIO SERVICIOS
            builder.Services.AddScoped<IRepositorioServicio, RepositorioServicio>();


            //CASO DE USOS


            //CASO DE USO CLIENTE
            builder.Services.AddScoped<ICURegistrarCliente, CURegistrarCliente>();

            builder.Services.AddScoped<ICUMostrarServicios, CUMostrarServicios>();


            //CASO DE USO LOGIN
            builder.Services.AddScoped<ICULogin, CULogin>();

            //CASO DE USO ADMINISTRADOR
            builder.Services.AddScoped<ICUGestionDeClientes, CUGestionDeClientes>();

            //REPOSITORIO CITA
            builder.Services.AddScoped<ICUCitas, CUHistorialDeCitas>();

            builder.Services.AddScoped<ICUAgendarCitas, CUAgendarCitas>();

            builder.Services.AddScoped<ICUGestionDeEmpleados, CUGestionDeEmpleados>();

            builder.Services.AddScoped<ICUGestionDeServicios, CUGestionDeServicios>();

            //USUARIO
            builder.Services.AddScoped<ICUGestionDeUsuarios, CUGestionDeUsuarios>();


            var app = builder.Build();

            app.UseCors("AllowAllOrigins");  // Aplica la política de CORS

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
            app.UseSession();   //agrego esto para session
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
