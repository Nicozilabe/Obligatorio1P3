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
    public class EditarEmpleado : IEditarEmpleado
    {
        public IRepositorioEmpleados repo { get; set; }

        public EditarEmpleado(IRepositorioEmpleados repo)
        {
            this.repo = repo;
        }

        void IEditarEmpleado.EditarEmpleado(EmpleadoDTO dto)
        {
            repo.Update(MappersEmpleado.ToEmpleado(dto));
        }
    }
}
