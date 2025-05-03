using CasosDeUso.DTOs.Envio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapeadores.Envios
{
    public class MapperDireccion
    {
        public static DireccionDTO ToDTO(DireccionPostal d)
        {
            //faltan validaciones
            DireccionDTO ret = new DireccionDTO
            {
                Calle = d.Calle,
                Numero = d.Numero,
                Ciudad = MapperCiudad.ToDTO(d.Ciudad),
            };

            return ret;
        }

    }
}
