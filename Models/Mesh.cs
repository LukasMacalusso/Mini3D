namespace Mini3D.Models;

using Mini3D.Math;

public class Mesh
{
    // -- Local Transform Properties -- //
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

    public Matrix4x4 WorldMatrix => MatrixFactory.CreateWorldMatrix(Position, Rotation, Scale);

    // -- Geometry Data -- //
    // The raw 3D coordinates relative to the object's center (0,0,0)
    public Vector3[] Vertices;
    
    // Every 3 integers represent the indices of the Vertices array that form a triangle face
    public int[] TriangleIndices;

    public Mesh()
    {
        Position = new Vector3(0, 0, 0);
        Rotation = new Vector3(0, 0, 0);
        Scale = new Vector3(1, 1, 1);
        Vertices = new Vector3[0];
        TriangleIndices = new int[0];
    }
}
