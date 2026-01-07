using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_dotnet_domain.Entities;
using myfinance_web_dotnet_infra.Data;

namespace myfinance_web_dotnet_service
{
    public class PlanoContaService : IPlanoContaService
    {

        private readonly MyFinanceDbContext _dbContext;

        public PlanoContaService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(PlanoConta Entidade)
        {
            var dbSet = _dbContext.PlanoConta;

            if(Entidade.Id == null)
            {
                dbSet.Add(Entidade);
            }
            else
            {
                dbSet.Attach(Entidade);
                _dbContext.Entry(Entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Excluir(int Id)
        {
            var PlanoConta = new PlanoConta() { Id = Id };
            _dbContext.Attach(PlanoConta);
            _dbContext.Remove(PlanoConta);
            _dbContext.SaveChanges();
        }

        public List<PlanoConta> ListarRegistros()
        {
            var dbSet = _dbContext.PlanoConta;
            return dbSet.ToList();
        }

        public PlanoConta RetornarRegistro(int Id)
        {
            return _dbContext.PlanoConta.Where(x => x.Id == Id).First();
        }
    }
}