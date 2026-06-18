namespace Mini3D.Engine;
using Mini3D.Math;

public static class ProjectionMatrixFactory
{
    // -- Projection Matrices -- //
    public static Matrix4x4 CreatePerspectiveMatrix(float fovRadians, float aspect, float near, float far)
    {
        Matrix4x4 result = new Matrix4x4();
        
        float yScale = cot(fovRadians / 2);
        float xScale = yScale / aspect;
        
        result.Elements[0, 0] = xScale;
        result.Elements[1, 1] = yScale;
        result.Elements[2, 2] = far / (far - near);
        result.Elements[2, 3] = 1.0f;
        result.Elements[3, 2] = -near * far / (far - near);
        
        return result;
    }
}
