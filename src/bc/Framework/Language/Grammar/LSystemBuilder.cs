using System;
using System.Collections.Generic;

namespace bc.Framework.Language.Grammar
{
    /// <summary>
    /// An <see cref="IBuilder{t}"/> that builds instances of <see cref="LSystem"/>
    /// </summary>
    public class LSystemBuilder : IBuilder<LSystem>
    {
        /// <summary>
        /// Alias for <see cref="Start"/>
        /// </summary>
        /// <value></value>
        public string Axiom
        {
            get => Start;
            set { Start = value; }
        }

        /// <summary>
        /// The starting character that defines the initial state of the system
        /// </summary>
        /// <value></value>
        public string Start { get; set; } = "";

        /// <summary>
        /// The set of symbols in the system
        /// </summary>
        /// <value></value>
        public IEnumerable<string> Alphabet { get; set; } = new string[] { };

        /// <summary>
        /// The set of rules that define how symbols evolve
        /// </summary>
        /// <value></value>
        public IEnumerable<Production> Productions { get; set; } = new Production[] { };

        /// <summary>
        /// Builds a <see cref="LSystem"/> using the specified alphabet, axiom, and productions
        /// </summary>
        /// <returns></returns>
        public LSystem Build()
        {
            var checkedProductions = new List<Production>();
            var weightsMap = new Dictionary<string, double>();
            var countMap = new Dictionary<string, int>();

            // count how many & total the probs, by head
            foreach (var p in Productions)
            {
                if (!weightsMap.ContainsKey(p.Head))
                    weightsMap.Add(p.Head, 0.0);
                if (!countMap.ContainsKey(p.Head))
                    countMap.Add(p.Head, 0);
                weightsMap[p.Head] += p.Probability;
                countMap[p.Head] += 1;
            }

            // 
            var stage1AvgMap = new Dictionary<string, double>();
            foreach (var key in weightsMap.Keys)
            {
                if (weightsMap[key] == 0.0)
                {
                    //Console.WriteLine($"{key}: {countMap[key]} items ({1.0 / (double)countMap[key]})");
                    stage1AvgMap.Add(key, 1.0 / (double)countMap[key]);
                }
                else
                {
                    //Console.WriteLine($"{key}: multis: {weightsMap[key]} / {countMap[key]} = {weightsMap[key] / (double)countMap[key]}");
                    stage1AvgMap.Add(key, weightsMap[key] / (double)countMap[key]);
                }
            }

            // stage 1
            foreach (var p in Productions)
            {
                if (p.Probability == 0.0)
                {
                    //Console.WriteLine($"{p.Head} 0.0 prob -> {stage1AvgMap[p.Head]} prob");
                    checkedProductions.Add(new Production
                    {
                        Head = p.Head,
                        Body = p.Body,
                        Precedent = p.Precedent,
                        Next = p.Next,
                        Probability = stage1AvgMap[p.Head]
                    });
                }
                else
                {
                    checkedProductions.Add(p);
                }
            }

            // stage 2
            weightsMap.Clear();

            foreach (var p in checkedProductions)
            {
                if (!weightsMap.ContainsKey(p.Head))
                    weightsMap.Add(p.Head, 0.0);

                //Console.WriteLine($"{p.Probability}");
                weightsMap[p.Head] += p.Probability;
            }

            // balance
            var balancedList = new SortedSet<Production>();
            foreach (var p in checkedProductions)
            {
                balancedList.Add(new Production
                {
                    Head = p.Head,
                    Body = p.Body,
                    Precedent = p.Precedent,
                    Next = p.Next,
                    Probability = p.Probability / weightsMap[p.Head]
                });
            }

            // TODO state checking
            return new LSystem(alphabet: Alphabet, axiom: Start, productions: balancedList);
        }

    }
}