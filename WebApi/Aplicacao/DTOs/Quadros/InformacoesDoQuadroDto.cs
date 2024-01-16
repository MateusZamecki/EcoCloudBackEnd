using Aplicacao.DTOs.Colunas;
using System.Collections.Generic;

namespace Aplicacao.DTOs.Quadros;

public class InformacoesDoQuadroDto : QuadroDto
{
    public List<ColunaDto> Colunas { get; set; }
}
