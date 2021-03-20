using System;

namespace bc.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public struct ProbabilisticItem<T> : IEquatable<ProbabilisticItem<T>> where T : IEquatable<T>
    {
        public T Item { get; init; }
        public double Probability { get; init; }

        public bool Equals(ProbabilisticItem<T> other) => Item.Equals(other.Item) && Probability.Equals(other.Probability);

        public override bool Equals(object obj) =>
            obj is ProbabilisticItem<T> other &&
            this.Equals(other);

        public override int GetHashCode() => (Item, Probability).GetHashCode();

        public static bool operator ==(ProbabilisticItem<T> lhs, ProbabilisticItem<T> rhs) => lhs.Probability.Equals(rhs.Probability) && lhs.Item.Equals(rhs.Item);

        public static bool operator !=(ProbabilisticItem<T> lhs, ProbabilisticItem<T> rhs) => !lhs.Probability.Equals(rhs.Probability) || !lhs.Item.Equals(rhs.Item);

        public static implicit operator ProbabilisticItem<T>(T item) => new ProbabilisticItem<T> { Item = item, Probability = 1.0 };

        public static implicit operator ProbabilisticItem<T>((T item, double probability) pair) => new ProbabilisticItem<T> { Item = pair.item, Probability = pair.probability};
    }
}