using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repos
{
    public class RepositorioEmpleados:IRepositorioEmpleados
    {
        public EmpresaContext Context { get; set; }

        public RepositorioEmpleados(EmpresaContext context)
        {

            Context = context;

        }

        public void Add(Empleado obj)
        {
            if (obj == null)
            {
                throw new DatosInvalidosException("Usuario no válido para el alta.");
            }
            obj.Validar();

            Empleado buscado = null;

            if(buscado != null)
            {
                throw new DatosInvalidosException("El Usuario ya existe"); 
            }
            Context.Empleados.Add(obj);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Empleado obj)
        {
            throw new NotImplementedException();
        }

        public Empleado FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empleado> FindAll()
        {
            throw new NotImplementedException();
        }

        public Empleado? FindByEmail(string email)
        {
            Empleado? buscado = Context.Empleados.Where(Empleado => Empleado.Email.Email == email).SingleOrDefault();
            return buscado;
        }
    }
}
