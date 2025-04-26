using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

            Empleado buscado = FindByEmail(obj.Email.Email);

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
            Empleado buscado = Context.Empleados.Where(Empleado => Empleado.Id == id).SingleOrDefault();
            return buscado;
        }

        public List<Empleado> FindAll()
        {
            return Context.Empleados.ToList();
        }

        public Empleado? FindByEmail(string email)
        {
            Empleado? buscado = Context.Empleados.Where(Empleado => Empleado.Email.Email == email).SingleOrDefault();
            return buscado;
        }
       
        
    }
}
