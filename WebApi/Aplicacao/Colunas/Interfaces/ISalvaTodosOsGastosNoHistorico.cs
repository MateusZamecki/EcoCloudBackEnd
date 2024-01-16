using System.Threading.Tasks;

namespace Aplicacao.Colunas.Interfaces;

public interface ISalvaTodasAsTransacoesNoHistorico
{
    Task Salvar(int idDaColuna);
}
