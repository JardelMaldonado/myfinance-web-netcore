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
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ILogger<TransacaoController> logger,
        ITransacaoService transacaoService)
        {
            _logger = logger;
            _transacaoService = transacaoService;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaTransacoes = _transacaoService.ListarRegistros();
            List<TransacaoModel> listaTransacaoModel = new List<TransacaoModel>();
            foreach (var transacao in listaTransacoes)
            {
                TransacaoModel transacaoModel = new TransacaoModel();
                transacaoModel.Id = transacao.Id;
                transacaoModel.Historico = transacao.Historico;
                transacaoModel.Data = transacao.Data;
                transacaoModel.Valor = transacao.Valor;
                transacaoModel.Tipo = transacao.PlanoConta.Tipo;
                transacaoModel.PlanoContaId = transacao.PlanoContaId;
                listaTransacaoModel.Add(transacaoModel);
            }
            ViewBag.ListaTransacoes = listaTransacaoModel;
            return View();
        }
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if (Id != null)
            {
                var transacao = _transacaoService.RetornarRegistro((int)Id);
                var transacaoModel = new TransacaoModel();
                {
                    transacaoModel.Id = transacao.Id;
                    transacaoModel.Historico = transacao.Historico;
                    transacaoModel.Data = transacao.Data;
                    transacaoModel.Valor = transacao.Valor;
                    transacaoModel.PlanoContaId = transacao.PlanoContaId;

                }
                return View(transacaoModel);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(TransacaoModel model)
        {
            var transacao = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Data = model.Data,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId
            };
            _transacaoService.Cadastrar(transacao);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            _transacaoService.Excluir((int)Id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}