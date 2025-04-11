using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public class EnvioComun:Envio
    {
        public Agencia Agencia { get; set; }

        public EnvioComun(Agencia agencia)
        {
            Agencia = agencia;
        }
        public EnvioComun() { }
    }
}
