using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Interfaces;
using myfinance_web_dotnet_domain;

namespace myfinance_web_dotnet_infra.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(MyFinanceDbContext dbContext) : base(dbContext)
        {
        }
        public override List<Transacao> ListarRegistros()
        {
            return DbSetContext.Include(x => x.PlanoConta).ToList();
        }
    }
}