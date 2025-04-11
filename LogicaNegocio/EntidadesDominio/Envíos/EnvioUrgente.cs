using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public class EnvioUrgente:Envio
    {
        public DireccionPostal Direccion { get; set; }
        public bool EnvioEficiente { get; set; }

        public EnvioUrgente() { }

        public EnvioUrgente(DireccionPostal direccion)
        {
            Direccion = direccion;

        }
    }
}
