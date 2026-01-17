using Microsoft.AspNetCore.Mvc.Rendering;
using myfinance_web_dotnet_domain;
using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Informe um histórico para a transação")]
        [StringLength(50, ErrorMessage = "O histórico deve ter no máximo 50 caracteres")]
        public string? Historico { get; set; }
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime? Data { get; set; }
        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        public decimal? Valor { get; set; }
        [Required(ErrorMessage = "Selecione um plano de contas")]
        public int? PlanoContaId { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<SelectListItem>? ListaPlanoContas { get; set; }
    }
}