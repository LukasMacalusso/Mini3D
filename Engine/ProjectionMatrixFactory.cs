namespace Mini3D.Engine;
using Mini3D.Math;

public static class ProjectionMatrixFactory
{
    // -- Projection Matrices --
    public static Matrix4x4 CreatePerspectiveMatrix(float fovDegrees, float aspect, float near, float far)
    {
        float fovRadians = fovDegrees * (float)System.Math.PI / 180.0f;
		float yScale = 1.0f / (float)System.Math.Tan(fovRadians / 2.0f);
        float xScale = yScale / aspect;
        
		return new Matrix4x4(
    		xScale, 0.0f,   0.0f,               0.0f,
    		0.0f,   yScale, 0.0f,               0.0f,
    		0.0f,   0.0f,   far / (far - near), (-near * far) / (far - near),
    		0.0f,   0.0f,   1.0f,               0.0f
		);
    }
}
