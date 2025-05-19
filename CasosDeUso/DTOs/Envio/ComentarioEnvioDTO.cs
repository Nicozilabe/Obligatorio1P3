using CasosDeUso.DTOs.Usuarios;
using CasosDeUso.InterfacesCasosUso;
using System.ComponentModel.DataAnnotations;

namespace CasosDeUso.DTOs.Envio
{
    public class ComentarioEnvioDTO:IValidable
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(32, ErrorMessage = "Comentario no puede superar los 32 caracteres.")]
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public EmpleadoSeguroDTO Empleado { get; set; }
        public int? EmpleadoId { get; set; }

        public ComentarioEnvioDTO() { }

        public void Validar()
        {
            
        }


        //validar comentario, fecha y empleado id



    }
}