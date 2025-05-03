using CasosDeUso.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapeadores.Envios
{
    public class MapperCiudad
    {
        public static CiudadDTO ToDTO(LogicaNegocio.EntidadesDominio.Envíos.Ciudad c)
        {
            //faltan validaciones
            CiudadDTO ret = new CiudadDTO
            {
                Nombre = c.Nombre,
                Id = c.Id,
            };

            return ret;
        }

        public static List<CiudadDTO> ToListDTO(List<LogicaNegocio.EntidadesDominio.Envíos.Ciudad> ciudades)
        {
            List<CiudadDTO> ret = new List<CiudadDTO>();
            foreach (var ciudad in ciudades)
            {
                ret.Add(ToDTO(ciudad));
            }
            return ret;
        }
    }
}
