using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.Repositorios.Interfaces;

public interface IRepositorioBase<TEntidade> where TEntidade : class
{
    Task<IEnumerable<TEntidade>> Obter(Expression<Func<TEntidade, bool>> filtro = null);
    Task<TEntidade> ObterPorId(int id);
    Task Adicionar(TEntidade objeto);
    Task Adicionar(IEnumerable<TEntidade> objetos);
    Task Atualizar(TEntidade objeto);
    Task Excluir(TEntidade objeto);
    Task Excluir(int id);
    Task Excluir(IEnumerable<TEntidade> objetos);
}
