using Comum.Dominio;
using Comum.Excecoes;
using Dominio.Helpers;
using Dominio.ObjetosDeValor;
using Dominio.Transacoes;
using System.Collections.Generic;

namespace Dominio.Colunas;

public class Coluna : Entidade<Coluna>
{
    public Nome Nome { get; private set; }
    private readonly List<Transacao> _transacoes = new();
    public virtual List<Transacao> Transacoes => _transacoes;
    public Quantia TotalDasTransacoes => CalcularQuantidadeTotalDasTransacoes();
    public virtual Configuracao Configuracao { get; private set; }
    public Tipo Tipo { get; private set; }

    protected Coluna() { }

    public Coluna(Nome nome, Tipo tipo, Configuracao configuracao = null)
    {
        ValidarDadosObrigatorios(nome, tipo);
        Nome = nome;
        Tipo = tipo;
        Configuracao = configuracao;
    }

    private void ValidarDadosObrigatorios(Nome nome, Tipo tipo)
    {
        ValidarNome(nome);
        ValidarTipo(tipo);
    }

    private Quantia CalcularQuantidadeTotalDasTransacoes()
    {
        return Transacoes.Somar();
    }

    public void AdicionarTransacoes(List<Transacao> transacoes)
    {
        ValidarTransacoes(transacoes);
        _transacoes.AddRange(transacoes);
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        ValidarTransacao(transacao);
        _transacoes.Add(transacao);
    }

    public void AdicionarConfiguracao(Configuracao configuracao)
    {
        ValidarConfiguracao(configuracao);
        Configuracao = configuracao;
    }

    public void SalvarTransacoesNoHistorico()
    {
        Transacoes.ForEach(transacao => transacao.Desativar());
    }

    public void ExlcuirTransacao(Transacao transacao)
    {
        ValidarTransacao(transacao);
        _transacoes.Remove(transacao);
    }

    public void AlterarNome(Nome nome)
    {
        Nome = nome;
    }

    public void AlterarTipo(Tipo tipo)
    {
        Tipo = tipo;
    }

    private void ValidarConfiguracao(Configuracao configuracao)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(configuracao, MensagensDeExcecao.ErroAoAdicionarConfiguracaoNaColuna)
            .EntaoDispara();
    }

    private void ValidarTransacoes(List<Transacao> transacoes)
    {
        new ExcecaoDeDominio()
            .QuandoEhListaNulaOuVazia(transacoes, MensagensDeExcecao.ErroAoAdicionarAsTransacoes)
            .EntaoDispara();
        transacoes.ForEach(ValidarTransacao);
    }

    private void ValidarTransacao(Transacao transacao)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(transacao, MensagensDeExcecao.ErroAoAdicionarAsTransacoes)
            .EntaoDispara();
    }

    private void ValidarTipo(Tipo tipo) 
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(tipo, MensagensDeExcecao.OTipoInformadoEhInvalido)
            .EntaoDispara();
    }

    private void ValidarNome(Nome nome)
    {
        new ExcecaoDeDominio()
        .QuandoEhNulo(nome, MensagensDeExcecao.EhObrigatorioInformarUmNome)
        .EntaoDispara();
    }
}
