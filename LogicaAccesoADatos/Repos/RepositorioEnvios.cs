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
            obj.generarTracking();
            obj.FechaRegistroEnvio = DateTime.Now;
            //Validamos el Envío acá porque es el que genera el tracking(Para que no se desface la variable o se pierda)
            obj.Validar();
            Context.Envios.Add(obj);
            Context.SaveChanges();
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
            if (obj == null)
            {
                throw new DatosInvalidosException("Error al registrar cambio envio.");
            }
            obj.Validar();
            Envio aEditar = FindById(obj.Id);

            if (aEditar.FechaEntrega == obj.FechaEntrega || aEditar.EstadoEnvio == obj.EstadoEnvio || aEditar.FechaRegistroEnvio == obj.FechaRegistroEnvio || aEditar.Comentarios == obj.Comentarios)
            {
                //agregar más validaciones si se necesita
                throw new DatosInvalidosException("No se han ingresado cambios al envío.");                
            }
            Context.Entry(aEditar).State = EntityState.Detached;
            Context.Envios.Update(obj);
            Context.SaveChanges();
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
