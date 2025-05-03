using CasosDeUso.DTOs.Envio;

namespace Web.Models
{
    public class RegistroEnvioViewModel
    {
        public string EmailCliente { get; set; }
        public double Peso { get; set; }
        public string TipoEnvio { get; set; }
        public int IdAgencia { get; set; }
        public int IdCiudad { get; set; }
        public DireccionDTO? direccion { get; set; }

        public IEnumerable<CiudadDTO> Ciudades { get; set; }
        public IEnumerable<AgenciaDTO> Agencias { get; set; } 
    }
}
