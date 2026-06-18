namespace Mini3D.Math;

public static class MatrixFactory
{
    // -- Transformation Generators -- //
    public static Matrix4x4 CreateTranslation(Vector3 offset)
    {
        Matrix4x4 matrix = new Matrix4x4();
        
        // 1. Matriz Identidad (1 en la diagonal para mantener la forma original)
        matrix.Elements[0, 0] = 1f;
        matrix.Elements[1, 1] = 1f;
        matrix.Elements[2, 2] = 1f;
        matrix.Elements[3, 3] = 1f;

        // 2. Desplazamiento en la última columna
        matrix.Elements[0, 3] = offset.X;
        matrix.Elements[1, 3] = offset.Y;
        matrix.Elements[2, 3] = offset.Z;

        return matrix;
    }

    public static Matrix4x4 CreateScale(Vector3 scale)
    {
        Matrix4x4 matrix = new Matrix4x4();
        
        // Para escalar, ponemos los valores por los que queremos multiplicar en la diagnal.
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
