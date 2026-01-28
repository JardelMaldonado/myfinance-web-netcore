using myfinance_web_dotnet_domain;       
using myfinance_web_dotnet_infra.Interfaces;        
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service.Interfaces
{
    public interface ITransacaoService : ITransacaoRepository
    {
    }
}