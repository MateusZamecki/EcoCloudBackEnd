using Aplicacao.DTOs;
using Dominio.Colunas;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaConfiguracaoDto
{
    public static ConfiguracaoDto ObterDto(this Configuracao configuracao)
    {
        return new ConfiguracaoDto
        {
            Id = configuracao.Id,
            Data = configuracao.Data,
            IntervaloDeDias = configuracao.IntervaloDeDias
        };
    }

    public static List<ConfiguracaoDto> ObterDto(this List<Configuracao> configuracoes)
    {
        return configuracoes.Select(ObterDto).ToList();
    }
}
