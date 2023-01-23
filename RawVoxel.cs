namespace VoxReader
{
    internal readonly struct RawVoxel
    {
        /// <summary>
        /// The position of the voxel.
        /// </summary>
        public VectorData3 Position { get; }

        /// <summary>
        /// The color index of the voxel.
        /// </summary>
        public int ColorIndex { get; }

        public RawVoxel(VectorData3 position, int colorIndex)
        {
            Position = position;
            ColorIndex = colorIndex;
        }

        public override string ToString()
        {
            return $"Position: [{Position}], Color Index: [{ColorIndex}]";
        }
    }
}