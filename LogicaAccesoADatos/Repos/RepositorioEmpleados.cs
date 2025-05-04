using ExcepcionesPropias;
using LogicaAccesoADatos.EF;
using LogicaNegocio.EntidadesDominio.Usuarios;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LogicaAccesoADatos.Repos
{
    public class RepositorioEmpleados: IRepositorioEmpleados
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

            if (buscado != null)
            {
                throw new DatosInvalidosException("El Usuario ya existe");
            }
            Context.Empleados.Add(obj);
            Context.SaveChanges();
        }

        public void Remove(int id)
        {
            Empleado aBorrar = FindById(id);
            if (aBorrar == null)
            {
                throw new DatosInvalidosException("No hay un Empleado para borrar aqui");
            }
            Context.Empleados.Remove(aBorrar);
            Context.SaveChanges();
        }

        public void Update(Empleado obj)
        {
            if(obj == null)
            {
                throw new DatosInvalidosException("");
            }
            obj.Validar();
            Empleado aEditar = FindById(obj.Id);

            if (aEditar.Nombre.Nombre != obj.Nombre.Nombre || aEditar.Activo != obj.Activo || aEditar.Email.Email != obj.Email.Email)
            {
                if(aEditar.Email.Email != obj.Email.Email)
                {
                    Empleado buscado = FindByEmail(obj.Email.Email);
                    if(buscado != null)
                    {
                        throw new DatosInvalidosException("El Email a editar ya existe.");
                    }
                }
            }
            Context.Entry(aEditar).State = EntityState.Detached;
            Context.Empleados.Update(obj); 
            Context.SaveChanges();
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
            Empleado? buscado = Context.Empleados.AsEnumerable().Where(Empleado => Empleado.Email.Email == email).SingleOrDefault();
            return buscado;
        }
        public Administrador VerificarAdministrador(int id)
        {
            Administrador a = null;
            try
            {
                a = Context.Empleados.OfType<Administrador>().SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex) 
            {
                throw new PermisosException("La acción solicitada debe ser realizada por un administrador.");
            }
            if (a == null)
            {
                throw new PermisosException("La acción solicitada debe ser realizada por un administrador.");
            }
            return a;
        }

        public Empleado VerificarEmpleado(int id)
        {
            if (id <= 0)
            {
                throw new DatosInvalidosException("El id no puede ser menor o igual a cero.");
            }
            Empleado ret = null;
            try
            {
                ret = Context.Empleados.OfType<Empleado>().SingleOrDefault(a => a.Id == id);
            }
            catch (Exception ex)
            {
                throw new PermisosException("La acción solicitada debe ser realizada por un empleado.");
            }
            return ret;
        }
    }
}
