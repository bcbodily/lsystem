using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace bc.Framework.Language
{
    public struct LSystem : IGrammar
    {
        public ISet<string> Alphabet { get; init; }
        public String Axiom { get; init; }
        public ISet<IProduction> Productions { get; init; }
    }
}