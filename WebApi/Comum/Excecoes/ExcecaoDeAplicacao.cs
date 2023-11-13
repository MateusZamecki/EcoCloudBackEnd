namespace Comum.Excecoes;

public class ExcecaoDeAplicacao : Excecao
{

    public ExcecaoDeAplicacao() : base("")
    {
    }

    public ExcecaoDeAplicacao(string message) : base(message)
    {
    }
}
