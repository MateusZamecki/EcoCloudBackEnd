using Aplicacao.DTOs;
using Dominio.Transacoes;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaTransacaoDto
{
    public static TransacaoDto ObterDto(this Transacao transacao)
    {
        return new TransacaoDto
        {
            Id = transacao.Id,
            Nome = transacao.Nome.Valor,
            Quantia = transacao.Quantia.Valor,
            DataDeCriacao = transacao.DataDeCriacao,
            Ativo = transacao.Ativo,
            Desativado = transacao.Desativado
        };
    }

    public static List<TransacaoDto> ObterDto(this List<Transacao> transacoes)
    {
        return transacoes.Select(ObterDto).ToList();
    }
}
