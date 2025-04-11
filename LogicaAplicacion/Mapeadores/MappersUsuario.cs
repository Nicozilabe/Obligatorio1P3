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

        public static UsuarioDTO ToUsuarioDTO(Usuario usuario) { 
            UsuarioDTO ret = null;
            if (usuario != null) {
                ret = new UsuarioDTO();
                if (usuario is Administrador)
                {
                    ret.rol = CasosDeUso.Enums.TipoRolUsuario.Administrador;
                }
                else if (usuario is Cliente)
                {
                    ret.rol = CasosDeUso.Enums.TipoRolUsuario.Cliente;
                }
                else if (usuario is Empleado) 
                { 
                    ret.rol = CasosDeUso.Enums.TipoRolUsuario.Empleado;
                }
                ret.Id = usuario.Id;
                ret.Nombre = usuario.Nombre.Nombre;
                ret.Apellido = usuario.Nombre.Apellido;
                ret.Email = usuario.Email.Email;
                ret.Password = usuario.Password.Password;
            }
            return ret;
        }

        public static List<UsuarioDTO> ToListaUsuarioDTO(List<Usuario> usuarios)
        {
            List<UsuarioDTO> DTOs = new List<UsuarioDTO>();
            foreach (Usuario usuario in usuarios)
            {
                UsuarioDTO dto = ToUsuarioDTO(usuario);
                DTOs.Add(dto);
            }
            return DTOs;
        }
    }
}
