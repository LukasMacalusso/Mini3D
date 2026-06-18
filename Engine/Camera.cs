namespace Mini3D.Engine;
using Mini3D.Math;

public class Camera
{
    public Vector3 Position;
    public Vector3 Target;

    public Camera(Vector3 position, Vector3 target)
    {
        Position = position;
        Target = target;
    }

    // -- Matrix Generation -- //
    public Matrix4x4 GetViewMatrix()
    {
        // Calculate vectors
        Matrix4x4 result = new Matrix4x4();

        Vector3 forwardVector = Normalize(Position - Target);
        
        Vector3 tempUpVector = new Vector3(0, 1, 0);
        Vector3 rightVector = Normalize(DotProduct(tempUpVector, forward));
        
        Vector3 upVector = DotProduct(forward, rightVector);
        
        // LookAt Matrix Construction
        result.Elements[0, 0] = rightVector.X;
        result.Elements[0, 1] = upVector.X;
        result.Elements[0, 2] = forwardVector.X;
        result.Elements[0, 3] = 0.0f;
        
        result.Elements[0, 0] = rightVector.Y;
        result.Elements[0, 1] = upVector.Y;
        result.Elements[0, 2] = forwardVector.Y;
        result.Elements[0, 3] = 0.0f;
        
        result.Elements[0, 0] = rightVector.Y;
        result.Elements[0, 1] = upVector.Y;
        result.Elements[0, 2] = forwardVector.Y;
        result.Elements[0, 3] = 0.0f;
        
        result.Elements[3, 0] = -DotProduct(rightVector, Position);
        result.Elements[3, 1] = -DotProduct(upVector, Position);
        result.Elements[3, 2] = -DotProduct(forwardVector, Position);
        result.Elements[3, 3] = 1.0f;
        
        return result;
    }
}
