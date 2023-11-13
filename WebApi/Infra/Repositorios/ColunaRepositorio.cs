using Dominio.Colunas;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositorios;

public class ColunaRepositorio : RepositorioBase<Coluna>, IColunaRepositorio
{
    public ColunaRepositorio(Contexto contexto) : base(contexto)
    {
    }

    public async Task<Coluna> ConsultarHistorico(int idDaColuna)
    {
        var coluna = await _contexto.Set<Coluna>()
            .IgnoreQueryFilters()
            .Where(coluna => coluna.Id == idDaColuna)
            .Include(coluna => coluna.Transacoes.Where(transacao => !transacao.Ativo))
            .FirstOrDefaultAsync();

        return coluna;
    }
}
