using LogicaNegocio.EntidadesDominio.Usuarios;
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
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"SERVER=(localdb)\MSSQLLocalDB; Initial Catalog = EmpresaV1; Integrated Security = True;");

        }
    }
}
