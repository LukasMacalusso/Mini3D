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
        // TODO: Implement the "LookAt" view matrix logic
        // This matrix shifts the entire 3D world so it is relative to the camera's perspective.
        return new Matrix4x4();
    }
}
