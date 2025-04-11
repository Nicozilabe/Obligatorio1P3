using ExcepcionesPropias;
using LogicaNegocio.Enums;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    public record DireccionPostal : IValidable
    {

        public string Calle { get; init; }
        public int Numero { get; init; }
        public Ciudad Ciudad { get; init; }
        public int CodigoPostal { get; init; }

        public DireccionPostal() { 
            
        }
        public DireccionPostal(string calle, int numero, Ciudad ciudad, int cp) {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
            CodigoPostal = cp;
            Validar();
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle)) {
                throw new DatosInvalidosException("Calle debe ser un valor válido");
            }
            if(Calle.Length > 32)
            {
                throw new DatosInvalidosException("Calle no debe contener ente 1 y 32 caracteres.");
            }
            if (Numero <= 0 || Numero > 9999 || Numero == null) {
                throw new DatosInvalidosException("Número-Dirección Debe ser un valor entre 1 y 9999");
            }
            if (CodigoPostal <= 0 || CodigoPostal > 99999 || CodigoPostal == null)
            {
                throw new DatosInvalidosException("Número-Dirección Debe ser un valor entre 1 y 99999");
            }
            if(Ciudad == null)
            {
                throw new DatosInvalidosException("Ciudad no válida");
            }
        }
    }
}
