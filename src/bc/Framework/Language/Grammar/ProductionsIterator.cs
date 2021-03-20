using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language.Grammar
{
    public class ProductionsIterator
    {
        public Random Random { get; init; } = new Random(312);
        public ProductionsIterator(IEnumerable<Production> productions)
        {
            Productions = productions.ToImmutableHashSet();

            RulesMap = new Dictionary<string, Production>();
            foreach (var production in Productions)
            {
                if (!RulesMap.ContainsKey(production.Head))
                    RulesMap.Add(production.Head, production);
            }

            var tempMap = new Dictionary<string, ISet<(double p, string body)>>();
            foreach (var production in Productions)
            {
                if (!tempMap.ContainsKey(production.Head))
                {
                    tempMap.Add(production.Head, new HashSet<(double p, string body)>());
                }
                tempMap[production.Head].Add((production.Probability, production.Body));
            }

            // copy to prob map
            foreach (var kv in tempMap)
            {
                ProbableProductions.Add(kv.Key, new ProbabilisticValue<string> { Items = kv.Value, Random = Random, });
            }
        }

        public ISet<Production> Productions { get; private init; }

        private Dictionary<string, ProbabilisticValue<string>> ProbableProductions { get; set; } = new Dictionary<string, ProbabilisticValue<string>>();

        private IDictionary<string, Production> RulesMap;

        public string Generate(string input)
        {
            string output = "";
            foreach (var c in input)
            {
                // output += RulesMap.ContainsKey(c.ToString()) ? RulesMap[c.ToString()].Body : c.ToString();
                output += ProbableProductions.ContainsKey(c.ToString()) ? ProbableProductions[c.ToString()].Value : c.ToString();
            }
            return output;
        }

        public string GenerateV2(string input)
        {
            string output = "";
            for (int pos = 0; pos < input.Length; pos++)
            {
                var possibles = new List<(double, Production)>();
                foreach (var p in Productions)
                {
                    if (p.Matches(input, pos))
                    {
                        possibles.Add((p.Probability > 0 ? p.Probability : 1.0, p));
                    }
                }
                if (possibles.Count > 0)
                {
                    var ps = new ProbabilisticValue<Production> { Items = possibles, Random = Random, };
                    var p = ps.Value;
                    output += p.Body;
                    pos += p.Head.Length - 1;
                }
                else
                {
                    output += input[pos];
                }
            }
            return output;
        }

        public static bool ProductionMatches(Production p, string s, int position)
        {
            if (s.Length - position < p.Head.Length + p.Next?.Length)
                return false;

            if (position < p.Precedent?.Length)
                return false;

            if (!p.Head.Equals(s.Substring(position, p.Head.Length)))
                return false;

            if (p.Precedent?.Length > 0 && !p.Precedent.Equals(s.Substring(position - p.Precedent.Length, p.Precedent.Length)))
                return false;

            if (p.Next?.Length > 0 && !p.Next.Equals(s.Substring(position + p.Head.Length, p.Next.Length)))
                return false;

            return true;
        }

    }
}