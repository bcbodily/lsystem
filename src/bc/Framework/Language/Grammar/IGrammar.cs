using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language.Grammar
{
    /// <summary>
    /// Interface to a formal grammar
    /// </summary>
    public interface IGrammar
    {
        /// <summary>
        /// The grammar nonterminal symbols
        /// </summary>
        /// <value></value>
        IImmutableSet<string> Nonterminals { get; }

        /// <summary>
        /// The grammar production rules
        /// </summary>
        /// <value></value>
        IImmutableSet<Production> Productions { get; }

        /// <summary>
        /// The grammar start symbol
        /// </summary>
        /// <value></value>
        string Start { get; }

        /// <summary>
        /// The grammar terminal symbols
        /// </summary>
        /// <value></value>
        IImmutableSet<string> Terminals { get; }
    }
}