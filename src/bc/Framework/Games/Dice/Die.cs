using System.Collections.Generic;

namespace bc.Framework.Games.Dice
{
    public class Die<T>
    {
        public IEnumerable<T> PossibleOutcomes { get; init; }
    }
}