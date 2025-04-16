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
            if(Rol != "Empleado" && Rol != "Administrador" && Rol != "Cliente") {
                throw new DatosInvalidosException("Tipo Usuario no válido");
            }

            if (string.IsNullOrEmpty(Nombre) || Nombre.Length > 32)
            {
                throw new DatosInvalidosException("Nombre no válido DTO->Usuario");
            }
            if (string.IsNullOrEmpty(Email) || Email.Length > 32)
            {
                throw new DatosInvalidosException("Nombre no válido DTO->Usuario");
            }
            if (string.IsNullOrEmpty(Pass) || Pass.Length > 32)
            {
                throw new DatosInvalidosException("Nombre no válido DTO->Usuario");
            }
            if (IdRealizador < 0) {
                throw new DatosInvalidosException("Id Realizador no válido");
            }
        }

    }
}
