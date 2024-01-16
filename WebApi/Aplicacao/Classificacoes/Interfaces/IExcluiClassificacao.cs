using System.Threading.Tasks;

namespace Aplicacao.Classificacoes.Interfaces;

public interface IExcluiClassificacao
{
    Task Excluir(int idDaClassificacao);
}
