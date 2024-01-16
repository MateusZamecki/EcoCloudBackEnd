using Aplicacao.DTOs;
using Dominio.Transacoes;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes.Interfaces;

public interface IConsultaClassificacao
{
    Task<ClassificacaoDto> Consultar(int id);
    Task<Classificacao> ConsultarClassificacao(int id);
}
