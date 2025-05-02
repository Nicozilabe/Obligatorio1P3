using CasosDeUso.InterfacesCasosUso;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EnviosController : Controller
    {
        public IObtenerAgencias CUObtenerAgencias { get; set; }

        public EnviosController(IObtenerAgencias cUObtenerAgencias) {
            CUObtenerAgencias = cUObtenerAgencias;
        }
       public IActionResult AltaEnvio()
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador")
            {
                return View();
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }
    }
}
