using CasosDeUso.DTOs.Envio;
using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using LogicaNegocio.InterfacesRepositorio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapeadores.Envios
{
    public class MapperEnvio
    {
        public static Envio RegistroDTOToEnvioComun(RegistroEnvioDTO dto, Empleado EmpleadoResponsable, Agencia agencia)
        {
            EnvioComun ret = new EnvioComun();
            if (dto == null)
            {
                throw new DatosInvalidosException("El DTO de registro de envío no puede ser nulo");
            }
            
            ret.EstadoEnvio = TipoEstadoEnvio.En_Proceso;
            ret.EmpleadoResponable = EmpleadoResponsable;
            ret.Cliente = dto.EmailCliente;
            ret.Peso = dto.Peso;
            ret.Seguimiento = TipoSeguimiento.En_Preparacion;
            ret.Agencia = agencia;
            return ret;
        }
        public static EnvioUrgente RegistroDTOToEnvioUrgente(RegistroEnvioDTO dto, Empleado EmpleadoResponsable, DireccionPostal di, Ciudad c)
        {
            EnvioUrgente ret = new EnvioUrgente();
            if (dto == null)
            {
                throw new DatosInvalidosException("El DTO de registro de envío no puede ser nulo");
            }
            
            ret.EstadoEnvio = TipoEstadoEnvio.En_Proceso;
            ret.EmpleadoResponable = EmpleadoResponsable;
            ret.Cliente = dto.EmailCliente;
            ret.Peso = dto.Peso;
            ret.Seguimiento = TipoSeguimiento.En_Preparacion;
            ret.Direccion = di;
            
            return ret;
        }
    }
}
