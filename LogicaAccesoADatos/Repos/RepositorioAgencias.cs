using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Envíos;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repos
{
    public class RepositorioAgencias : IRepositorioAgencias
    {
        public EmpresaContext Context { get; set; }

        public RepositorioAgencias(EmpresaContext context)
        {

            Context = context;

        }
        public void Add(Agencia obj)
        {
            throw new NotImplementedException();
        }

        public List<Agencia> FindAll()
        {
            return Context.Agencias.ToList();
        }

        public Agencia FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Agencia obj)
        {
            throw new NotImplementedException();
        }
    }
}
