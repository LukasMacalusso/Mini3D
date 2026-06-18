namespace Mini3D.Math;

public static class MatrixFactory
{
    // -- Matrix Generators -- //
    public static Matrix4x4 CreateIdentityMatrix()
    {

        Matrix4x4 IdentityMatrix = new Matrix4x4();

        // - Diagonal of 1's - //
        IdentityMatrix.Elements[0, 0] = 1f;
        IdentityMatrix.Elements[1, 1] = 1f;
        IdentityMatrix.Elements[2, 2] = 1f;
        IdentityMatrix.Elements[3, 3] = 1f;

        return IdentityMatrix;
    }

    // -- Transformation Generators -- //
    public static Matrix4x4 CreateTranslationMatrix(Vector3 offset)
    {
        Matrix4x4 translationMatrix = CreateIdentityMatrix();

        // - Use the third columnn to translate by offsets - //
        translationMatrix.Elements[0, 3] = offset.X;
        translationMatrix.Elements[1, 3] = offset.Y;
        translationMatrix.Elements[2, 3] = offset.Z;

        return translationMatrix;
    }

    public static Matrix4x4 CreateScaleMatrix(Vector3 scale)
    {
        Matrix4x4 matrix = new Matrix4x4();

        // - X, Y, & Z On the diagonal - //
        matrix.Elements[0, 0] = scale.X;
        matrix.Elements[1, 1] = scale.Y;
        matrix.Elements[2, 2] = scale.Z;
        matrix.Elements[3, 3] = 1f;

        return matrix;
    }

    public static Matrix4x4 CreateRotationX(float angleRadians)
    {
        Matrix4x4 matrix = new Matrix4x4();
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        // El eje X se queda igual. Se rota Y y Z.
        matrix.Elements[0, 0] = 1f;

        matrix.Elements[1, 1] = cos;
        matrix.Elements[1, 2] = -sin;

        matrix.Elements[2, 1] = sin;
        matrix.Elements[2, 2] = cos;

        matrix.Elements[3, 3] = 1f;

        return matrix;
    }

    public static Matrix4x4 CreateRotationY(float angleRadians)
    {
        Matrix4x4 matrix = new Matrix4x4();
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        // El eje Y se queda igual. Se rota X y Z.
        matrix.Elements[0, 0] = cos;
        matrix.Elements[0, 2] = sin;

        matrix.Elements[1, 1] = 1f;

        matrix.Elements[2, 0] = -sin;
        matrix.Elements[2, 2] = cos;

        matrix.Elements[3, 3] = 1f;

        return matrix;
    }

    public static Matrix4x4 CreateRotationZ(float angleRadians)
    {
        Matrix4x4 matrix = new Matrix4x4();
        float cos = (float)System.Math.Cos(angleRadians);
        float sin = (float)System.Math.Sin(angleRadians);

        // El eje Z se queda igual. Se rota X e Y.
        matrix.Elements[0, 0] = cos;
        matrix.Elements[0, 1] = -sin;

        matrix.Elements[1, 0] = sin;
        matrix.Elements[1, 1] = cos;

        matrix.Elements[2, 2] = 1f;

        matrix.Elements[3, 3] = 1f;

        return matrix;
    }
}
