using System.Text;
using VoxReader.Interfaces;

namespace VoxReader
{
    public class Palette : IPalette
    {
        public VoxColor[] Colors { get; }

        public Palette(VoxColor[] colors)
        {
            Colors = colors;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            
            for (int i = 0; i < Colors.Length - 1; i++)
            {
                output.AppendLine(GetText(i));
            }
            output.Append(GetText(Colors.Length - 1));

            string GetText(int index) => $"{index}: [{Colors[index]}]";

            return output.ToString();
        }
    }
}