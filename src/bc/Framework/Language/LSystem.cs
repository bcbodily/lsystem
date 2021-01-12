using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language
{
    public struct LSystem
    {
        public ISet<string> Alphabet { get; init; }
        public String Axiom { get; init; }
        public IEnumerable<IProduction> Productions { get; init; }

        private IDictionary<string, IProduction> RulesMap;

        public LSystem(IEnumerable<string> letters, String axiom, IEnumerable<IProduction> productions)
        {
            Alphabet = letters.ToImmutableSortedSet();
            Axiom = axiom;
            Productions = productions.ToImmutableHashSet();

            RulesMap = new Dictionary<string, IProduction>();
            foreach (var production in productions)
            {
                RulesMap.Add(production.Head, production);
            }

        }

        public string Generate(string input = "")
        {
            if (input == "")
                input = Axiom;

            string output = "";
            foreach (var c in input)
            {
                output += RulesMap.ContainsKey(c.ToString()) ? RulesMap[c.ToString()].Body : c.ToString();
            }
            return output;
        }
    }
}