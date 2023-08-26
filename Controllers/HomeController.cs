using ConsumoCEPWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Correios;
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
        public async Task<ActionResult> BuscarEndereco(EnderecoViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cep = model.CEP.Replace("-", "");
                model = await ObterDadosEndereco(cep);
                ViewBag.MostrarPartial = true;
                return View("Index", model);
            }
            _logger.LogError("Endereco não encontrado.");
            return View("Index");
        }
        private async Task<EnderecoViewModel> ObterDadosEndereco(string cep)
        {
            _logger.LogInformation("Buscando Dados Endereco");
            var modelCorreios = new AtendeClienteClient();
            var endereco = await modelCorreios.consultaCEPAsync(cep);
            return new EnderecoViewModel
            {
                Bairro = endereco.@return.bairro,
                CEP = cep,
                Cidade = endereco.@return.cidade,
                Estado = endereco.@return.uf,
                Rua = endereco.@return.end
            };
        }
    }
}