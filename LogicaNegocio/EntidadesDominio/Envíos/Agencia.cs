using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DireccionPostal Direccion { get; set; }
        public Ubicacion Ubicacion { get; set; }


    }
}
