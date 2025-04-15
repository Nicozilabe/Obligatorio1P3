using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Acciones;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repos
{
    public class RepoAcciones:IRepositorioAcciones
    {
        public EmpresaContext Context { get; set; }

        public RepoAcciones(EmpresaContext context)
        {

            Context = context;

        }

        public void Add(Accion obj)
        {
            if (obj == null) {
                throw new DatosInvalidosException("Acción no válida");
            }
            obj.Validar();

            Context.Acciones.Add(obj);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Accion obj)
        {
            throw new NotImplementedException();
        }

        public Accion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Accion> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
