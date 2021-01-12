using System.Collections.Immutable;

namespace bc.Framework.Language
{
    /// <summary>
    /// A collection of some common l-systems
    /// </summary>
    public static class LSystems
    {
        /// <summary>
        /// Lindenmayer's l-system for modelling algae growth
        /// </summary>
        /// <value></value>
        public static LSystem ALGAE => new LSystem
        {
            Axiom = "A",
            Alphabet = new string[] { "A", "B" }.ToImmutableSortedSet(),
            Productions = new IProduction[]
            {
                new Production
                {
                    Head = "A",
                    Body = "AB"
                },
                new Production
                {
                    Head = "B",
                    Body = "A"
                }
            }.ToImmutableHashSet()
        };

        public static LSystem BINARY_FRACTAL_TREE => new LSystem
        {
            Axiom = "0",
            Alphabet = new string[] { "0", "1", "[", "]" }.ToImmutableSortedSet(),
            Productions = new IProduction[]
            {
                new Production
                {
                    Head = "1",
                    Body = "11"
                },
                new Production
                {
                    Head = "0",
                    Body = "1[0]0"
                }
            }.ToImmutableHashSet()
        };

        public static LSystem CANTOR_SET => new LSystem
        {
            Axiom = "A",
            Alphabet = new string[] {"A", "B"}.ToImmutableSortedSet(),
            Productions = new IProduction[]
            {
                new Production
                {
                    Head = "A",
                    Body = "ABA"
                },
                new Production
                {
                    Head = "B",
                    Body = "BBB"
                }
            }.ToImmutableHashSet()
        };
    }
}