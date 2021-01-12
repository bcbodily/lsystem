using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language
{
    public class ProductionsIterator
    {
        public ProductionsIterator(ISet<IProduction> productions)
        {
            Productions = productions.ToImmutableHashSet();

            RulesMap = new Dictionary<string, IProduction>();
            foreach (var production in Productions)
            {
                RulesMap.Add(production.Head, production);
            }
        }

        public ISet<IProduction> Productions { get; private init; }

        private IDictionary<string, IProduction> RulesMap;

        public string Generate(string input)
        {
            string output = "";
            foreach (var c in input)
            {
                output += RulesMap.ContainsKey(c.ToString()) ? RulesMap[c.ToString()].Body : c.ToString();
            }
            return output;
        }

    }
}