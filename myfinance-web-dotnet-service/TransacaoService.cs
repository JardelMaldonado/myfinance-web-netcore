using myfinance_web_dotnet_domain;       
using myfinance_web_dotnet_infra;        
using myfinance_web_dotnet_service.Interfaces;

namespace myfinance_web_dotnet_service{
    public class TransacaoService : ITransacaoService
    {

        private readonly MyFinanceDbContext _dbContext;

        public TransacaoService(MyFinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Cadastrar(Transacao Entidade)
        {
            var dbSet = _dbContext.Transacao;

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
            var Transacao = new Transacao() { Id = Id };
            _dbContext.Attach(Transacao);
            _dbContext.Remove(Transacao);
            _dbContext.SaveChanges();
        }

        public List<Transacao> ListarRegistros()
        {
            var dbSet = _dbContext.Transacao;
            return dbSet.ToList();
        }

        public Transacao RetornarRegistro(int Id)
        {
            return _dbContext.Transacao.Where(x => x.Id == Id).First();
        }
    }
}