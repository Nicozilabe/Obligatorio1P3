using LogicaAccesoADatos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repos
{
    public class RepositorioEmpleados
    {
        public EmpresaContext Context { get; set; }

        public RepositorioEmpleados(EmpresaContext context)
        {

            Context = context;

        }

    }
}
