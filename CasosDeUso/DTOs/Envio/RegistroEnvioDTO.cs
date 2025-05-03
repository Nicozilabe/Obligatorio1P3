using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.DTOs.Envio
{
    public class RegistroEnvioDTO
    {
        public int IdEmpleadoResponable { get; set; }
        public string EmailCliente { get; set; }
        public double Peso { get; set; }
        public string TipoEnvio { get; set; }
        public AgenciaDTO? Agencia { get; set; }
        public DireccionDTO? direccion { get; set; }
    }
}
