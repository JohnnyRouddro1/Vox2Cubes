namespace VoxReader.Interfaces
{
    internal interface IPaletteChunk : IChunk
    {
        /// <summary>
        /// The colors stored in the RGBA chunk.
        /// </summary>
        VoxColor[] Colors { get; }
    }
}