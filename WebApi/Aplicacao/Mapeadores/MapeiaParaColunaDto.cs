using Aplicacao.DTOs.Colunas;
using Comum.Helpers;
using Dominio.Colunas;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaColunaDto
{
    public static ColunaDto ObterDto(this Coluna coluna)
    {
        return new ColunaDto
        {
            Id = coluna.Id,
            Nome = coluna.Nome.Valor,
            Transacoes = coluna.Transacoes.ToList().ObterDto(),
            QuantidadeTotalDasTransacoes = coluna.TotalDasTransacoes.Valor,
            Configuracao = coluna.Configuracao is null ? null : coluna.Configuracao.ObterDto(),
            Tipo = (int)coluna.Tipo,
            TipoDescricao = coluna.Tipo.ObterDescricaoDaEnumeracao(),
        };
    }

    public static List<ColunaDto> ObterDto(this List<Coluna> colunas)
    {
        return colunas.Select(ObterDto).ToList();
    }
}
