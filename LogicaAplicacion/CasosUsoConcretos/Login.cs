using CasosDeUso.DTOs;
using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using LogicaAplicacion.Mapeadores;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos
{
    public class Login:ILogin
    {
        public IRepositorioEmpleados Repo { get; set; }

        public Login(IRepositorioEmpleados repo) {  Repo = repo; }

        public UsuarioDTO? RealizarLogin(LoginDTO datos)
        {
            UsuarioDTO? ret = null;
            Usuario buscado = Repo.FindByEmail(datos.Email);
            if (buscado != null)
            {
                ret = MappersUsuario.ToUsuarioDTO(buscado);
            }
            else
            {     
                    throw new DatosInvalidosException("Email o Contraseña no válidos");   
            }
            return ret;
        }

    }
}
