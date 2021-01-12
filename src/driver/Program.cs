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
            var lsys = LSystems.CANTOR_SET;
            var reader = new ProductionsIterator(lsys.Productions);

            int count = 0;
            string input = lsys.Axiom;

            Console.WriteLine($"{count}:\t{input}");
            while (count < 5)
            {
                count++;
                input = reader.Generate(input);
                Console.WriteLine($"{count}:\t{input}");
            }
        }
    }
}
