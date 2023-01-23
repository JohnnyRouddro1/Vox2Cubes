using VoxReader.Interfaces;

namespace VoxReader.Chunks
{
    internal class PaletteChunk : Chunk, IPaletteChunk
    {
        public VoxColor[] Colors { get; }

        public PaletteChunk(byte[] data) : base(data)
        {
            Colors = new VoxColor[256];

            var formatParser = new FormatParser(Content);

            Colors = formatParser.ParseColors(Colors.Length);
        }
    }
}