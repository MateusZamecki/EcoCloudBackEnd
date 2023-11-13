using Aplicacao.DTOs;
using Dominio.Quadros;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacao.Mapeadores;

public static class MapeiaParaQuadroDto
{
    public static QuadroDto ObterDto(this Quadro quadro)
    {
        return new QuadroDto
        {
            Id = quadro.Id,
            Nome = quadro.Nome.Valor,
            Colunas = quadro.Colunas.ObterDto(),
        };
    }

    public static List<QuadroDto> ObterDto(this List<Quadro> quadros)
    {
        return quadros.Select(ObterDto).ToList();
    }
}
