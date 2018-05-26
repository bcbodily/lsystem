using System;
using System.Collections.Generic;

namespace BC.LSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // create an alphabet
            var algaeVariables = new SortedSet<String>();
            var algaeConstants = new SortedSet<String>();
            algaeVariables.Add("A");
            algaeVariables.Add("B");
            algaeConstants.Add("A");
            var algaeAlphabet = new Alphabet(algaeConstants, algaeVariables);

        }
    }
}
