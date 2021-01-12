using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using bc.Framework.Grammar;

namespace driver
{
    class Program
    {
        static void Main(string[] args)
        {

            // create an alphabet
            var algaeAlphabet = new String[] { "A", "B" };

            // create a rule
            var rules = new SortedSet<Production>
            {
                // A -> AB
                new Production
                {
                    Predecessor = "A",
                    Successor = "AB"
                },
                // B -> A
                new Production
                {
                    Predecessor = "B",
                    Successor = "A"
                }
            };

            // create system
            var lsys = new LSystem(algaeAlphabet, "A", rules.ToImmutableHashSet());

            int count = 0;
            string input = lsys.Axiom;

            Console.WriteLine($"{count}:\t{input}");
            while (count < 10)
            {
                count++;
                input = lsys.Generate(input);
                Console.WriteLine($"{count}:\t{input}");
            }
        }
    }
}
