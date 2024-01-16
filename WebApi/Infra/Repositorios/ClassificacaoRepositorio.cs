using Dominio.Transacoes;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class ClassificacaoRepositorio : RepositorioBase<Classificacao>, IClassificacaoRepositorio
{
    public ClassificacaoRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
