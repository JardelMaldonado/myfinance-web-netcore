using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet_domain;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        public string Historico { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int PlanoContaId { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<SelectListItem>? ListaPlanoContas { get; set; }
    }
}