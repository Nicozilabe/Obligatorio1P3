using CasosDeUso.DTOs.Envio;
using CasosDeUso.InterfacesCasosUso;
using LogicaAplicacion.Mapeadores.Envios;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos.Envios
{
    public class ObtenerCiudades: IObtenerCiudades
    {
        IRepositorioCiudades repo { get; set; }

        public ObtenerCiudades(IRepositorioCiudades repo)
        {
            this.repo = repo;
        }
        public IEnumerable<CiudadDTO> GetCiudades()
        {
            return MapperCiudad.ToListDTO(repo.FindAll());
        }
    }

}
