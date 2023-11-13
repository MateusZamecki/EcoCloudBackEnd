namespace Comum.Excecoes;

public class ExcecaoDeDominio : Excecao
{
    public ExcecaoDeDominio() : base("") { }

    public ExcecaoDeDominio(string message) : base(message)
    {
    }

    public static ExcecaoDeDominio UmaExcecao()
    {
        return new ExcecaoDeDominio();
    }
}
