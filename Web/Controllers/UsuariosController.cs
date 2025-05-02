using CasosDeUso.DTOs.Usuarios;
using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using Humanizer;
using LogicaAplicacion.CasosUsoConcretos;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        public ILogin CULogin { get; set; }
        public IRegistroEmpleado CuRegistroEmpleado { get; set; }
        public IListarEmpleados CUListarEmpleados { get; set; }
        public IObtenerEmpleado CUObtenerEmpleado { get; set; }
        public IEditarEmpleado CUEditarEmpleado { get; set; }
        public IBajaEmpleado CUBajaEmpleado { get; set; }

        public UsuariosController(ILogin cULogin, IRegistroEmpleado cUregistroEmpleado, IListarEmpleados cUListarEmpleados, IObtenerEmpleado cUObtenerEmpleado, IEditarEmpleado cUEditarEmpleado, IBajaEmpleado cUBajaEmpleado)
        {
            CULogin = cULogin;
            CuRegistroEmpleado = cUregistroEmpleado;
            CUListarEmpleados = cUListarEmpleados;
            CUObtenerEmpleado = cUObtenerEmpleado;
            CUEditarEmpleado = cUEditarEmpleado;
            CUBajaEmpleado = cUBajaEmpleado;
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO datos)
        {
            try
            {
                UsuarioDTO user = CULogin.RealizarLogin(datos);
                HttpContext.Session.SetInt32("LogeadoId", user.Id);
                HttpContext.Session.SetString("LogeadoRol", user.Rol);
                ViewBag.ErrorMessage = (user.Nombre + user.Apellido + user.Email + user.Rol + user.Id);
                return RedirectToAction("Index", "Home");
            }catch(DatosInvalidosException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error inesperado al iniciar sesión.";
            }
            return View();
        }

        public ActionResult Registro()
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {
                ViewBag.IdAdmin = HttpContext.Session.GetInt32("LogeadoId");
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }


        }

        [HttpPost]
        public ActionResult Registro(RegistroEmpleadoDTO datos)
        {
            ViewBag.IdAdmin = HttpContext.Session.GetInt32("LogeadoId");
            try
            {
                datos.Validar();
                UsuarioDTO creado = CuRegistroEmpleado.RegistrarEmpleado(datos);
                ViewBag.ErrorInfo = "Usuario creado exitosamente.";
            }catch (DatosInvalidosException ex)
            {
                ViewBag.ErrorInfo = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.ErrorInfo = "Ocurrió un error inesperado al registrar el usuario.";
            }
            return View();
        }




        public ActionResult Empleados()
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {

                return View(CUListarEmpleados.ListarTodosLosEmpleados());
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }

        }

        public ActionResult EditarEmpleado(int id)
        {

            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {

                EmpleadoDTO emp = null;
                try
                {
                    emp = CUObtenerEmpleado.FindById(id);
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.ErrorInfo = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Ocurrió un error inesperado al editar el usuario.";
                }

                return View(emp);


            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }

        }

        [HttpPost]
        public ActionResult EditarEmpleado(EmpleadoDTO dto)
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {
                try
                {
                    int? IdRealizador = HttpContext.Session.GetInt32("LogeadoId");
                    dto.Validar();
                    CUEditarEmpleado.EditarEmpleado(dto, IdRealizador);
                    ViewBag.ErrorMessage = "Empleado editado correctamente";
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.ErrorInfo = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Ocurrió un error inesperado al editar el usuario.";
                }

                return View(CUObtenerEmpleado.FindById(dto.Id));


            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }

        }

        public ActionResult BajaEmpleado(int id)
        {
  
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {
                EmpleadoDTO dto = null;
                try
                {
                     dto = CUObtenerEmpleado.FindById(id);
                    
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.ErrorInfo = ex.Message;
                }catch (Exception ex)
                {
                    ViewBag.ErrorInfo = "Ocurrió un error al recuoerar los datos del usuario";
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }



        }

        [HttpPost]
        public ActionResult BajaEmpleado(EmpleadoDTO dto, bool confirmacion)
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {
                int? IdRealizador = HttpContext.Session.GetInt32("LogeadoId");
                try
                {
                    CUBajaEmpleado.RelizarBaja(dto.Id, IdRealizador);
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.ErrorInfo = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Ocurrió un error al eliminar el usuario.";
                }
                return View(dto);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }


        }
    }
}
