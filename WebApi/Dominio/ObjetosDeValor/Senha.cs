using Comum.Excecoes;
using Comum.ObjetosDeValor;
using System.Collections.Generic;

namespace Dominio.ObjetosDeValor;

public class Senha : ObjetoDeValor
{
    public const int TamanhoMaximo = 50;
    public string Valor { get; private set; }

    private Senha(string valor)
    {
        Valor = valor;
    }
    public static Senha Criar(string valor)
    {
        ValidarConteudo(valor);
        return new Senha(valor);
    }

    private static void ValidarConteudo(string valor)
    {
        new ExcecaoDeDominio()
            .QuandoEhStringVaziaOuNula(valor, "Senha inválida.")
            .Quando(valor.Length > TamanhoMaximo, "Senha inválida.")
            .EntaoDispara();
    }

    public override IEnumerable<object> ValoresAtomicos()
    {
        yield return Valor;
    }
}
