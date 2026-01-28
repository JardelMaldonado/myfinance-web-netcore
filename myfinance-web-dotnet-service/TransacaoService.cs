using System.Security.Cryptography.X509Certificates;
using myfinance_web_dotnet_domain;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_dotnet_service
{
    public class TransacaoService : ITransacaoService
    {

        private readonly ITransacaoRepository _transacaoRepository;
        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }
        public void Cadastrar(Transacao Entidade)
        {
            _transacaoRepository.Cadastrar(Entidade);
        }
        public void Excluir(int Id)
        {
            _transacaoRepository.Excluir(Id);
        }
        public List<Transacao> ListarRegistros()
        {
            return _transacaoRepository.ListarRegistros();
        }
        public Transacao RetornarRegistro(int Id)
        {
            return _transacaoRepository.RetornarRegistro(Id);
        }
    }
}