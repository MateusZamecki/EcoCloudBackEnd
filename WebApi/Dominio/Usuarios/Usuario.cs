using Comum.Dominio;
using Comum.Excecoes;
using Comum.Helpers;
using Dominio.ObjetosDeValor;
using Dominio.Quadros;
using System;
using System.Collections.Generic;

namespace Dominio.Usuarios;

public class Usuario : Entidade<Usuario>
{
    public Nome Nome { get; private set; }
    public Email Email { get; private set; }
    private List<Quadro> _quadros = new List<Quadro>();
    public virtual List<Quadro> Quadros => _quadros;
    public DateTime DataDeCriacao { get; private set; }

    protected Usuario() { }

    public Usuario(Nome nome, Email email)
    {
        Nome = nome;
        Email = email;
        DataDeCriacao = ObtemADataAtualEHorarioDeBrasilia.Obter();
    }

    public void AdicionarQuadro(Quadro quadro)
    {
        ValidarQuadro(quadro);
        _quadros.Add(quadro);
    }

    private void ValidarQuadro(Quadro quadro)
    {
        new ExcecaoDeDominio()
            .QuandoEhNulo(quadro, MensagensDeExcecao.OQuadroInformadoEhInvalido)
            .EntaoDispara();
    }
}
