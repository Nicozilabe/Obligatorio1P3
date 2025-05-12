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

        public EnvioDTO getByID(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El id no puede ser menor o igual a cero");
            }
            var envio = repoEnvios.FindById(id);
            if (envio == null)
            {
                throw new ArgumentException("El envío no existe");
            }
            else
            {
                return MapperEnvio.ToDTO(envio);
            }
        }
    }
}
