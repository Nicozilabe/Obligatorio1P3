using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasosDeUso.DTOs.Envio
{
    public class DireccionDTO : IValidable
    {
        public string Calle { get; init; }
        public int Numero { get; init; }
        public CiudadDTO Ciudad { get; init; }
        public int CodigoPostal { get; init; }
        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle))
            {
                throw new DatosInvalidosException("Calle debe ser un valor válido");
            }
            if (Calle.Length > 32)
            {
                throw new DatosInvalidosException("Calle no debe contener ente 1 y 32 caracteres.");
            }
            if (Numero <= 0 || Numero > 9999 || Numero == null)
            {
                throw new DatosInvalidosException("Número-Dirección Debe ser un valor entre 1 y 9999");
            }
            if (CodigoPostal <= 0 || CodigoPostal > 99999 || CodigoPostal == null)
            {
                throw new DatosInvalidosException("Número-Dirección Debe ser un valor entre 1 y 99999");
            }
            if (Ciudad == null)
            {
                throw new DatosInvalidosException("Ciudad no válida");
            }
            Ciudad.Validar();
        }
    }
