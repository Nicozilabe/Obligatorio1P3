using CasosDeUso.DTOs.Usuarios;
using CasosDeUso.InterfacesCasosUso;
using LogicaAplicacion.Mapeadores.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos.Usuarios
{
    public class ListarEmpleados : IListarEmpleados
    {
        IRepositorioEmpleados repo { get; set; }

        public ListarEmpleados(IRepositorioEmpleados repo)
        {
            this.repo = repo;
        }

        public List<EmpleadoDTO> ListarTodosLosEmpleados()
        {
            return MappersEmpleado.ToListaEmpleadoDTO(repo.FindAll());
        }
    }
}
