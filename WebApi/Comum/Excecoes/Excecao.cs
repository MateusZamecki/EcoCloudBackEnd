using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Comum.Excecoes;

public abstract class Excecao : Exception
{
    protected readonly Expression<Func<object, object>> _objeto = x => x;
    protected readonly IList<ViolacaoDeRegra> _erros = new List<ViolacaoDeRegra>();

    public Excecao() : base("") { }

    public Excecao(string message) : base(message)
    {
    }

    public Excecao(string message, Exception innerException) : base(message, innerException)
    {
    }

    public IEnumerable<ViolacaoDeRegra> Erros => _erros;

    public void DispararComMensagem(string mensagemDeErro)
    {
        _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        throw this;
    }

    public bool PossuiErroComAMensagemIgualA(string mensagemDeErro)
    {
        return _erros.Any(e => e.Mensagem.Equals(mensagemDeErro));
    }

    public void EntaoDispara()
    {
        if (_erros.Any())
            throw this;
    }

    public override string Message => ToString();

    public override string ToString()
    {
        var texto = new StringBuilder();
        foreach (var erro in _erros)
            texto.AppendLine(erro.Mensagem);

        return texto.ToString();
    }

    public Excecao Quando(bool condicao, string mensagemDeErro)
    {
        if (condicao) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }

    public Excecao QuandoEhData(string data, string mensagemDeErro)
    {
        var datatime = DateTime.Now;
        if (!DateTime.TryParse(data, new CultureInfo("pt-BR"), DateTimeStyles.None, out datatime)) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }

    public Excecao QuandoEhStringVaziaOuNula(string campo, string mensagemDeErro)
    {
        if (string.IsNullOrWhiteSpace(campo)) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }

    public Excecao QuandoEhStringMaiorQue(string campo, int tamanhoMaximo, string mensagemDeErro)
    {
        if (campo != null && campo.Length > tamanhoMaximo)
            _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });

        return this;
    }

    public Excecao QuandoEhNulo(object objeto, string mensagemDeErro)
    {
        if (objeto == null) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }

    public Excecao QuandoEhListaNulaOuVazia(IEnumerable<object> lista, string mensagemDeErro)
    {
        if (lista == null || !lista.Any()) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }

    public Excecao QuandoDataEhMenorQueADataAtual(DateTime data, string mensagemDeErro)
    {
        if (data < DateTime.Now) _erros.Add(new ViolacaoDeRegra { Propriedade = _objeto, Mensagem = mensagemDeErro });
        return this;
    }
}
