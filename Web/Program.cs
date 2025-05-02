using CasosDeUso.InterfacesCasosUso;
using LogicaAccesoADatos.EF;
using LogicaAccesoADatos.Repos;
using LogicaAplicacion.CasosUsoConcretos.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Mine
            builder.Services.AddSession();


            //Inyecciones
            builder.Services.AddScoped<IRepositorioEmpleados, RepositorioEmpleados>();
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
            builder.Services.AddScoped<IRepositorioAcciones, RepositorioAcciones>();
            builder.Services.AddScoped<ILogin, Login>();
            builder.Services.AddScoped<IRegistroEmpleado, RegistroEmpleado>();
            builder.Services.AddScoped<IListarEmpleados, ListarEmpleados>();
            builder.Services.AddScoped<IObtenerEmpleado, ObtenerEmpleado>();
            builder.Services.AddScoped<IEditarEmpleado, EditarEmpleado>();
            builder.Services.AddScoped<IBajaEmpleado, BajaEmpleado>();

            //DB
            builder.Services.AddDbContext<EmpresaContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Empresa"),
                    sql => sql.EnableRetryOnFailure()
                )
            );

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

            //Mine
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
