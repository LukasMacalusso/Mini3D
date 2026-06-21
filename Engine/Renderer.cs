namespace Mini3D.Engine;

using System;
using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;
using Raylib_cs;
using Mesh = Mini3D.Models.Mesh;
using System.Reflection.PortableExecutable;

public unsafe class Renderer
{
    // -- Render window setup --
    private int _screenWidth;
    private int _screenHeight;
    private List<ScreenTriangle> _screenTriangles;

    // -- Framebuffer Setup --
    private Color* _frameBuffer;
    private Texture2D _screenTexture;
    private Image _screenImage;
    public bool WireframeMode = false;

    public Renderer(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
        _screenTriangles = new List<ScreenTriangle>();

        // - Setup custom framebuffer -
        _screenImage = Raylib.GenImageColor(_screenWidth, _screenHeight, Color.Black);
        _frameBuffer = (Color*)_screenImage.Data;
        _screenTexture = Raylib.LoadTextureFromImage(_screenImage);
    }

    public void RenderScene(List<Mesh> sceneMeshes, Camera camera)
    {
        ClearScreen();

        SetScreenTrianglesFromSceneMeshes(sceneMeshes, camera);

        _screenTriangles.Sort((a, b) => b.AverageDepth.CompareTo(a.AverageDepth));

        DrawScreenTriangles(_screenTriangles);

        RenderTexture();
    }

    private void ClearScreen()
    {
        ClearFrameBuffer(Color.Black);
        _screenTriangles.Clear();
    }
    private void ClearFrameBuffer(Color color)
    {
        for (int i = 0; i < _screenWidth * _screenHeight; i++)
        {
            _frameBuffer[i] = color;
        }
    }


    private void SetScreenTrianglesFromSceneMeshes(List<Mesh> sceneObjects, Camera camera)
    {

        Matrix4x4 viewMatrix = MatrixFactory.CreateViewMatrix(camera.Position, camera.Target, new Vector3(0, 1, 0));
        Matrix4x4 perspectiveMatrix = ProjectionMatrixFactory.CreatePerspectiveMatrix(
            90.0f,                               // - Field of View in Degrees -
            _screenWidth / (float)_screenHeight, // - Aspect Ratio (Width / Height) -
            0.1f,                                // - Near Clipping Plane -
            1000f                                // - Far Clipping Plane -
        );

        foreach (Mesh mesh in sceneObjects)
        {
            SetScreenTrianglesFromMesh(mesh, viewMatrix, perspectiveMatrix);
        }
    }

    private void SetScreenTrianglesFromMesh(Mesh mesh, Matrix4x4 viewMatrix, Matrix4x4 perspectiveMatrix)
    {
        Matrix4x4 worldMatrix = mesh.WorldMatrix;

        for (int triangleIndex = 0; triangleIndex < mesh.TriangleIndices.Length; triangleIndex += 3)
        {
            var (v1, v2, v3) = GetMeshVertices(mesh, triangleIndex);

            Matrix4x4 fullTransform = perspectiveMatrix * viewMatrix * worldMatrix;
            ApplyTransform(ref v1, ref v2, ref v3, fullTransform);

            // - Simple Near-Plane Culling: If any vertex is behind or too close to the camera, drop the triangle. -
            if (v1.W <= 0.1f || v2.W <= 0.1f || v3.W <= 0.1f)
            {
                continue;
            }

            ApplyPerspectiveDivide(ref v1, ref v2, ref v3);
            ConvertToScreenSpace(ref v1, ref v2, ref v3);

            float averageDepth = (v1.Z + v2.Z + v3.Z) / 3.0f;

            _screenTriangles.Add(new ScreenTriangle(
                new Vector2(v1.X, v1.Y),
                new Vector2(v2.X, v2.Y),
                new Vector2(v3.X, v3.Y),
                averageDepth
            ));
        }
    }
    private (Vector4 v1, Vector4 v2, Vector4 v3) GetMeshVertices(Mesh mesh, int triangleIndex)
    {
        int i1 = mesh.TriangleIndices[triangleIndex];
        int i2 = mesh.TriangleIndices[triangleIndex + 1];
        int i3 = mesh.TriangleIndices[triangleIndex + 2];

        Vector4 v1 = mesh.Vertices[i1].ToVector4();
        Vector4 v2 = mesh.Vertices[i2].ToVector4();
        Vector4 v3 = mesh.Vertices[i3].ToVector4();

        return (v1, v2, v3);
    }
    private void ApplyTransform(ref Vector4 v1, ref Vector4 v2, ref Vector4 v3, Matrix4x4 transformMatrix)
    {
        v1 = transformMatrix * v1;
        v2 = transformMatrix * v2;
        v3 = transformMatrix * v3;
    }
    private void ApplyPerspectiveDivide(ref Vector4 v1, ref Vector4 v2, ref Vector4 v3)
    {
        v1.X /= v1.W; v1.Y /= v1.W; v1.Z /= v1.W;
        v2.X /= v2.W; v2.Y /= v2.W; v2.Z /= v2.W;
        v3.X /= v3.W; v3.Y /= v3.W; v3.Z /= v3.W;
    }
    private void ConvertToScreenSpace(ref Vector4 v1, ref Vector4 v2, ref Vector4 v3)
    {
        v1.X = (v1.X + 1.0f) * 0.5f * _screenWidth;
        v1.Y = (1.0f - v1.Y) * 0.5f * _screenHeight;

        v2.X = (v2.X + 1.0f) * 0.5f * _screenWidth;
        v2.Y = (1.0f - v2.Y) * 0.5f * _screenHeight;

        v3.X = (v3.X + 1.0f) * 0.5f * _screenWidth;
        v3.Y = (1.0f - v3.Y) * 0.5f * _screenHeight;
    }


