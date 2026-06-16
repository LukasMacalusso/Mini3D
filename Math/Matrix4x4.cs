namespace Mini3D.Math;

public struct Matrix4x4
{
    public float[,] Elements;

    public Matrix4x4()
    {
        Elements = new float[4, 4];
    }

    // -- Operator Overloads -- //
    public static Matrix4x4 operator *(Matrix4x4 left, Matrix4x4 right)
    {
        // TODO: Implement matrix multiplication
        return new Matrix4x4();
    }

    public static Vector4 operator *(Matrix4x4 matrix, Vector4 vector)
    {
        // TODO: Implement matrix-vector multiplication
        return new Vector4(0, 0, 0, 0);
    }
}
