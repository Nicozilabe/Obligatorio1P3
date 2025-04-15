using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Acciones
{
    public class AccionEnvio : Accion
    {
        public Empleado Realizador { get; set; }
        public TipoAccionEnvio TipoAccion { get; set; }
        public Envio Envio { get; set; }
        public TipoComentarioEnvio ComentarioEnvio { get; set; }

        public AccionEnvio() { }

        public AccionEnvio(TipoAccionEnvio tipoAccion, Envio envio, TipoComentarioEnvio comentarioEnvio, Empleado realizador, FechaAccion fecha):base( fecha)
        {
            Realizador= realizador;
            TipoAccion = tipoAccion;
            Envio = envio;
            ComentarioEnvio = comentarioEnvio;
        }
    }
}
