using System.Collections.Generic;

namespace bc.Framework.Language
{
    public interface IGrammar
    {
        ISet<string> NonterminalSymbols { get; }
        ISet<Production> Productions { get; }
        string StartSymbol { get; }
        ISet<string> TerminalSymbols { get; }
    }
}