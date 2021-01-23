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
            DisplaySystemDetails(LSystems.BINARY_FRACTAL_TREE);
        }

        static void DisplaySystemDetails(IGrammar grammar)
        {
            Console.WriteLine("Grammar details");
            Console.WriteLine();
            Console.WriteLine($"Start:\t'{grammar.Start}'");
            Console.WriteLine($"Nonterminals:\t'{String.Join("', '", grammar.Nonterminals)}'");
            Console.WriteLine($"Terminals:\t'{String.Join("', '", grammar.Terminals)}'");
            Console.WriteLine("Productions:");
            foreach (var p in grammar.Productions)
            {
                DisplayProduction(p);
            }
        }

        static void DisplayProduction(Production production)
        {
            if (production.Probability == 1.0)
                Console.WriteLine($"\t{production.Head} → {production.Body}");
            else
                Console.WriteLine($"\t{production.Head} ({production.Probability}) → {production.Body}");
        }
    }
}
