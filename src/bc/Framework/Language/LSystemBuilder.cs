using System;
using System.Collections.Generic;

namespace bc.Framework.Language
{
    /// <summary>
    /// An <see cref="IBuilder{t}"/> that builds instances of <see cref="LSystem"/>
    /// </summary>
    public class LSystemBuilder : IBuilder<LSystem>
    {
        /// <summary>
        /// Alias for <see cref="Start"/>
        /// </summary>
        /// <value></value>
        public string Axiom
        {
            get => Start;
            set { Start = value; }
        }

        /// <summary>
        /// The starting character that defines the initial state of the system
        /// </summary>
        /// <value></value>
        public string Start { get; set; } = "";

        /// <summary>
        /// The set of symbols in the system
        /// </summary>
        /// <value></value>
        public IEnumerable<string> Alphabet { get; set; } = new string[] { };

        /// <summary>
        /// The set of rules that define how symbols evolve
        /// </summary>
        /// <value></value>
        public IEnumerable<Production> Productions { get; set; } = new Production[] { };

        /// <summary>
        /// Builds a <see cref="LSystem"/> using the specified alphabet, axiom, and productions
        /// </summary>
        /// <returns></returns>
        public LSystem Build()
        {
            // TODO state checking
            return new LSystem(alphabet: Alphabet, axiom: Start, productions: Productions);
        }
    }
}