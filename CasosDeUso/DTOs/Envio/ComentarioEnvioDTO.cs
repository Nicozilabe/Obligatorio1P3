using CasosDeUso.DTOs.Usuarios;
using CasosDeUso.InterfacesCasosUso;

namespace CasosDeUso.DTOs.Envio
{
    public class ComentarioEnvioDTO:IValidable
    {
        public int Id { get; init; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public EmpleadoDTO Empleado { get; set; }
        public int? EmpleadoId { get; set; }

        public ComentarioEnvioDTO() { }

        public void Validar()
        {
            
        }


        //validar comentario, fecha y empleado id



    }
}