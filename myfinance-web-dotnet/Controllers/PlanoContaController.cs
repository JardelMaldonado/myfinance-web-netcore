using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet_domain;
using myfinance_web_dotnet_service;
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(ILogger<PlanoContaController> logger,
        IPlanoContaService planoContaService)
        {
            _logger = logger;
            _planoContaService = planoContaService;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();
            List<PlanoContaModel> listaPlanoContaModel = new List<PlanoContaModel>();
            foreach (var planoConta in listaPlanoContas)
            {
                PlanoContaModel planoContaModel = new PlanoContaModel();
                planoContaModel.Id = planoConta.Id;
                planoContaModel.Descricao = planoConta.Descricao;
                planoContaModel.Tipo = planoConta.Tipo;
                listaPlanoContaModel.Add(planoContaModel);
            }
            ViewBag.ListaPlanoContas = listaPlanoContaModel;
            return View();
        }
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                var planoConta = _planoContaService.RetornarRegistro((int)Id);
                var planoContaModel = new PlanoContaModel();
                {
                    planoContaModel.Id = planoConta.Id;
                    planoContaModel.Descricao = planoConta.Descricao;
                    planoContaModel.Tipo = planoConta.Tipo;

                }
                return View(planoContaModel);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(PlanoContaModel model)
        {
            var planoConta = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };
            _planoContaService.Cadastrar(planoConta);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            _planoContaService.Excluir((int)Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}