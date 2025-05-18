using CasosDeUso.DTOs.Envio;
using LogicaAplicacion.Mapeadores.Usuarios;
using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.Enums;

namespace LogicaAplicacion.Mapeadores.Envios
{
    public class MapperComentarioEnvio
    {

        public static ComentarioEnvioDTO ToDTO(ComentarioEnvio comentario)
        {
            ComentarioEnvioDTO ret = new ComentarioEnvioDTO
            {
                Id = comentario.Id,
                Fecha = comentario.Fecha,
                Comentario = comentario.Comentario.ToString(),
                Empleado = MappersEmpleado.ToEmpleadoDTO(comentario.Empleado),
            };
            return ret;
        }

        public static ComentarioEnvio ToComentario(ComentarioEnvioDTO comentarioDTO, int? empleadoId = null)
        {
            ComentarioEnvio ret = new ComentarioEnvio
            {
                Id = comentarioDTO.Id,
                Fecha = comentarioDTO.Fecha,
                Comentario = comentarioDTO.Comentario,
                EmpleadoId = empleadoId,
            };

            return ret;
        }

        public static IEnumerable<ComentarioEnvioDTO> ToListDTO(IEnumerable<ComentarioEnvio> comentarios)
        {
            List<ComentarioEnvioDTO> ret = new List<ComentarioEnvioDTO>();
            foreach (var comentario in comentarios)
            {
                ret.Add(ToDTO(comentario));
            }
            return ret;
        }
    }
}