using System;
using System.Collections.Generic;

namespace bc.Framework
{
    public class ProbabilisticValue<T> where T : IEquatable<T>
    {
        public Random Random { private get; init; } = new Random();

        public IEnumerable<(double p, T item)> Items
        {
            init
            {
                foreach (var item in value)
                {
                    AddItem(item.p, item.item);
                }
            }
        }

        public IEnumerable<T> EqualItems
        {
            init
            {
                foreach (var item in value)
                {
                    AddItem(1.0, item);
                }
            }
        }

        public T Value
        {
            get
            {
                BuildMapping();
                var roll = Random.NextDouble();
                foreach (var key in mapping.Keys)
                {
                    if (key > roll)
                    {
                        return mapping[key];
                    }
                }

                throw new Exception("should be impossible");
            }
        }

        private ISet<(double p, T item)> PossibleValues { get; } = new HashSet<(double p, T item)>();

        private SortedDictionary<double, T> mapping { get; } = new SortedDictionary<double, T>();


        private void AddItem(double probability, T item)
        {
            if (probability <= 0)
            {
                throw new ArgumentException($"{nameof(probability)} is '{probability}'; {nameof(probability)} must be greater than 0");
            }

            PossibleValues.Add((p: probability, item: item));
        }

        private void BuildMapping()
        {
            // calc total weight
            var total = 0.0;
            foreach (var item in PossibleValues)
            {
                total += item.p;
            }

            // place items in mapping
            mapping.Clear();
            var current = 0.0;
            foreach (var item in PossibleValues)
            {
                current += (item.p / total);
                mapping.Add(current, item.item);
            }
        }
    }
}