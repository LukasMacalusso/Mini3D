namespace Mini3D.Math;

public static class MatrixFactory
{
    // -- Matrix Generators --
    public static Matrix4x4 CreateIdentityMatrix()
    {
        return new Matrix4x4(
            1f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f
        );
    }

    // -- Transformation Generators --
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

    public static Matrix4x4 CreateViewMatrix(Vector3 position, Vector3 target, Vector3 up)
    {
        Vector3 forward = (target - position).GetNormalized();
        Vector3 right = Vector3.CrossProduct(up, forward).GetNormalized();
        Vector3 actualUp = Vector3.CrossProduct(forward, right);

        float tx = -Vector3.DotProduct(position, right);
        float ty = -Vector3.DotProduct(position, actualUp);
        float tz = -Vector3.DotProduct(position, forward);

        return new Matrix4x4(
            right.X, right.Y, right.Z, tx,
            actualUp.X, actualUp.Y, actualUp.Z, ty,
            forward.X, forward.Y, forward.Z, tz,
            0.0f, 0.0f, 0.0f, 1.0f
        );
    }

    public static Matrix4x4 CreateWorldMatrix(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        Matrix4x4 scaleMatrix = CreateScaleMatrix(scale);
        Matrix4x4 rotX = CreateRotationX(rotation.X);
        Matrix4x4 rotY = CreateRotationY(rotation.Y);
        Matrix4x4 rotZ = CreateRotationZ(rotation.Z);
        Matrix4x4 translationMatrix = CreateTranslationMatrix(position);

        // - Multiplication order for column vectors (v' = T * R * S * v) -
        return translationMatrix * rotZ * rotY * rotX * scaleMatrix;
    }
}
