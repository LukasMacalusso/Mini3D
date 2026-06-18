namespace Mini3D.Math;

public static class MatrixFactory
{
    // -- Matrix Generators -- //
    public static Matrix4x4 CreateIdentityMatrix()
    {
        return new Matrix4x4(
            1f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f
        );
    }

    // -- Transformation Generators -- //
    public static Matrix4x4 CreateTranslationMatrix(Vector3 offset)
    {
        return new Matrix4x4(
            1f, 0f, 0f, offset.X,
            0f, 1f, 0f, offset.Y,
            0f, 0f, 1f, offset.Z,
            0f, 0f, 0f, 1f
        );
    }

    public static Matrix4x4 CreateScaleMatrix(Vector3 scale)
    {
        return new Matrix4x4(
            scale.X, 0f, 0f, 0f,
            0f, scale.Y, 0f, 0f,
            0f, 0f, scale.Z, 0f,
            0f, 0f, 0f, 1f
        );
    }

    public static Matrix4x4 CreateRotationX(float angleRadians)
    {
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        return new Matrix4x4(
            1f, 0f, 0f, 0f,
            0f, cos, -sin, 0f,
            0f, sin, cos, 0f,
            0f, 0f, 0f, 1f
        );
    }

    public static Matrix4x4 CreateRotationY(float angleRadians)
    {
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        return new Matrix4x4(
            cos, 0f, sin, 0f,
            0f, 1f, 0f, 0f,
            -sin, 0f, cos, 0f,
            0f, 0f, 0f, 1f
        );
    }

    public static Matrix4x4 CreateRotationZ(float angleRadians)
    {
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        return new Matrix4x4(
            cos, -sin, 0f, 0f,
            sin, cos, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f
        );
    }
}
