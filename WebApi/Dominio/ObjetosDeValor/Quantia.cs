using Comum.Excecoes;
using Comum.ObjetosDeValor;
using System.Collections.Generic;

namespace Dominio.ObjetosDeValor;

public class Quantia : ObjetoDeValor
{
    public double Valor { get; private set; }

    public Quantia(double valor) 
    { 
        Valor = valor;
    }

    public static Quantia Criar(double valor = 0)
    {
        ValidarConteudo(valor);
        return new Quantia(valor);
    }

    private static void ValidarConteudo(double valor)
    {
        new ExcecaoDeDominio()
           .Quando(valor < 0, MensagensDeExcecao.QuantiaInformadaEhInvalida)
           .EntaoDispara();
    }

    public override IEnumerable<object> ValoresAtomicos()
    {
        yield return Valor;
    }

    public void Adicionar(double valor)
    {
        ValidarConteudo(valor);
        Valor += valor;
    }

    public void Remover(double valor)
    {
        ValidarConteudo(valor);
        Valor -= valor;
    }
}
