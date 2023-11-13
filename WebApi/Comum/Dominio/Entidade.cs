namespace Comum.Dominio;

public abstract class Entidade<T> where T : Entidade<T>
{
    public int Id { get; protected set; }
}
