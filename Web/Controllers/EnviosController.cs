using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EnviosController : Controller
    {
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
