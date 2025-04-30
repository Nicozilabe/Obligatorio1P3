using LogicaNegocio.EntidadesDominio.Acciones;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.ValueObjects.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.EF
{
    public class EmpresaContext:DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<AccionAdministracion> AccionesAdministracion { get; set; }



        public EmpresaContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // opcional, pero recomendado

            modelBuilder.Entity<Usuario>()
            .Property(u => u.Email)
            .HasConversion(
            email => email.Email,
            Email => new UsuarioEmail(Email)
            );

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();


            modelBuilder.Entity<AccionAdministracion>()
                .HasOne(a => a.Afectado)
                .WithMany()
                .HasForeignKey(a => a.AfectadoId)
                .OnDelete(DeleteBehavior.SetNull); // puede quedar

            modelBuilder.Entity<AccionAdministracion>()
                .HasOne(a => a.Realizador)
                .WithMany()
                .HasForeignKey(a => a.RealizadorId)
                .OnDelete(DeleteBehavior.NoAction); // o .Restrict
        }

    }
}
