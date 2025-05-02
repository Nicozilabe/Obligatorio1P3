using CasosDeUso.DTOs;
using CasosDeUso.InterfacesCasosUso;
using LogicaAplicacion.Mapeadores;
using LogicaNegocio.EntidadesDominio.Acciones;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
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

        void IEditarEmpleado.EditarEmpleado(EmpleadoDTO dto, int? idRealizador)
        {
            if (idRealizador == null)
            {
                throw new DataMisalignedException("El id del realizador no puede ser nulo");
            }

            Administrador realizador = repo.VerificarAdministrador((int)idRealizador);

            AccionAdministracion accion = new AccionAdministracion(repo.FindById(dto.Id),realizador,TipoAccionAdministracion.Modificación, new LogicaNegocio.ValueObjects.FechaAccion(DateTime.Now);

            repo.Update(MappersEmpleado.ToEmpleado(dto));
        }
    }
}
