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
        Matrix4x4 resultMatrix = new Matrix4x4();

        // -- Row (left matrix) -- //
        for (int row = 0; row < 4; row++)
        {
            // -- Column (right matrix) -- //
            for (int col = 0; col < 4; col++)
            {
                float sum = 0f;

                // -- Element (left column, right row) -- //
                for (int element = 0; element < 4; element++)
                {
                    sum += left.Elements[row, element] * right.Elements[element, col];
                }
                resultMatrix.Elements[row, col] = sum;
            }
        }

        return resultMatrix;
    }

    public static Vector4 operator *(Matrix4x4 matrix, Vector4 vector)
    {
        float x = (matrix.Elements[0, 0] * vector.X) + (matrix.Elements[0, 1] * vector.Y) + (matrix.Elements[0, 2] * vector.Z) + (matrix.Elements[0, 3] * vector.W);
        float y = (matrix.Elements[1, 0] * vector.X) + (matrix.Elements[1, 1] * vector.Y) + (matrix.Elements[1, 2] * vector.Z) + (matrix.Elements[1, 3] * vector.W);
        float z = (matrix.Elements[2, 0] * vector.X) + (matrix.Elements[2, 1] * vector.Y) + (matrix.Elements[2, 2] * vector.Z) + (matrix.Elements[2, 3] * vector.W);
        float w = (matrix.Elements[3, 0] * vector.X) + (matrix.Elements[3, 1] * vector.Y) + (matrix.Elements[3, 2] * vector.Z) + (matrix.Elements[3, 3] * vector.W);

        return new Vector4(x, y, z, w);
    }
}
