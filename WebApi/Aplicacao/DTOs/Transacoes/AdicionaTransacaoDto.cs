namespace Aplicacao.DTOs.Transacoes;

public class AdicionaTransacaoDto
{
    public int IdDaColuna { get; set; }
    public string Nome { get; set; }
    public double Quantia { get; set; }
    public string Descricao { get; set; }
    public int IdDaClassificacao { get; set; }
    public bool EhRecorrente { get; set; }
}
