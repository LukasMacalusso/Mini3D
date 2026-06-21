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
}
