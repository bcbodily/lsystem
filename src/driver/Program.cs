using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using bc.Framework;
using bc.Framework.Language;

namespace driver
{
    class Program
    {
        static void Main(string[] args)
        {
            // common RNG
            var random = new Random(1);

            // create an alphabet
            var algaeAlphabet = new String[] { "A", "B" };

            // create a rule
            var rules = new IProduction[]
            {
                // A -> AB
                // new Production
                // {
                //     Predecessor = "0",
                //     Successor = "1[0]0"
                // },
                // B -> A
                new StochasticProduction
                {
                    Head = "0",
                    // Successor = "A"
                    Productions = new StochasticValue<string>[]
                    {
                        new StochasticValue<string>
                        {
                            Value = "1[0]0",
                            Probability = 0.5
                        },
                        new StochasticValue<string>
                        {
                            Value = "0",
                            Probability = 0.5
                        }
                    },
                    Random = random
                }
            };

            // create system
            var lsys = new LSystem(algaeAlphabet, "0", rules);

            int count = 0;
            string input = lsys.Axiom;

            Console.WriteLine($"{count}:\t{input}");
            while (count < 7)
            {
                count++;
                input = lsys.Generate(input);
                Console.WriteLine($"{count}:\t{input}");
            }
        }
    }
}
