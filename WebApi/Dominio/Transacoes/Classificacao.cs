using Comum.Dominio;
using Comum.Excecoes;
using Dominio.ObjetosDeValor;

namespace Dominio.Transacoes;

public class Classificacao : Entidade<Classificacao>
{
    public Nome Nome { get; private set; }
    public string Cor { get; private set; }

    protected Classificacao() { }

    public Classificacao(Nome nome, string cor)
    {
        ValidarDadosObrigatorios(nome, cor);
        Nome = nome;
        Cor = cor.ToLower();
    }

    public void AlterarNome(Nome nome)
    {
        ValidarNome(nome);
        Nome = nome;
    }

    public void AlterarCor(string cor)
    {
        ValidarCor(cor);
        Cor = cor.ToLower();
    }

    private void ValidarDadosObrigatorios(Nome nome, string cor)
    {
        ValidarNome(nome);
        ValidarCor(cor);
    }

    private void ValidarCor(string cor)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhStringVaziaOuNula(cor, MensagensDeExcecao.ACorInformadaEhInvalida)
            .EntaoDispara();
    }

    private void ValidarNome(Nome nome)
    {
        new ExcecaoDeAplicacao()
            .QuandoEhNulo(nome, MensagensDeExcecao.ONomeInformadoEhInvalido)
            .EntaoDispara();
    }
}
