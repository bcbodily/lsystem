namespace bc.Framework
{
    /// <summary>
    /// Interface to a class that assists in building something
    /// </summary>
    /// <typeparam name="T">the type of class this builder builds</typeparam>
    public interface IBuilder<T>
    {
        /// <summary>
        /// Builds an object
        /// </summary>
        /// <returns></returns>
        T Build();
    }
}