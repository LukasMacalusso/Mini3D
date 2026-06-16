namespace Mini3D.Engine;

using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;

public class Renderer
{
    private int _screenWidth;
    private int _screenHeight;

    private List<ProjectedFace> _facesToDraw;

    public Renderer(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
        _facesToDraw = new List<ProjectedFace>();
    }

    public void RenderScene(List<Mesh> sceneObjects, Camera camera)
    {
        // --- The Integrator's Pipeline --- //
        // This method runs every single frame.

        // Clear the list from the previous frame instead of creating a new one! (Zero Allocations)
        _facesToDraw.Clear();

        // TODO 1: Get the View Matrix from the camera
        // TODO 2: Get the Perspective Matrix from the ProjectionMatrixFactory

        foreach (Mesh mesh in sceneObjects)
        {
            // TODO 3: Generate the World Matrix for this mesh (Translation * Rotation * Scale)

            // TODO 4: Loop through the mesh's Triangles index buffer (stepping by 3)
            //   a) Get the 3 Vertices from the mesh
            //   b) Multiply each vertex by the World Matrix
            //   c) Multiply by the View Matrix
            //   d) Multiply by the Perspective Matrix
            //   e) Perform the Perspective Divide (divide X, Y, Z by the W component)
            //   f) Scale the X and Y coordinates to fit your screen resolution (pixels)
            //   g) Calculate the average depth (Z) of the triangle
            //   h) Create a new ProjectedFace and add it to the facesToDraw list
        }

        // TODO 5: Sort facesToDraw by their AverageDepth (Painter's Algorithm)
        
        // TODO 6: Loop through the sorted list and use Raylib.DrawTriangle to paint them!
    }
}
