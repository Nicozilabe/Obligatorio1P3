using ExcepcionesPropias;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesDominio.Envíos
{
    public abstract class Envio:IValidable
    {
        public int Id { get; set; }
        public int Tracking { get; set; }
        public Empleado EmpleadoResponable { get; set; }
        public string Cliente { get; set; }
        public double Peso { get; set; }
        public TipoEstadoEnvio EstadoEnvio { get; set; }
        public TipoSeguimiento Seguimiento { get; set; }

        private static int ultimoTrack = 1;

        public Envio()
        {
           
        }
        public Envio(Empleado empleadoResponable, string cliente, double peso, TipoEstadoEnvio estadoEnvio, TipoSeguimiento seguimiento)
        {
            EmpleadoResponable = empleadoResponable;
            Cliente = cliente;
            Peso = peso;
            EstadoEnvio = estadoEnvio;
            Seguimiento = seguimiento;
        }

        public virtual void Validar()
        {
           if(Peso < 0)
            {
                throw new DatosInvalidosException("Peso-Envío no válido");
            }
            if (Tracking < 0)
            {
                throw new DatosInvalidosException("Tracking-Envío no válido");
            }
            if( EmpleadoResponable == null)
            {
                throw new DatosInvalidosException("Empleado-Envío no válido");
            }
            if (Cliente == null)
            {
                throw new DatosInvalidosException("Cliente-Envío no válido");
            }
            if (EstadoEnvio == null)
            {
                throw new DatosInvalidosException("Estado Envío no válido");
            }
            if (Seguimiento == null)
            {
                throw new DatosInvalidosException("Seguimiento-Encío no válido");
            }

            
        }
        public void generarTrack()
        {
            Tracking = ultimoTrack++;
        }
    }
}
