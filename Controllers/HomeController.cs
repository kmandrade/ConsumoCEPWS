using ConsumoCEPWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Correios;
using Microsoft.Extensions.Caching.Memory;

namespace ConsumoCEPWS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> BuscarEndereco(EnderecoViewModel model)
        {
            string cacheKey = "Endereco";
            EnderecoViewModel Endereco;
            if (ModelState.IsValid)
            {
                if (!_cache.TryGetValue(cacheKey, out Endereco))
                {
                    ViewBag.MostrarPartial = true;
                    string cep = model.CEP.Replace("-", "");
                    Endereco = await ObterDadosEndereco(cep);
                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(160));
                    _cache.Set(cacheKey, Endereco, cacheOptions);
                    return View("Index", Endereco);
                }
                else
                {
                    var EnderecoModel = await _cache.GetOrCreateAsync<EnderecoViewModel>(cacheKey, async entry =>
                    {
                        entry.SlidingExpiration = TimeSpan.FromSeconds(10);
                        entry.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30);
                        string cep = model.CEP.Replace("-", "");
                        return await ObterDadosEndereco(cep);
                    });
                    ViewBag.MostrarPartial = (EnderecoModel != null);
                    return View("Index", EnderecoModel);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Endereço não encontrado.";
                _logger.LogError("Endereco não encontrado.");
                return View("Index");
            }

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