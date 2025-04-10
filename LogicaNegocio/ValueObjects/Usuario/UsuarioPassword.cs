using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.Usuario
{
    public record UsuarioPassword : IValidable
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
