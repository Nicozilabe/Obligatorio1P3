using CasosDeUso.DTOs.Usuarios;

namespace CasosDeUso.DTOs.Envio
{
    public class ComentarioEnvioDTO
    {
        public int Id { get; init; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public EmpleadoDTO Empleado { get; set; }
        public int? EmpleadoId { get; set; }

        public ComentarioEnvioDTO() { }
    }
}