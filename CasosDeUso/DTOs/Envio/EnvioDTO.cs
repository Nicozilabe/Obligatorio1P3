using CasosDeUso.DTOs.Usuarios;
using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.DTOs.Envio
{
    public class EnvioDTO : IValidable
    {
        public int Id { get; set; }
        public int Tracking { get; set; }
        public EmpleadoDTO EmpleadoResponable { get; set; }
        public string EmailCliente { get; set; }
        public double Peso { get; set; }
        public string EstadoEnvio { get; set; }
        public string Seguimiento { get; set; }
        public string TipoEnvio { get; set; }
        public AgenciaDTO? Agencia { get; set; }
        public DireccionDTO? direccion { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(TipoEnvio) || TipoEnvio != "Comun" || TipoEnvio != "Urgente")
            {
                throw new DatosInvalidosException("Tipo de envio no válido");
            }
            //if (TipoEnvio == "comun")
            //{
            //    Agencia.Validar();
            //}
            //else
            //{
            //    direccion.Validar();
            //}
        }
    }
}
