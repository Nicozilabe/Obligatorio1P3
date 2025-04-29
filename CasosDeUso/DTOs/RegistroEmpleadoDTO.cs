using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.DTOs
{
    public class RegistroEmpleadoDTO:IValidable
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Pass {  get; set; }

        public int IdRealizador { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new DatosInvalidosException("El nombre no puede quedar vacio. DTO->Usuario");
            }
            if (Nombre.Length > 32)
            {
                throw new DatosInvalidosException("El nombre debe tener menos de 32 letras. DTO->Usuario");
            }
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new DatosInvalidosException("El apellido no puede quedar vacio. DTO->Usuario");
            }
            if (Apellido.Length > 32)
            {
                throw new DatosInvalidosException("El apellido debe tener menos de 32 letras. DTO->Usuario");
            }
            if (string.IsNullOrEmpty(Email))
            {
                throw new DatosInvalidosException("El email no puede quedar vacio. DTO->Usuario");
            }
            if (Email.Length > 32)
            {
                throw new DatosInvalidosException("El email debe tener menos de 32 letras. DTO->Usuario");
            }
            if (string.IsNullOrEmpty(Pass))
            {
                throw new DatosInvalidosException("La contraseña no puede quedar vacio. DTO->Usuario");
            }
            if (Pass.Length > 32)
            {
                throw new DatosInvalidosException("La contraseña debe tener menos de 32 letras. DTO->Usuario");
            }
            if (Rol != "Empleado" && Rol != "Administrador")
            {
                throw new DatosInvalidosException("Tipo Usuario no válido. DTO->Usuario");
            }
            if (IdRealizador < 0)
            {
                throw new DatosInvalidosException("Id Realizador no válido. DTO->Usuario");
            }
        }

    }
}
