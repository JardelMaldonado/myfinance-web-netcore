using System.ComponentModel.DataAnnotations;

namespace myfinance_web_dotnet_domain.Entities.Base
{
    public class EntityBase
    {
        [Key]
        public int? Id { get; set; }
    }
}