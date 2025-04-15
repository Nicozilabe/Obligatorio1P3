using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Acciones
{
    public abstract class Accion
    {
        public int Id { get; set; }
        public FechaAccion Fecha { get; set; }

        public Accion() { }

        public Accion( FechaAccion fecha)
        {
            Fecha = fecha;
        }
    }
}
