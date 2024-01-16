using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes.Interfaces;

public interface IAlteraClassificacao
{
    Task Alterar(ClassificacaoDto classificacaoDto);
}
