using Comum.Excecoes;
using Comum.ObjetosDeValor;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dominio.ObjetosDeValor;

public class Email : ObjetoDeValor
{
    public string Valor { get; private set; }
    public static readonly Regex _padraoDeEmail = new Regex(
        @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$");

    protected Email()
    {
    }

    private Email(string valor) 
    {
        Valor = valor;
    }

    public static Email Criar(string valor)
    {
        ValidaConteudo(valor);
        return new Email(valor);
    }

    private static void ValidaConteudo(string valor)
    {
        new ExcecaoDeDominio()
            .QuandoEhStringVaziaOuNula(valor, MensagensDeExcecao.EmailInvalido)
            .Quando(!_padraoDeEmail.IsMatch(valor), MensagensDeExcecao.EmailInvalido)
            .EntaoDispara();
    }

    public override IEnumerable<object> ValoresAtomicos()
    {
        yield return Valor;
    }
}
