using CasosDeUso.DTOs.Envio;
using CasosDeUso.InterfacesCasosUso;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class EnviosController : Controller
    {
        public IObtenerAgencias CUObtenerAgencias { get; set; }
        public IObtenerCiudades CUObtenerCiudades { get; set; }

        


        public EnviosController(IObtenerAgencias cUObtenerAgencias, IObtenerCiudades cUObtenerCiudades)
        {
            CUObtenerAgencias = cUObtenerAgencias;
            CUObtenerCiudades = cUObtenerCiudades;
        }



        public IActionResult AltaEnvio()
        {
            if (HttpContext.Session.GetString("LogeadoRol") == "Administrador" || true)
            {

                //Evitar carga al servidor, Extraido de ChatGPT
                IEnumerable<AgenciaDTO> agencias = CUObtenerAgencias.GetAgencias();
                IEnumerable<CiudadDTO> ciudades = CUObtenerCiudades.GetCiudades();

                TempData["Agencias"] = JsonConvert.SerializeObject(agencias);
                TempData["Ciudades"] = JsonConvert.SerializeObject(ciudades);

                TempData.Keep("Agencias");
                TempData.Keep("Ciudades");


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
            //Evitar carga al servidor, Extraido de ChatGPT
            var agenciasJson = TempData["Agencias"]?.ToString();
            var ciudadesJson = TempData["Ciudades"]?.ToString();

            var agencias = JsonConvert.DeserializeObject<List<AgenciaDTO>>(agenciasJson);
            var ciudades = JsonConvert.DeserializeObject<List<CiudadDTO>>(ciudadesJson);



            AgenciaDTO a = agencias.FirstOrDefault(x => x.Id == model.IdAgencia);
            CiudadDTO c = ciudades.FirstOrDefault(x => x.Id == model.IdCiudad);
            model.direccion.Ciudad = c;

            RegistroEnvioDTO reg = new RegistroEnvioDTO
            {
                IdEmpleadoResponable = 1 /*int.Parse(HttpContext.Session.GetString("LogeadoId"))*/,
                EmailCliente = model.EmailCliente,
                Peso = model.Peso,
                TipoEnvio = model.TipoEnvio,
                Agencia = a,
                direccion = model.direccion
            };
            
            return View();
        }
    }
}
