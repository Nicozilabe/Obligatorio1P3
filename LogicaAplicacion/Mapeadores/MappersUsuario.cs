using CasosDeUso.DTOs;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.ValueObjects.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mapeadores
{
    public class MappersUsuario
    {
        public static Usuario ToUsuario(UsuarioDTO dto) {
            Usuario ret = null;
            if(dto.rol == CasosDeUso.Enums.TipoRolUsuario.Cliente)
            {
                ret = new Cliente();
            } 
            else if(dto.rol == CasosDeUso.Enums.TipoRolUsuario.Administrador)
            {
                ret = new Administrador();
            } 
            else if(dto.rol == CasosDeUso.Enums.TipoRolUsuario.Empleado)
            {
                ret = new Empleado();
            }
            ret.Id = dto.Id;
            ret.Nombre = new UsuarioNombre(dto.Nombre, dto.Apellido);
            ret.Email = new UsuarioEmail(dto.Email);
            ret.Password = new UsuarioPassword(dto.Password);
            return ret;
        }
    }
}
