using System.Threading.Tasks;

namespace Aplicacao.Configuracoes.Interfaces;

public interface IExcluiConfiguracao
{
    Task Excluir(int idDaConfiguracao);
}
