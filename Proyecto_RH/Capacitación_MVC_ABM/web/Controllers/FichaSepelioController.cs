using Microsoft.AspNetCore.Mvc;

namespace web.Controllers
{
    public class FichaSepelioController : Controller
    {
        public IActionResult Consulta()
        {
            return View();
        }

        public IActionResult Agregar()
        {
            return View("Agregar");
        }

        public IActionResult Editar(int id)
        {
            ViewBag.Id = id;

            return View("Editar");
        }

    }
}