using CasosDeUso.InterfacesCasosUso;
using LogicaAccesoADatos.EF;
using LogicaAccesoADatos.Repos;
using LogicaAplicacion.CasosUsoConcretos;
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

            //Inyecciones
            builder.Services.AddScoped<IRepositorioEmpleados, RepositorioEmpleados>();
            builder.Services.AddScoped<ILogin, Login>();

            //DB
            builder.Services.AddDbContext<EmpresaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Empresa")));

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
