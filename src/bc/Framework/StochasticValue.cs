using System;

namespace bc.Framework
{
    public struct StochasticValue<T>
    {
        private readonly double probability;
        public T Value { get; init; }
        public double Probability
        {
            get => probability;
            init
            {
                if (value < 0.0 || value > 1.0)
                {
                    throw new ArgumentException($"{nameof(this.Probability)} is out of range; {nameof(this.Probability)} must be within the range of 0..1, inclusive");
                }

                probability = value;
            }
        }

        public override int GetHashCode() => (Value, Probability).GetHashCode();
    }
}