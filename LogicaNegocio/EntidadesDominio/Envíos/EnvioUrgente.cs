using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public class EnvioUrgente:Envio
    {
        public DireccionPostal Direccion { get; set; }
        public bool EnvioEficiente { get; set; }

        public EnvioUrgente() { }

        public EnvioUrgente(Empleado empleadoResponable, string cliente, double peso, TipoEstadoEnvio estadoEnvio, TipoSeguimiento seguimiento, DireccionPostal direccion) : base(empleadoResponable, cliente, peso, estadoEnvio, seguimiento)
        {
            Direccion = direccion;
        }

        }
    }
}
