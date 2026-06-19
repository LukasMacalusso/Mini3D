using Raylib_cs;
using Mini3D.Engine;
using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;
using Mesh = Mini3D.Models.Mesh;

namespace Mini3D;

class Program
{
    static int _currentMeshIndex = 0;

    static void Main(string[] args)
    {
        // -- Initialize Window -- //
        const int screenWidth = 1000;
        const int screenHeight = 800;
        Raylib.InitWindow(screenWidth, screenHeight, "Mini 3D Defense Showcase");
        Raylib.SetTargetFPS(60);
        Raylib.DisableCursor();

        // -- Setup Engine -- //
        Renderer renderer = new Renderer(screenWidth, screenHeight);
        Camera camera = new Camera(new Vector3(0, 0, -5), new Vector3(0, 0, 0));

        // -- Scene Setup -- //
        List<Mesh> allMeshes = new List<Mesh>
        {
            MeshFactory.CreateCubeMesh(),
            MeshFactory.CreatePrismMesh(),
            MeshFactory.CreatePyramidMesh()
        };
        List<Mesh> sceneObjects = new List<Mesh>();
        sceneObjects.Add(allMeshes[_currentMeshIndex]);

        while (!Raylib.WindowShouldClose())
        {
            // -- Bind Controllers -- //
            MovementController(camera);
            ModeController(renderer);
            MeshSwapController(allMeshes, sceneObjects);
            TransformationController(sceneObjects);

            // -- Render -- //
            Raylib.BeginDrawing();

            renderer.RenderScene(sceneObjects, camera);
            RenderUI(renderer.WireframeMode);

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }

    static void RenderUI(bool isWireframe)
    {
        Raylib.DrawFPS(10, 10);

        Raylib.DrawText("1/2/3: Swap Mesh  |  Spacebar: Toggle X-Ray", 10, 70, 20, Color.Green);
        Raylib.DrawText("Left Click: Rotate  |  Right Click: Move  |  Scroll: Scale", 10, 95, 20, Color.Green);
        Raylib.DrawText("W/A/S/D: Move Camera", 10, 120, 20, Color.Green);

        string modeText = isWireframe ? "WIREFRAME MODE" : "SOLID MODE";
        Color modeColor = isWireframe ? Color.Green : Color.Blue;
        Raylib.DrawText(modeText, 10, 160, 20, modeColor);
    }

    static void MovementController(Camera camera)
    {
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            camera.Position.Z += 0.1f;
            camera.Target.Z += 0.1f;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            camera.Position.Z -= 0.1f;
            camera.Target.Z -= 0.1f;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            camera.Position.X -= 0.1f;
            camera.Target.X -= 0.1f;
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            camera.Position.X += 0.1f;
            camera.Target.X += 0.1f;
        }
    }

    static void ModeController(Renderer renderer)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space)) renderer.WireframeMode = !renderer.WireframeMode;
    }

    static void MeshSwapController(List<Mesh> allMeshes, List<Mesh> sceneObjects)
    {

        Mesh activeMesh = sceneObjects[0];

        if (Raylib.IsKeyPressed(KeyboardKey.One)) _currentMeshIndex = 0;
        if (Raylib.IsKeyPressed(KeyboardKey.Two)) _currentMeshIndex = 1;
        if (Raylib.IsKeyPressed(KeyboardKey.Three)) _currentMeshIndex = 2;

        if (sceneObjects[0] != allMeshes[_currentMeshIndex])
        {
            sceneObjects.Clear();
            sceneObjects.Add(allMeshes[_currentMeshIndex]);
            activeMesh = sceneObjects[0];
        }
    }

    static void TransformationController(List<Mesh> sceneObjects)
    {
        Mesh activeMesh = sceneObjects[0];

        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            System.Numerics.Vector2 mouseDelta = Raylib.GetMouseDelta();
            activeMesh.Rotation.Y += mouseDelta.X * 0.01f;
            activeMesh.Rotation.X += mouseDelta.Y * 0.01f;
        }

        if (Raylib.IsMouseButtonDown(MouseButton.Right))
        {
            System.Numerics.Vector2 mouseDelta = Raylib.GetMouseDelta();
            activeMesh.Position.X += mouseDelta.X * 0.01f;
            activeMesh.Position.Y -= mouseDelta.Y * 0.01f;
        }

        float scroll = Raylib.GetMouseWheelMove();
        if (scroll != 0)
        {
            activeMesh.Scale.X += scroll * 0.1f;
            activeMesh.Scale.Y += scroll * 0.1f;
            activeMesh.Scale.Z += scroll * 0.1f;
        }

    }

}
