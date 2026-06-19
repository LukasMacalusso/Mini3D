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

            // 1. Rotate with Left Mouse
            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                System.Numerics.Vector2 mouseDelta = Raylib.GetMouseDelta();
                myCube.Rotation.Y -= mouseDelta.X * 0.01f;
                myCube.Rotation.X += mouseDelta.Y * 0.01f;
            }

            // 2. Move with Right Mouse
            if (Raylib.IsMouseButtonDown(MouseButton.Right))
            {
                System.Numerics.Vector2 mouseDelta = Raylib.GetMouseDelta();
                myCube.Position.X += mouseDelta.X * 0.01f;
                myCube.Position.Y += mouseDelta.Y * 0.01f;
            }

            // 3. Scale with Scroll Wheel
            float scroll = Raylib.GetMouseWheelMove();
            if (scroll != 0)
            {
                myCube.Scale.X += scroll * 0.1f;
                myCube.Scale.Y += scroll * 0.1f;
                myCube.Scale.Z += scroll * 0.1f;
            }

            // Move camera with keyboard
            if (Raylib.IsKeyDown(KeyboardKey.W)) camera.Position.Z += 0.1f;
            if (Raylib.IsKeyDown(KeyboardKey.S)) camera.Position.Z -= 0.1f;

            // -- Drawing Logic -- //
            Raylib.BeginDrawing();

            // Execute the custom rendering pipeline
            renderer.RenderScene(sceneObjects, camera);

            // Draw UI on top of the rendered frame
            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("Left Click: Rotate | Right Click: Move | Scroll: Scale | W/S: Camera", 10, 30, 20, Color.Green);

            Raylib.EndDrawing();
        }

        // -- Cleanup -- //
        Raylib.CloseWindow();
    }
}
