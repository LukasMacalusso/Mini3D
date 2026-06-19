using Raylib_cs;
using Mini3D.Engine;
using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;
using Mesh = Mini3D.Models.Mesh;

namespace Mini3D;

class Program
{
    static void Main(string[] args)
    {
        // -- Initialize Window -- //
        const int screenWidth = 1000;
        const int screenHeight = 800;
        Raylib.InitWindow(screenWidth, screenHeight, "Mini Motor 3D");
        Raylib.SetTargetFPS(60);

        // -- Setup Engine & Scene -- //
        Renderer renderer = new Renderer(screenWidth, screenHeight);
        Camera camera = new Camera(new Vector3(0, 0, -5), new Vector3(0, 0, 0));
        
        List<Mesh> sceneObjects = new List<Mesh>();
        Mesh myCube = MeshFactory.CreateCubeMesh();
        
        // Push the cube out a bit so it's clearly visible
        myCube.Position = new Vector3(0, 0, 0); 
        sceneObjects.Add(myCube);

        // -- Main Game Loop -- //
        while (!Raylib.WindowShouldClose())
        {
            // -- Update Logic -- //
            
            // Constantly rotate the cube to see it in action!
            myCube.Rotation.X += 0.01f;
            myCube.Rotation.Y += 0.02f;
            myCube.Rotation.Z += 0.01f;

            // Optional: Move camera with keyboard
            if (Raylib.IsKeyDown(KeyboardKey.W)) camera.Position.Z += 0.1f;
            if (Raylib.IsKeyDown(KeyboardKey.S)) camera.Position.Z -= 0.1f;

            // -- Drawing Logic -- //
            Raylib.BeginDrawing();
            
            // Execute the custom rendering pipeline
            renderer.RenderScene(sceneObjects, camera);

            // Draw UI on top of the rendered frame
            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("W/S to move camera", 10, 30, 20, Color.Green);
            
            Raylib.EndDrawing();
        }

        // -- Cleanup -- //
        Raylib.CloseWindow();
    }
}
