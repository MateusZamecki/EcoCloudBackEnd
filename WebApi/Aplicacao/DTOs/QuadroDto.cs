using System.Collections.Generic;
using Aplicacao.DTOs.Colunas;

namespace Aplicacao.DTOs;

public class QuadroDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<ColunaDto> Colunas { get; set; }
}
