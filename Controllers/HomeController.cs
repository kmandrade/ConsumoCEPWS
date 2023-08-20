using ConsumoCEPWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace ConsumoCEPWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> BuscarEndereco(CepViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cep = model.CEP.Replace("-", "");

                ViewBag.MostrarPartial = true;
            }
            return View("Index");
        }
    }
}