namespace VoxReader
{
    public readonly struct Voxel
    {
        /// <summary>
        /// The position of the voxel in the model.
        /// </summary>
        public VectorData3 Position { get; }
        
        /// <summary>
        /// The global position of the voxel in the scene.
        /// </summary>
        public VectorData3 GlobalPosition { get; }

        /// <summary>
        /// The color of the voxel.
        /// </summary>
        public VoxColor Color { get; }

        internal Voxel(VectorData3 position, VectorData3 globalPosition, VoxColor color)
        {
            Position = position;
            GlobalPosition = globalPosition;
            Color = color;
        }

        public override string ToString()
        {
            return $"Position: [{Position}], Color: [{Color}]";
        }
    }
}