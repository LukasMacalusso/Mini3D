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

    public Matrix4x4 GetViewMatrix()
    {
        Vector3 worldUp = new Vector3(0, 1, 0);

        Vector3 forward = (Target - Position).GetNormalized();
        Vector3 right = Vector3.CrossProduct(worldUp, forward).GetNormalized();
        Vector3 up = Vector3.CrossProduct(forward, right);

        float tx = -Vector3.DotProduct(Position, right);
        float ty = -Vector3.DotProduct(Position, up);
        float tz = -Vector3.DotProduct(Position, forward);

        return new Matrix4x4(
            right.X, right.Y, right.Z, tx,
            up.X, up.Y, up.Z, ty,
            forward.X, forward.Y, forward.Z, tz,
            0.0f, 0.0f, 0.0f, 1.0f
        );
    }
}
