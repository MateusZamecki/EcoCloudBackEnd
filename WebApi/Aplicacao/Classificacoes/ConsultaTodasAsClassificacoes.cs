using Aplicacao.Classificacoes.Interfaces;
using Aplicacao.DTOs;
using Aplicacao.Mapeadores;
using Infra.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Classificacoes;

public class ConsultaTodasAsClassificacoes : IConsultaTodasAsClassificacoes
{
    private readonly IClassificacaoRepositorio _classificacaoRepositorio;

    public ConsultaTodasAsClassificacoes(IClassificacaoRepositorio classificacaoRepositorio)
    {
        _classificacaoRepositorio = classificacaoRepositorio;
    }

    public async Task<List<ClassificacaoDto>> Consultar()
    {
        var classificacoes = await _classificacaoRepositorio.Obter();
        return classificacoes.ToList().ObterDto();
    }
}
