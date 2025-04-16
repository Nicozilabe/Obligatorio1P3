using CasosDeUso.DTOs;
using CasosDeUso.InterfacesCasosUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UsuariosController : Controller
    {
        public ILogin CULogin { get; set; }
        public IRegistroEmpleado CuRegistroEmpleado { get; set; }

        public UsuariosController(ILogin cULogin, IRegistroEmpleado cUregistroEmpleado)
        {
            CULogin = cULogin;
            CuRegistroEmpleado = cUregistroEmpleado;
        }



        // GET: UsuariosController
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult Login() {
            return View(); 
         }
        
        [HttpPost]
        public ActionResult Login(LoginDTO datos)
        {
            try{
                UsuarioDTO user = CULogin.RealizarLogin(datos);
                HttpContext.Session.SetInt32("LogeadoId", user.Id);
                HttpContext.Session.SetString("LogeadoRol", user.Rol);
                ViewBag.ErrorMessage = (user.Nombre+user.Apellido+user.Email+user.Rol+user.Id);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) { 
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        public ActionResult Registro()
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador") { 
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
            try
            {
                datos.Validar();
                CuRegistroEmpleado.RegistrarEmpleado(datos);
            }
            catch (Exception ex) { 
                ViewBag.ErrorInfo = ex.Message;
            }
            return View();
        }
        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
