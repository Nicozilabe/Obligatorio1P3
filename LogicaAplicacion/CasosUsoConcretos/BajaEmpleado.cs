using CasosDeUso.DTOs;
using CasosDeUso.InterfacesCasosUso;
using LogicaAplicacion.Mapeadores;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos
{
    public class BajaEmpleado : IBajaEmpleado
    {
        public IRepositorioEmpleados repo { get; set; }

        public BajaEmpleado(IRepositorioEmpleados repo)
        {
            this.repo = repo;
        }

        void IBajaEmpleado.BajaEmpleado(int id)
        {
            repo.Remove(id);
        }
    }
}
