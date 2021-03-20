using System.Collections.Immutable;

namespace bc.Framework.Language.Grammar
{
    /// <summary>
    /// A collection of some common L-systems
    /// </summary>
    public static class LSystems
    {
        /// <summary>
        /// Lindenmayer's l-system for modelling algae growth
        /// </summary>
        /// <value></value>
        public static LSystem ALGAE { get; } = new LSystemBuilder
        {
            Start = "A",
            Alphabet = new string[] { "A", "B" },
            Productions = new Production[]
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
            }
        }.Build();

        public static LSystem BINARY_FRACTAL_TREE { get; } = new LSystemBuilder
        {
            Start = "0",
            Alphabet = new string[] { "0", "1", "[", "]" },
            Productions = new Production[]
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
            }
        }.Build();

        public static LSystem CANTOR_SET { get; } = new LSystemBuilder
        {
            Start = "A",
            Alphabet = new string[] { "A", "B" },
            Productions = new Production[]
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
            }
        }.Build();
    }
}