using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language
{
    public class StochasticProduction : IProduction
    {
        private readonly IDictionary<double, string> productionMap;
        public string Head { get; init; }

        public Random Random { private get; init; } = new Random();

        public IEnumerable<StochasticValue<string>> Productions
        {
            init
            {
                productionMap = new Dictionary<double, string>();
                var currentP = 0.0;
                foreach (var v in value)
                {
                    if (v.Probability > 0.0)
                    {
                        currentP += v.Probability;
                        if (currentP > 1.0)
                        {
                            // TODO fix
                            throw new ArgumentException("Specified production probabilities exceed 1.0; probabilities must sum to 1.0");
                        }
                        productionMap.Add(currentP, v.Value);
                    }
                }
                if (currentP != 1.0)
                {
                    throw new ArgumentException($"Specified production probabilities summed to {currentP}; probabilities must sum to 1.0");
                }
            }
        }

        public string Body
        {
            get
            {
                var p = Random.NextDouble();
                var lastKey = 0.0;
                foreach (var key in productionMap.Keys.ToImmutableSortedSet())
                {
                    lastKey = key;
                    if (p < key)
                        return productionMap[key];
                }
                // shouldn't happen
                return productionMap[lastKey];
            }
        }
    }
}