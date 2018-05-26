using System;
using System.Collections.Immutable;

namespace BC.LSystem
{
    public struct LSystem
    {
        public Alphabet Alphabet { get; }
        public String Axiom { get; }
        public IImmutableSet<Rule> Rules {get;}

        public LSystem(Alphabet alphabet, String axiom, IImmutableSet<Rule> rules)
        {
            Alphabet = alphabet;
            Axiom = axiom;
            Rules = rules;
        }
    }
}