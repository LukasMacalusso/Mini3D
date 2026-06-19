namespace Mini3D.Models;

using Mini3D.Math;

public struct ScreenTriangle
{
    // We use Vector3 here so X and Y act as the 2D screen pixels,
    // and Z can optionally hold depth if needed, though we track AverageDepth explicitly.
    public Vector2 PointA;
    public Vector2 PointB;
    public Vector2 PointC;

    // The average depth (Z) of the original 3D triangle from the camera.
    // Crucial for the Painter's Algorithm to sort triangles from back to front.
    public float AverageDepth;

    public ScreenTriangle(Vector2 a, Vector2 b, Vector2 c, float averageDepth)
    {
        PointA = a;
        PointB = b;
        PointC = c;
        AverageDepth = averageDepth;
    }
}
