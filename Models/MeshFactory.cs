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
        // TODO: Define the 8 vertices and 36 indices (12 triangles) for a cube
        return mesh;
    }

            new Vector3(1, -1, 1),
            new Vector3(1, 1, 1),
            new Vector3(-1, 1, 1),
        };

        // TODO: Define the 8 vertices and 36 indices (12 triangles) for a cube
        return mesh;
    }

    public static Mesh CreatePyramidMesh()
    {
        // TODO: Define the vertices and indices for a square-based pyramid
        return new Mesh();
    }

    public static Mesh CreatePrismMesh()
    {
        // TODO: Define the vertices and indices for a triangular prism
        return new Mesh();
    }
}
