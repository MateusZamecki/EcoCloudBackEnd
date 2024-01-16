using Aplicacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes.Interfaces;

public interface IConsultaTodasAsClassificacoes
{
    Task<List<ClassificacaoDto>> Consultar();
}
