namespace Mini3D.Engine;

using Mini3D.Math;

public static class ProjectionMatrixFactory
{
    // -- Projection Matrices -- //
    public static Matrix4x4 CreatePerspectiveMatrix(float fovRadians, float aspect, float near, float far)
    {
        // TODO: Implement the perspective projection matrix
        // This matrix will ensure that objects further away appear smaller,
        // and it prepares the 'W' component for the perspective divide.
        return new Matrix4x4();
    }
}
