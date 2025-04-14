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
        public DbSet<Empleado> Empleados { get; set; }

        public EmpresaContext(DbContextOptions options): base(options) { }
        
    }
}
