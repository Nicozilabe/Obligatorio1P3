using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public record UsuarioNombre: IValidable
    {
        public string Nombre { get; init; }
        public string Apellido { get; init; }

        public UsuarioNombre(string nombre, string apellido) {
            Nombre = nombre;
            Apellido = apellido;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre)) {
               
                
            }
        }
    }
}
