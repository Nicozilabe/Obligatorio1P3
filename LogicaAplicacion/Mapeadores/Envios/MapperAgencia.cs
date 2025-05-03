using CasosDeUso.DTOs.Envio;
using LogicaNegocio.EntidadesDominio.Envíos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapeadores.Envios
{
    public class MapperAgencia
    {
        public static AgenciaDTO ToDTO(Agencia a)
        {

            //faltan validaciones
            AgenciaDTO ret = new AgenciaDTO
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Direccion = MapperDireccion.ToDTO(a.Direccion),
                Ubicacion = MapperUbicacion.ToDTO(a.Ubicacion)
            };

            return ret;

        }
        public static List<AgenciaDTO> ToListDTO(List<Agencia> agencias)
        {
            throw new NotImplementedException();
        }

    }
}
