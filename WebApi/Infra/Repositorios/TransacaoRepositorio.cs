using Dominio.Transacoes;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
{
    public TransacaoRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
