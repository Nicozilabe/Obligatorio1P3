using CasosDeUso.DTOs;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUsoConcretos
{
    public class Login
    {
        public IRepositorioEmpleados Repo { get; set; }

        public Login(IRepositorioEmpleados repo) {  Repo = repo; }

        public UsuarioDTO Login(LoginDTO datos)
        {

        }


    }
}
