using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BC.LSystem
{
    public struct Alphabet
    {
        public IImmutableSet<String> Constants {get; private set;}
        public IImmutableSet<String> Variables {get; private set;}

        public Alphabet(ICollection<String> constants, ICollection<String> variables)
        {
            Constants = constants.ToImmutableSortedSet();
            Variables = variables.ToImmutableSortedSet();

            if (Constants.Intersect(Variables).Count != 0)
            {
                throw new ArgumentException($"{Constants.Intersect(Variables).Count} element(s) exist in both the constants and variables argument.");
            }
        }
    }
}