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

    public static float Dot(Vector3 a, Vector3 b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
    }
}
