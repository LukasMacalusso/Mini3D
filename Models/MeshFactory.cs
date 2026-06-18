namespace Mini3D.Models;

public static class MeshFactory
{
    // -- Geometry Generators -- //
    public static Mesh CreateCubeMesh()
    {
        var mesh = new Mesh();
        //Define the 8 vertices of the cube
        mesh.Vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),//0: bottom-left-Back
            new Vector3(0.5f, -0.5f, -0.5f), //1: bottom-right-Back
            new Vector3(0.5f, 0.5f, -0.5f),  //2: top-right-Back
            new Vector3(-0.5f, 0.5f, -0.5f), //3: top-left-Back
            new Vector3(-0.5f, -0.5f, 0.5f),  //4: bottom-left-Front
            new Vector3(0.5f, -0.5f, 0.5f),  //5: bottom-right-Front
            new Vector3(0.5f, 0.5f, 0.5f),  //6: top-right-Front
            new Vector3(-0.5f, 0.5f, 0.5f),  //7: top-left-Front
        };

        mesh.Triangles = new int[]
        {
            0, 2, 1,  0, 3, 2, // Front face
            4, 5, 6,  4, 6, 7, // Back face
            3, 6, 2,  3, 7, 6, // Left face
            0, 1, 5,  0, 5, 4, // Right face
            0, 4, 7,  0, 7, 3, // Top face
            1, 2, 6,  1, 6, 5, // Bottom face
        };
        return mesh;
    }

    public static Mesh CreatePyramidMesh()
    {
        // TODO: Define the vertices and indices for a square-based pyramid
        var mesh = new Mesh();

        mesh.Vertices = new Vector3[]
        {
            new Vector3(-0.5f, -0.5f, -0.5f),//0: base bottom-left-Back
            new Vector3(0.5f, -0.5f, -0.5f), //1: base bottom-right-Back
            new Vector3(0.5f, -0.5f, 0.5f),  //2: base bottom-right-Front
            new Vector3(-0.5f, -0.5f, 0.5f), //3: base bottom-left-Front
            new Vector3(0.0f, 0.5f, 0.0f)    //4: tip (mid-top)
        };

        mesh.Triangles = new int[]
        {
            0, 1, 2,  0, 2, 3,  // square base
            3, 2, 4,            // front side
            1, 0, 4,            // back side
            0, 3, 4,            // left side
            2, 1, 4,            // right side
        };

        return mesh;
    }

    public static Mesh CreatePrismMesh()
    {
        // TODO: Define the vertices and indices for a triangular prism
        var mesh = new Mesh();

        mesh.Vertices = new Vector3[]
        {
            new Vector3(0.0f, 0.5f, 0.5f),   // 0: front up
            new Vector3(-0.5f, -0.5f, 0.5f), // 1: front down-left
            new Vector3(0.5f, -0.5f, 0.5f),  // 2: front down-right
            new Vector3(0.0f, 0.5f, -0.5f),  // 3: back up
            new Vector3(-0.5f, -0.5f, -0.5f),// 4: back down-left
            new Vector3(0.5f, -0.5f, -0.5f), // 5: back down-right

        mesh.Triangles = new int[]
        {
            0, 1, 2,           // front side
            3, 5, 4,           // back side
            1, 4, 5,  1, 5, 2, // bottom wall (flat rectangular base)
            0, 3, 4,  0, 4, 1, // sloping right wall
            0, 2, 5,  0, 5, 3, // sloping left wall
        };

        return mesh;
    }
}
