using LogicaNegocio.EntidadesDominio.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Acciones
{
    public abstract class Accion
    {
        public int Id { get; set; }
        public Empleado Realizador { get; set; }
    }
}
