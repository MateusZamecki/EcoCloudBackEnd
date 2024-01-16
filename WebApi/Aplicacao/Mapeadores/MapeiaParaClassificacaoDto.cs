using Aplicacao.DTOs;
using Dominio.Transacoes;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaClassificacaoDto
{
    public static ClassificacaoDto ObterDto(this Classificacao classificacao)
    {
        return new ClassificacaoDto
        {
            Id = classificacao.Id,
            Nome = classificacao.Nome.Valor,
            Cor = classificacao.Cor,
        };
    }

    public static List<ClassificacaoDto> ObterDto(this List<Classificacao> classificacoes)
    {
        return classificacoes.Select(ObterDto).ToList();
    }
}
