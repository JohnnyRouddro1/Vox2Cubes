using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VoxReader.UnitTests")]

namespace VoxReader
{
    public readonly struct VoxColor : IEquatable<VoxColor>
    {
        public bool Equals(VoxColor other)
        {
            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        public override bool Equals(object obj)
        {
            return obj is VoxColor other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = R.GetHashCode();
                hashCode = (hashCode * 397) ^ G.GetHashCode();
                hashCode = (hashCode * 397) ^ B.GetHashCode();
                hashCode = (hashCode * 397) ^ A.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(VoxColor left, VoxColor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VoxColor left, VoxColor right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// The red component of the color.
        /// </summary>
        public byte R { get; }

        /// <summary>
        /// The green component of the color.
        /// </summary>
        public byte G { get; }

        /// <summary>
        /// The blue component of the color.
        /// </summary>
        public byte B { get; }

        /// <summary>
        /// The alpha component of the color.
        /// </summary>
        public byte A { get; }

        internal VoxColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public override string ToString()
        {
            return $"R: {R} G: {G} B: {B} A: {A}";
        }

        internal static readonly VoxColor Red = new(255, 0, 0, 255);
        internal static readonly VoxColor Green = new(0, 255, 0, 255);
        internal static readonly VoxColor Blue = new(0, 0, 255, 255);
        internal static readonly VoxColor White = new(255, 255, 255, 255);
        internal static readonly VoxColor Black = new(0, 0, 0, 255);
    }
}