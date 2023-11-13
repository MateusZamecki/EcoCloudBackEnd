using System;
using System.Collections.Generic;
using System.Linq;

namespace Comum.ObjetosDeValor;

public abstract class ObjetoDeValor : IEquatable<ObjetoDeValor>
{
    public abstract IEnumerable<object> ValoresAtomicos();

    public override bool Equals(object? obj)
    {
        return obj is ObjetoDeValor outro && ValidarSeValoresSaoIguais(outro);
    }

    public override int GetHashCode()
    {
        return ValoresAtomicos().Aggregate(default(int),HashCode.Combine);
    }

    private bool ValidarSeValoresSaoIguais(ObjetoDeValor outro)
    {
        return ValoresAtomicos().SequenceEqual(outro.ValoresAtomicos());
    }

    public bool Equals(ObjetoDeValor outro)
    {
        return outro is not null && ValidarSeValoresSaoIguais(outro);
    }
}
