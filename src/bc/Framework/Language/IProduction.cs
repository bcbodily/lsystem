namespace bc.Framework.Language
{
    /// <summary>
    /// An interface to a production rule
    /// </summary>
    public interface IProduction
    {
        /// <summary>
        /// The production head/left-hand side/predessor
        /// </summary>
        /// <value></value>
        string Head { get; }

        /// <summary>
        /// The production body/right-hand side/successor
        /// </summary>
        /// <value></value>
        string Body { get; }
    }
}