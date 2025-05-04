using CasosDeUso.DTOs.Envio;
using CasosDeUso.InterfacesCasosUso;
using ExcepcionesPropias;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class EnviosController : Controller
    {
        public IObtenerAgencias CUObtenerAgencias { get; set; }
        public IObtenerCiudades CUObtenerCiudades { get; set; }
        public IAltaEnvio CUAltaEnvio { get; set; }




        public EnviosController(IObtenerAgencias cUObtenerAgencias, IObtenerCiudades cUObtenerCiudades, IAltaEnvio cUAltaEnvio)
        {
            CUObtenerAgencias = cUObtenerAgencias;
            CUObtenerCiudades = cUObtenerCiudades;
            CUAltaEnvio = cUAltaEnvio;
        }



        public IActionResult AltaEnvio()

        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador" || HttpContext.Session.GetString("LogeadoRol") == "Empleado")
            {

                IEnumerable<AgenciaDTO> agencias = CUObtenerAgencias.GetAgencias();
                IEnumerable<CiudadDTO> ciudades = CUObtenerCiudades.GetCiudades();




                RegistroEnvioViewModel model = new RegistroEnvioViewModel
                {
                    direccion = new DireccionDTO(),
                    Agencias = agencias,
                    Ciudades = ciudades,
                    EmailCliente = "",
                    Peso = 0,
                    TipoEnvio = "",
                    IdAgencia = 0
                };

                return View(model);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }
        }
        [HttpPost]
        public IActionResult AltaEnvio(RegistroEnvioViewModel model)
        {

            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador" || HttpContext.Session.GetString("LogeadoRol") == "Empleado")
            {

                IEnumerable<AgenciaDTO> agencias = CUObtenerAgencias.GetAgencias();
                IEnumerable<CiudadDTO> ciudades = CUObtenerCiudades.GetCiudades();




                RegistroEnvioViewModel model2 = new RegistroEnvioViewModel
                {
                    direccion = new DireccionDTO(),
                    Agencias = agencias,
                    Ciudades = ciudades,
                    EmailCliente = "",
                    Peso = 0,
                    TipoEnvio = "",
                    IdAgencia = 0
                };



                RegistroEnvioDTO reg = new RegistroEnvioDTO
                {
                    IdEmpleadoResponable = HttpContext.Session.GetInt32("LogeadoId"),
                    EmailCliente = model.EmailCliente,
                    Peso = model.Peso,
                    TipoEnvio = model.TipoEnvio,
                    IdAgencia = model.IdAgencia,
                    IdCiudad = model.IdCiudad,
                    direccion = model.direccion
                };
                try
                {
                    CUAltaEnvio.RegistroEnvio(reg);
                }
                catch (DatosInvalidosException ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                catch (PermisosException ex)
                {
                    ViewBag.ErrorMessage = ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Ha ocurrido un error inesperado";
                }
                return View(model2);
            }
            else
            {
                return RedirectToAction("NoAutorizado", "Auth");
            }


        }
    }
}
