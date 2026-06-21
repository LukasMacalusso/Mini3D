namespace Mini3D.Math;

public struct Matrix4x4
{
    public float M11, M12, M13, M14;
    public float M21, M22, M23, M24;
    public float M31, M32, M33, M34;
    public float M41, M42, M43, M44;

    public Matrix4x4(
        float m11, float m12, float m13, float m14,
        float m21, float m22, float m23, float m24,
        float m31, float m32, float m33, float m34,
        float m41, float m42, float m43, float m44)
    {
        M11 = m11; M12 = m12; M13 = m13; M14 = m14;
        M21 = m21; M22 = m22; M23 = m23; M24 = m24;
        M31 = m31; M32 = m32; M33 = m33; M34 = m34;
        M41 = m41; M42 = m42; M43 = m43; M44 = m44;
    }

    public Vector4 Row1 => new Vector4(M11, M12, M13, M14);
    public Vector4 Row2 => new Vector4(M21, M22, M23, M24);
    public Vector4 Row3 => new Vector4(M31, M32, M33, M34);
    public Vector4 Row4 => new Vector4(M41, M42, M43, M44);

    public Vector4 Column1 => new Vector4(M11, M21, M31, M41);
    public Vector4 Column2 => new Vector4(M12, M22, M32, M42);
    public Vector4 Column3 => new Vector4(M13, M23, M33, M43);
    public Vector4 Column4 => new Vector4(M14, M24, M34, M44);

    // -- Operator Overloads --
    public static Matrix4x4 operator *(Matrix4x4 left, Matrix4x4 right)
    {
        Vector4 r1 = left.Row1;
        Vector4 r2 = left.Row2;
        Vector4 r3 = left.Row3;
        Vector4 r4 = left.Row4;

        Vector4 c1 = right.Column1;
        Vector4 c2 = right.Column2;
        Vector4 c3 = right.Column3;
        Vector4 c4 = right.Column4;

        return new Matrix4x4(
            Vector4.Dot(r1, c1), Vector4.Dot(r1, c2), Vector4.Dot(r1, c3), Vector4.Dot(r1, c4),
            Vector4.Dot(r2, c1), Vector4.Dot(r2, c2), Vector4.Dot(r2, c3), Vector4.Dot(r2, c4),
            Vector4.Dot(r3, c1), Vector4.Dot(r3, c2), Vector4.Dot(r3, c3), Vector4.Dot(r3, c4),
            Vector4.Dot(r4, c1), Vector4.Dot(r4, c2), Vector4.Dot(r4, c3), Vector4.Dot(r4, c4)
        );
    }

    public static Vector4 operator *(Matrix4x4 matrix, Vector4 vector)
    {
        return new Vector4(
            Vector4.Dot(matrix.Row1, vector),
            Vector4.Dot(matrix.Row2, vector),
            Vector4.Dot(matrix.Row3, vector),
            Vector4.Dot(matrix.Row4, vector)
        );
    }
}
