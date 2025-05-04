using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
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
            throw new NotImplementedException();
        }
    }
}
