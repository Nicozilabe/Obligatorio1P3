using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public class EnvioComun:Envio
    {
        public Agencia Agencia { get; set; }

        public EnvioComun( Empleado empleadoResponable, string cliente, double peso, TipoEstadoEnvio estadoEnvio, TipoSeguimiento seguimiento, Agencia agencia):base( empleadoResponable,  cliente,  peso,  estadoEnvio,  seguimiento)
        {
            Agencia = agencia;
        }

        public EnvioComun() { }
    }
}
