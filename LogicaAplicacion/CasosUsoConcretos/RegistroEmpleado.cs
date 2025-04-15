using CasosDeUso.DTOs;
using ExcepcionesPropias;
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
    public class RegistroEmpleado
    {
        public IRepositorioUsuarios RepoUsuarios { get; set; }
        public IRepositorioAcciones RepoAcciones { get; set; }

        public RegistroEmpleado() { }

        public RegistroEmpleado(IRepositorioUsuarios repoUsuarios, IRepositorioAcciones repoAcciones)
        {
            RepoUsuarios = repoUsuarios;
            RepoAcciones = repoAcciones;
        }

        public UsuarioDTO RegistrarEmpleado(RegistroEmpleadoDTO datos)
        {

            datos.Validar();
            Administrador realizador = null;
            Usuario buscado = RepoUsuarios.FindById(datos.IdRealizador);
            if (buscado != null)
            {
                if (buscado is Administrador a)
                {
                    realizador = a;
                }
                else
                {
                    throw new DatosInvalidosException("La acción solicitada debe ser realizada por un administrador.");
                }
            }
            else {
                throw new DatosInvalidosException("No existe usuario con el IdRealizador indicado");
            }
            RepoUsuarios.Add(MappersRegistro.ToUsuario(datos));
            Usuario creado = RepoUsuarios.FindByEmail(datos.Email);
            Empleado creadoCast = null;

            if(creado is Empleado c)
            {
                creadoCast = c;
            }
            else
            {
                throw new DatosInvalidosException("Eror al crear el empleado");
            }

            Accion accion = new AccionAdministracion(creadoCast,realizador,TipoAccionAdministracion.Registro,new LogicaNegocio.ValueObjects.FechaAccion(new DateTime()));
            RepoAcciones.Add(accion);
            return MappersUsuario.ToUsuarioDTO(creado);

        }
    }
}
