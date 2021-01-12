using System.Collections.Generic;

namespace bc.Framework.Language
{
    public interface IGrammar
    {
        ISet<IProduction> Productions { get; }
    }
}