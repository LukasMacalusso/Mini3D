namespace Mini3D.Math;

public struct Vector3
{
    public float X;
    public float Y;
    public float Z;

    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // - Operator overloads - //
    public static Vector3 operator +(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
    }

    public static Vector3 operator -(Vector3 left, Vector3 right)
    {
        return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    }

    // - Methods - //
    public static float DotProduct(Vector3 a, Vector3 b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
    }

    public static Vector3 CrossProduct(Vector3 a, Vector3 b)
    {
        return new Vector3(
            (a.Y * b.Z) - (a.Z * b.Y),
            (a.Z * b.X) - (a.X * b.Z),
            (a.X * b.Y) - (a.Y * b.X)
        );
    }

    public float GetLength()
    {
        return (float)System.Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
    }

    public Vector3 GetNormalized()
    {
        float length = GetLength();
        if (length == 0f) return new Vector3(0, 0, 0);
        return new Vector3(X / length, Y / length, Z / length);
    }

    public Vector4 ToVector4()
    {
        return new Vector4(X, Y, Z, 1.0f);
    }

}
