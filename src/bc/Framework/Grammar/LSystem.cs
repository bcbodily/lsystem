using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Grammar
{
    public struct LSystem
    {
        public IEnumerable<string> Alphabet { get; init; }
        public String Axiom { get; init; }
        public IEnumerable<Production> Productions { get; init; }

        private IDictionary<string, string> RulesMap;

        public LSystem(IEnumerable<string> letters, String axiom, IEnumerable<Production> productions)
        {
            Alphabet = letters.ToImmutableSortedSet();
            Axiom = axiom;
            Productions = productions.ToImmutableHashSet();

            RulesMap = new Dictionary<string, string>();
            foreach (var production in productions)
            {
                RulesMap.Add(production.Predecessor, production.Successor);
            }

        }

        public string Generate(string input = "")
        {
            if (input == "")
                input = Axiom;

            string output = "";
            foreach (var c in input)
            {
                output += RulesMap.ContainsKey(c.ToString()) ? RulesMap[c.ToString()] : c.ToString();
            }
            return output;
        }
    }
}