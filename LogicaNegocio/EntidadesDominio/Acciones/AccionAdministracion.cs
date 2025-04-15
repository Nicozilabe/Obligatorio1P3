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
    public class AccionAdministracion : Accion
    {
        public Empleado Afectado { get; set; }
        public Administrador Realizador { get; set; }
        public TipoAccionAdministracion TipoAccion { get; set; }

        public AccionAdministracion() { }

        public AccionAdministracion(Empleado afectado, Administrador realizador, TipoAccionAdministracion tipoAccion, FechaAccion fecha):base(fecha)
        {
            Afectado = afectado;
            Realizador = realizador;
            TipoAccion = tipoAccion;
        }
    }
}
