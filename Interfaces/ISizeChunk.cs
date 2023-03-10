namespace VoxReader.Interfaces
{
    internal interface ISizeChunk : IChunk
    {
        /// <summary>
        /// The size that is specified in the SIZE chunk.
        /// </summary>
        VectorData3 Size { get; }
    }
}