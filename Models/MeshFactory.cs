namespace Mini3D.Models;

public static class MeshFactory
{
    // -- Geometry Generators --
    public static Mesh CreateCubeMesh()
    {
        var mesh = new Mesh();
        
        // - 24 vertices for independent face normals and UVs -
        mesh.Vertices = new Vector3[]
        {
            // - Front face (+Z) -
            new Vector3(-0.5f, -0.5f, 0.5f), // 0: bottom-left
            new Vector3( 0.5f, -0.5f, 0.5f), // 1: bottom-right
            new Vector3( 0.5f,  0.5f, 0.5f), // 2: top-right
            new Vector3(-0.5f,  0.5f, 0.5f), // 3: top-left
            
            // - Back face (-Z) -
            new Vector3( 0.5f, -0.5f, -0.5f), // 4: bottom-left (looking from back)
            new Vector3(-0.5f, -0.5f, -0.5f), // 5: bottom-right
            new Vector3(-0.5f,  0.5f, -0.5f), // 6: top-right
            new Vector3( 0.5f,  0.5f, -0.5f), // 7: top-left
            
            // - Left face (-X) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 8: bottom-left (looking from left)
            new Vector3(-0.5f, -0.5f,  0.5f), // 9: bottom-right
            new Vector3(-0.5f,  0.5f,  0.5f), // 10: top-right
            new Vector3(-0.5f,  0.5f, -0.5f), // 11: top-left
            
            // - Right face (+X) -
            new Vector3( 0.5f, -0.5f,  0.5f), // 12: bottom-left (looking from right)
            new Vector3( 0.5f, -0.5f, -0.5f), // 13: bottom-right
            new Vector3( 0.5f,  0.5f, -0.5f), // 14: top-right
            new Vector3( 0.5f,  0.5f,  0.5f), // 15: top-left
            
            // - Top face (+Y) -
            new Vector3(-0.5f,  0.5f,  0.5f), // 16: bottom-left (looking from top)
            new Vector3( 0.5f,  0.5f,  0.5f), // 17: bottom-right
            new Vector3( 0.5f,  0.5f, -0.5f), // 18: top-right
            new Vector3(-0.5f,  0.5f, -0.5f), // 19: top-left
            
            // - Bottom face (-Y) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 20: bottom-left (looking from bottom)
            new Vector3( 0.5f, -0.5f, -0.5f), // 21: bottom-right
            new Vector3( 0.5f, -0.5f,  0.5f), // 22: top-right
            new Vector3(-0.5f, -0.5f,  0.5f), // 23: top-left
        };

        mesh.Triangles = new int[]
        {
            0, 1, 2,  0, 2, 3,       // - Front face -
            4, 5, 6,  4, 6, 7,       // - Back face -
            8, 9, 10,  8, 10, 11,    // - Left face -
            12, 13, 14,  12, 14, 15, // - Right face -
            16, 17, 18,  16, 18, 19, // - Top face -
            20, 21, 22,  20, 22, 23  // - Bottom face -
        };
        
        return mesh;
    }

    public static Mesh CreatePyramidMesh()
    {
        var mesh = new Mesh();

        // - 16 vertices for independent face normals and UVs -
        mesh.Vertices = new Vector3[]
        {
            // - Base face (Bottom, -Y) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 0: bottom-left-back
            new Vector3( 0.5f, -0.5f, -0.5f), // 1: bottom-right-back
            new Vector3( 0.5f, -0.5f,  0.5f), // 2: bottom-right-front
            new Vector3(-0.5f, -0.5f,  0.5f), // 3: bottom-left-front

            // - Front face (+Z) -
            new Vector3(-0.5f, -0.5f,  0.5f), // 4: bottom-left
            new Vector3( 0.5f, -0.5f,  0.5f), // 5: bottom-right
            new Vector3( 0.0f,  0.5f,  0.0f), // 6: tip

            // - Right face (+X) -
            new Vector3( 0.5f, -0.5f,  0.5f), // 7: bottom-left (looking from right)
            new Vector3( 0.5f, -0.5f, -0.5f), // 8: bottom-right
            new Vector3( 0.0f,  0.5f,  0.0f), // 9: tip

            // - Back face (-Z) -
            new Vector3( 0.5f, -0.5f, -0.5f), // 10: bottom-left (looking from back)
            new Vector3(-0.5f, -0.5f, -0.5f), // 11: bottom-right
            new Vector3( 0.0f,  0.5f,  0.0f), // 12: tip

            // - Left face (-X) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 13: bottom-left (looking from left)
            new Vector3(-0.5f, -0.5f,  0.5f), // 14: bottom-right
            new Vector3( 0.0f,  0.5f,  0.0f), // 15: tip
        };

        mesh.Triangles = new int[]
        {
            0, 1, 2,  0, 2, 3, // - Base face -
            4, 5, 6,           // - Front face -
            7, 8, 9,           // - Right face -
            10, 11, 12,        // - Back face -
            13, 14, 15         // - Left face -
        };

        return mesh;
    }

    public static Mesh CreatePrismMesh()
    {
        var mesh = new Mesh();

        // - 18 vertices for independent face normals and UVs -
        mesh.Vertices = new Vector3[]
        {
            // - Front face (+Z) -
            new Vector3(-0.5f, -0.5f,  0.5f), // 0: bottom-left
            new Vector3( 0.5f, -0.5f,  0.5f), // 1: bottom-right
            new Vector3( 0.0f,  0.5f,  0.5f), // 2: top

            // - Back face (-Z) -
            new Vector3( 0.5f, -0.5f, -0.5f), // 3: bottom-left (from back)
            new Vector3(-0.5f, -0.5f, -0.5f), // 4: bottom-right (from back)
            new Vector3( 0.0f,  0.5f, -0.5f), // 5: top

            // - Bottom face (-Y) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 6: bottom-left
            new Vector3( 0.5f, -0.5f, -0.5f), // 7: bottom-right
            new Vector3( 0.5f, -0.5f,  0.5f), // 8: top-right
            new Vector3(-0.5f, -0.5f,  0.5f), // 9: top-left

            // - Left sloping face (-X) -
            new Vector3(-0.5f, -0.5f, -0.5f), // 10: bottom-left
            new Vector3(-0.5f, -0.5f,  0.5f), // 11: bottom-right
            new Vector3( 0.0f,  0.5f,  0.5f), // 12: top-right
            new Vector3( 0.0f,  0.5f, -0.5f), // 13: top-left

            // - Right sloping face (+X) -
            new Vector3( 0.5f, -0.5f,  0.5f), // 14: bottom-left
            new Vector3( 0.5f, -0.5f, -0.5f), // 15: bottom-right
            new Vector3( 0.0f,  0.5f, -0.5f), // 16: top-right
            new Vector3( 0.0f,  0.5f,  0.5f), // 17: top-left
        };

        mesh.Triangles = new int[]
        {
            0, 1, 2,             // - Front face -
            3, 4, 5,             // - Back face -
            6, 7, 8,  6, 8, 9,   // - Bottom face -
            10, 11, 12,  10, 12, 13, // - Left sloping face -
            14, 15, 16,  14, 16, 17  // - Right sloping face -
        };

        return mesh;
    }
}
