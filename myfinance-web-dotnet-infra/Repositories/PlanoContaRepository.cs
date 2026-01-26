using Microsoft.EntityFrameworkCore;    
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_domain;

namespace myfinance_web_dotnet_infra.Repositories
{
    public class PlanoContaRepository : Repository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }
    }
}