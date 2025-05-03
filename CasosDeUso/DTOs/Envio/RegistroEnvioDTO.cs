using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasosDeUso.DTOs.Envio
{
    public class RegistroEnvioDTO: IValidable
    {
        public int IdEmpleadoResponable { get; set; }
        public string EmailCliente { get; set; }
        public double Peso { get; set; }
        public string TipoEnvio { get; set; }
        public AgenciaDTO? Agencia { get; set; }
        public DireccionDTO? direccion { get; set; }

        public void Validar()
        {
            if(IdEmpleadoResponable < 0)
            {
                throw new DatosInvalidosException("Id empleado responsable no valido, debe ser mayor a 0");
            }
            if(IdEmpleadoResponable == null)
            {
                throw new DatosInvalidosException("El Id del empleado responsable no puede quedar vacio");
            }
            if (string.IsNullOrEmpty(EmailCliente))
            {
                throw new DatosInvalidosException("El Email-Registro-Envio no puede quedar vacio.");
            }
            if (EmailCliente.Length > 32)
            {
                throw new DatosInvalidosException("El Email-Registro-Envio debe tener menos de 32 letras");
            }
            if (Peso <= 0 || Peso == null)
            {
                throw new DatosInvalidosException("El Peso-Registro debe ser un valor mayor a 0");
            }
            if (string.IsNullOrEmpty(TipoEnvio))
            {
                throw new DatosInvalidosException("El tipo envio no puede estar vacio");
            }
            if (TipoEnvio != "C" || TipoEnvio != "U")
            {
                throw new DatosInvalidosException("El Tipo unicamente puede ser Comun o Urgente.");
            }
            if (TipoEnvio == "C")
            {
                Agencia.Validar();
            }
            if (TipoEnvio == "U")
            {
                direccion.Validar();
            }
        }
    }
}
