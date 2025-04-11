using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public abstract class Envio
    {
        public int Id { get; set; }
        public int Tracking { get; set; }
        public Empleado EmpleadoResponable { get; set; }
        public Cliente Cliente { get; set; }
        public double Peso { get; set; }
        public TipoEstadoEnvio EstadoEnvio { get; set; }
        public TipoSeguimiento Seguimiento { get; set; }
    }
}
