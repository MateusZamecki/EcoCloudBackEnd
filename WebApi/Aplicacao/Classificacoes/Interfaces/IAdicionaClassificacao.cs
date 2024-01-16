using Aplicacao.DTOs;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes.Interfaces;

public interface IAdicionaClassificacao
{
    Task Adicionar(ClassificacaoDto classificacaoDto);
}
