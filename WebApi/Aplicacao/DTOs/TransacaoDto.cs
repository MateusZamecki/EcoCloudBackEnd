using System;

namespace Aplicacao.DTOs;

public class TransacaoDto
{
    public int Id { get; set; }
    public int IdDaColuna { get; set; }
    public string Nome { get; set; }
    public double Quantia { get; set; }
    public DateTime DataDeCriacao { get; set; }
    public bool Ativo { get; set; }
    public bool Desativado { get; set; }
    public int Classificacao { get; set; }
}
