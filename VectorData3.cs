using System;

namespace VoxReader
{
    public struct VectorData3 : IEquatable<VectorData3>
    {
        /// <summary>
        /// The x-component of the vector (right).
        /// </summary>
        public readonly int X;

        /// <summary>
        /// The y-component of the vector (forward).
        /// </summary>
        public readonly int Y;

        /// <summary>
        /// The z-component of the vector (up).
        /// </summary>
        public readonly int Z;

        public VectorData3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

        public bool Equals(VectorData3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is VectorData3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Z;
                return hashCode;
            }
        }

        //TODO: add unit tests

        public static bool operator ==(VectorData3 a, VectorData3 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(VectorData3 a, VectorData3 b)
        {
            return !(a == b);
        }

        public static VectorData3 operator +(VectorData3 a, VectorData3 b)
        {
            return new VectorData3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static VectorData3 operator -(VectorData3 a, VectorData3 b)
        {
            return new VectorData3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static VectorData3 operator *(VectorData3 a, int i)
        {
            return new VectorData3(a.X * i, a.Y * i, a.Z * i);
        }

        public static VectorData3 operator /(VectorData3 a, int i)
        {
            return new VectorData3(a.X / i, a.Y / i, a.Z / i);
        }
    }
}