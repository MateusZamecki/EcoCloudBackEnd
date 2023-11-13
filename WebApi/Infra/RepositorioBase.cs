using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra;

public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : class
{
    protected Contexto _contexto;
    public readonly DbSet<TEntidade> _DbSet;
    public bool _salvarAlteracoes = true;

    public RepositorioBase(Contexto contexto)
    {
        _DbSet = contexto.Set<TEntidade>();
        _contexto = contexto;
    }

    public async Task<IEnumerable<TEntidade>> Obter(Expression<Func<TEntidade, bool>> filtro = null)
    {
        var query = _DbSet.AsQueryable();

        if (filtro != null)
            query = query.Where(filtro).AsNoTracking();

        return await query.ToListAsync();
    }

    public async Task<TEntidade> ObterPorId(int id)
    {
        return await _DbSet.FindAsync(id);
    }

    public async Task Adicionar(TEntidade entidade)
    {
        await _DbSet.AddAsync(entidade);
        await _contexto.SaveChangesAsync();
    }

    public async Task Adicionar(IEnumerable<TEntidade> entidades)
    {
        await _DbSet.AddRangeAsync(entidades);
        await _contexto.SaveChangesAsync();
    }

    public async Task Excluir(TEntidade entidade)
    {
        _DbSet.Remove(entidade);
        await _contexto.SaveChangesAsync();
    }

    public async Task Excluir(int id)
    {
        var entidade = await _DbSet.FindAsync(id);
        _DbSet.Remove(entidade);
        await _contexto.SaveChangesAsync();
    }

    public async Task Atualizar(TEntidade entidade)
    {
        _DbSet.Update(entidade);
        await _contexto.SaveChangesAsync();
    }

    public async Task Excluir(IEnumerable<TEntidade> objetos)
    {
        _DbSet.RemoveRange(objetos);
        await _contexto.SaveChangesAsync();
    }
}
