using System.Linq.Expressions;

namespace Comum.Excecoes;

public class ViolacaoDeRegra
{
    public LambdaExpression Propriedade { get; internal set; }
    public string Mensagem { get; internal set; }
}
