using System;

namespace Aplicacao.DTOs.Transacoes;

public class AlteraTransacaoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Quantia { get; set; }
    public DateTime DataDeCriacao { get; set; }
    public int IdDaClassificacao { get; set; }
    public string Descricao { get; set; }
    public bool EhRecorrente { get; set; }
}
