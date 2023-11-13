using Dominio.Servicos;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class ServicosRepositorio : RepositorioBase<LogDosServicos>, IServicosRepositorio
{
    public ServicosRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
