using CasosDeUso.InterfacesCasosUso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.DTOs.Envio
{
    public class AgenciaDTO : IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DireccionDTO Direccion { get; set; }
        public UbicacionDTO Ubicacion { get; set; }
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
