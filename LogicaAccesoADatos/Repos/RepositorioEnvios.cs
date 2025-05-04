using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.Enums;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repos
{
    public class RepositorioEnvios : IRepositorioEnvios
    {

        public EmpresaContext Context { get; set; }

        public RepositorioEnvios(EmpresaContext context)
        {
            Context = context;
        }

        public void Add(Envio obj)
        {
            if (obj == null)
            {
                throw new DatosInvalidosException("Envío no válido para el alta.");
            }
            obj.Tracking=(GetLastTracking()+1);
            obj.FechaRegistroEnvio = DateTime.Now;
            //Validamos el Envío acá porque es el que genera el tracking(Para que no se desface la variable o se pierda)
            obj.Validar();
            Context.Envios.Add(obj);
            Context.SaveChanges();
        }
        public int GetLastTracking()
        {
            var lastTracking = Context.Envios.OrderByDescending(e => e.Tracking).FirstOrDefault();
            if (lastTracking != null)
            {
                return lastTracking.Tracking;
            }
            return 0; 
        }
        public List<Envio> FindAll()
        {
            throw new NotImplementedException();
        }

        public Envio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Envio obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Envio> FindAllLightActivos()
        {
            List<Envio> ret = new List<Envio>();
            ret.AddRange(Context.EnviosComunes.Include(a => a.Agencia).Where(a => a.EstadoEnvio == TipoEstadoEnvio.En_Proceso).ToList());
            ret.AddRange(Context.EnviosUrgentes.Include(a => a.Direccion).Where(a => a.EstadoEnvio == TipoEstadoEnvio.En_Proceso).ToList());
            return ret;
        }
    }
}
