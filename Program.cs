using Raylib_cs;
using Mini3D.Engine;
using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;

namespace Mini3D;

class Program
{
    static void Main(string[] args)
    {
        // 1. Initialize Raylib Window
        const int screenWidth = 1000;
        const int screenHeight = 800;
        Raylib.InitWindow(screenWidth, screenHeight, "Mini Motor 3D");
        Raylib.SetTargetFPS(60);

        // 2. Setup the Engine and Scene
        Renderer renderer = new Renderer(screenWidth, screenHeight);
        
        // Start the camera at Z = -10, looking at the origin (0,0,0)
        Camera camera = new Camera(new Vector3(0, 0, -10), new Vector3(0, 0, 0));
        
        List<Mesh> sceneObjects = new List<Mesh>();
        // The Integrator will add the Modeler's shapes here once they are built:
        // sceneObjects.Add(MeshFactory.CreateCubeMesh());

        // 3. Main Game Loop
        while (!Raylib.WindowShouldClose())
        {
            // -- UPDATE LOGIC (Input & Physics) --
            // TODO: Read Raylib.IsKeyDown() here to move the camera or rotate the meshes!

            // -- DRAWING LOGIC --
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Pass the world data to the Renderer pipeline
            renderer.RenderScene(sceneObjects, camera);

            Raylib.DrawFPS(10, 10);
            Raylib.EndDrawing();
        }

        // 4. Cleanup
        Raylib.CloseWindow();
    }
}
