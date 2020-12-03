namespace VowelFinder
{
    /// <summary>
    /// Stream interface
    /// </summary>
    public interface IStream{
        /// <summary>
        /// Get next element in Stream
        /// </summary>
        /// <returns>The element in next position from Stream</returns>
        char getNext();

        /// <summary>
        /// Verify if the Stream has next value
        /// </summary>
        /// <returns>If the exists value in next position</returns>
        bool hasNext();
    }
}