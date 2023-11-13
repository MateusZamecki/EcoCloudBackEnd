using Dominio.Colunas;
using Infra.ConexaoComBanco;
using Infra.Repositorios.Interfaces;

namespace Infra.Repositorios;

public class ConfiguracaoRepositorio : RepositorioBase<Configuracao>, IConfiguracaoRepositorio
{
    public ConfiguracaoRepositorio(Contexto contexto) : base(contexto)
    {
    }
}
