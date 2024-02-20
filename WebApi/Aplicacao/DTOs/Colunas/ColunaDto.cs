using System.Collections.Generic;
using Aplicacao.DTOs.Configuracao;
using Aplicacao.DTOs.Transacoes;

namespace Aplicacao.DTOs.Colunas;

public class ColunaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int IdDoQuadro { get; set; }
    public double QuantidadeTotalDasTransacoes { get; set; }
    public List<TransacaoDto> Transacoes { get; set; }
    public ConfiguracaoDto Configuracao { get; set; }
    public int Tipo { get; set; }
    public string TipoDescricao { get; set; }
}
