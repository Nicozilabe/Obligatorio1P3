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
    public class ObtenerAgencias:IObtenerAgencias
    {
        public IRepositorioAgencias repo { get; set; }

        public ObtenerAgencias(IRepositorioAgencias repo)
        {
            this.repo = repo;
        }

        public IEnumerable<AgenciaDTO> GetAgencias() { 
        
                return MapperAgencia.ToListDTO(repo.FindAll());
        }
    }
}