    private void DrawScreenTriangles(List<ScreenTriangle> trianglesToDraw)
    {
        foreach (ScreenTriangle triangle in trianglesToDraw)
        {
            if (WireframeMode)
            {
                DrawLine(triangle.PointA, triangle.PointB, Color.Green);
                DrawLine(triangle.PointB, triangle.PointC, Color.Green);
                DrawLine(triangle.PointC, triangle.PointA, Color.Green);
            }
            else
            {
                DrawFilledTriangle(triangle.PointA, triangle.PointB, triangle.PointC, Color.DarkBlue);
                DrawLine(triangle.PointA, triangle.PointB, Color.Black);
                DrawLine(triangle.PointB, triangle.PointC, Color.Black);
                DrawLine(triangle.PointC, triangle.PointA, Color.Black);
            }
        }
    }

    private void DrawFilledTriangle(Vector2 v0, Vector2 v1, Vector2 v2, Color color)
    {
        int minX = (int)System.Math.Min(v0.X, System.Math.Min(v1.X, v2.X));
        int minY = (int)System.Math.Min(v0.Y, System.Math.Min(v1.Y, v2.Y));
        int maxX = (int)System.Math.Max(v0.X, System.Math.Max(v1.X, v2.X));
        int maxY = (int)System.Math.Max(v0.Y, System.Math.Max(v1.Y, v2.Y));

        minX = System.Math.Max(0, minX);
        minY = System.Math.Max(0, minY);

        maxX = System.Math.Min(_screenWidth - 1, maxX);
        maxY = System.Math.Min(_screenHeight - 1, maxY);

        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                if (IsPointInside(v0, v1, x, y) && IsPointInside(v1, v2, x, y) && IsPointInside(v2, v0, x, y))
                {
                    PutPixel(x, y, color);
                }
            }
        }

    }
    private bool IsPointInside(Vector2 vA, Vector2 vB, float pX, float pY)
    {
        return ((pX - vA.X) * (vB.Y - vA.Y) - (pY - vA.Y) * (vB.X - vA.X)) >= 0;
    }
    private void DrawLine(Vector2 start, Vector2 end, Color color)
    {
        int x0 = (int)start.X;
        int x1 = (int)end.X;
        int y0 = (int)start.Y;
        int y1 = (int)end.Y;

        int distance_x = System.Math.Abs(x1 - x0);
        int distance_y = System.Math.Abs(y1 - y0);

        int step_x = (x0 < x1) ? 1 : -1;
        int step_y = (y0 < y1) ? 1 : -1;

        int err = distance_x - distance_y;

        while (true)
        {
            PutPixel(x0, y0, color);
            if (x0 == x1 && y0 == y1) break;

            int e2 = 2 * err;

            if (e2 > -distance_y)
            {
                err -= distance_y;
                x0 += step_x;
            }

            if (e2 < distance_x)
            {
                err += distance_x;
                y0 += step_y;
            }
        }
    }
    private void PutPixel(int x, int y, Color color)
    {
        if (x < 0 || x >= _screenWidth || y < 0 || y >= _screenHeight) return;
        _frameBuffer[y * _screenWidth + x] = color;
    }

    private void RenderTexture()
    {
        Raylib.UpdateTexture(_screenTexture, _screenImage.Data);
        Raylib.DrawTexture(_screenTexture, 0, 0, Color.White);
    }





}
