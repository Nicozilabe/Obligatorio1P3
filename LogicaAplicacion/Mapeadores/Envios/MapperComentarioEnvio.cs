using CasosDeUso.DTOs.Envio;
using LogicaAplicacion.Mapeadores.Usuarios;
using LogicaNegocio.EntidadesDominio.Envíos;

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