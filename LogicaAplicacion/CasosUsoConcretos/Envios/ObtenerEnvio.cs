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
    public class ObtenerEnvio : IObtenerEnvio
    {
        IRepositorioEnvios repoEnvios { get; set; }

        public ObtenerEnvio(IRepositorioEnvios repoEnvios)
        {
            this.repoEnvios = repoEnvios;
        }


        //Cargar menos a la base con datos que no se van a mostrar
        public IEnumerable<EnvioLigthDTO> getEnviosLightActivos()
        {
            return MapperEnvio.ToListEnvioLigthDTO(repoEnvios.FindAllLightActivos());
        }
    }
}
