using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_dotnet_infra.Interfaces.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Cadastrar(TEntity Entidade);
        void Excluir(int Id);
        List<TEntity> ListarRegistros();
        TEntity RetornarRegistro(int Id);
    }
}