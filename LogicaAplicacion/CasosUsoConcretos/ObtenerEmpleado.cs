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
    public class ObtenerEmpleado : IObtenerEmpleado
    {
        IRepositorioEmpleados repo {  get; set; }

        public ObtenerEmpleado (IRepositorioEmpleados repo)
        {
            this.repo = repo;
        }

        public EmpleadoDTO FindById(int id)
        {
            return MappersEmpleado.ToEmpleadoDTO(repo.FindById(id));
        }
    }
}
