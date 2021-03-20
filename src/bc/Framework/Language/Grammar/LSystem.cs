using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language.Grammar
{
    /// <summary>
    /// A context-free L-system
    /// </summary>
    public struct LSystem : IGrammar
    {
        /// <summary>
        /// The grammar symbols, including both nonterminals and terminals
        /// </summary>
        /// <value></value>
        public IImmutableSet<string> Alphabet { get; init; }

        /// <summary>
        /// The grammar symbols that can be replaced
        /// </summary>
        /// <value></value>
        public IImmutableSet<string> Nonterminals { get; init; }

        /// <summary>
        /// The grammar production rules
        /// </summary>
        /// <value></value>
        public IImmutableSet<Production> Productions { get; init; }

        /// <summary>
        /// The symbol, or symbols, that define the initial state of the L-system
        /// </summary>
        /// <value></value>
        public string Start { get; init; }

        /// <summary>
        /// The grammar symbols that cannot be replaced
        /// </summary>
        /// <value></value>
        public IImmutableSet<string> Terminals { get; init; }

        /// <summary>
        /// Creates a new <see cref="LSystem"/> with a specified alphabet, axiom, and productions
        /// </summary>
        /// <param name="alphabet">the grammar alphabet</param>
        /// <param name="axiom">the grammar axiom</param>
        /// <param name="productions">the grammar productions</param>
        public LSystem(IEnumerable<string> alphabet, string axiom, IEnumerable<Production> productions)
        {
            Start = axiom;
            Nonterminals = GetNonterminals(productions).ToImmutableSortedSet();
            Terminals = GetTerminals(productions).ToImmutableSortedSet();
            Productions = productions.ToImmutableHashSet();
            Alphabet = alphabet.ToImmutableSortedSet();
        }

        /// <summary>
        /// Returns the set of symbols that serve as nonterminals
        /// </summary>
        /// <param name="productions">the grammar production rules that will determine the nonterminal set</param>
        /// <returns></returns>
        private static IEnumerable<string> GetNonterminals(IEnumerable<Production> productions)
        {
            var nonterminals = new SortedSet<string>();
            foreach (var production in productions)
            {
                nonterminals.Add(production.Head);
            }
            return nonterminals;
        }

        /// <summary>
        /// Returns the set of symbols that serve as terminals
        /// </summary>
        /// <param name="productions">the grammar production rules that will determine the terminal set</param>
        /// <returns></returns>
        private static IEnumerable<string> GetTerminals(IEnumerable<Production> productions)
        {
            var terminals = new SortedSet<string>();
            var nonterminals = GetNonterminals(productions);
            foreach (var production in productions)
            {
                terminals.Add(production.Body);
            }
            terminals.ExceptWith(nonterminals);

            return terminals;
        }
    }
}