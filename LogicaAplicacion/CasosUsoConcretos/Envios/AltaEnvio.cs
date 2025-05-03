using CasosDeUso.DTOs.Envio;
using CasosDeUso.InterfacesCasosUso;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos.Envios
{
    public class AltaEnvio: IAltaEnvio
    {
        IRepositorioEnvios repo {  get; set; }

        public AltaEnvio(IRepositorioEnvios repo)
        {
            this.repo = repo;
        }
        public EnvioDTO AltaEnvio(RegistroEnvioDTO envio)
        {
            repo.VerificarEmpleado(envio.IdEmpleadoResponable);
            repo.Add(MapperEnvio.RegistroDTOToEnvio(envio));
        }
    }

}
