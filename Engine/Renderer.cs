namespace Mini3D.Engine;

using System;
using Mini3D.Math;
using Mini3D.Models;
using System.Collections.Generic;
using Raylib_cs;
using Mesh = Mini3D.Models.Mesh;

public unsafe class Renderer
{
    // -- Render window setup -- //
    private int _screenWidth;
    private int _screenHeight;
    private List<ScreenTriangle> _facesToDraw;

    // -- Framebuffer Setup -- //
    private Color* _frameBuffer;
    private Texture2D _screenTexture;
    private Image _screenImage;

    public Renderer(int width, int height)
    {
        _screenWidth = width;
        _screenHeight = height;
        _facesToDraw = new List<ScreenTriangle>();

        // - Setup custom framebuffer - //
        _screenImage = Raylib.GenImageColor(_screenWidth, _screenHeight, Color.Black);
        _frameBuffer = (Color*)_screenImage.Data;
        _screenTexture = Raylib.LoadTextureFromImage(_screenImage);
    }

    public void RenderScene(List<Mesh> sceneObjects, Camera camera)
    {
        // - Clear screen - //
        ClearFrameBuffer(Color.Black);
        _facesToDraw.Clear();

        // - Get Matrices - //
        Matrix4x4 viewMatrix = camera.GetViewMatrix();
        Matrix4x4 perspectiveMatrix = ProjectionMatrixFactory.CreatePerspectiveMatrix(
            90.0f,                               // - Field of View in Degrees
            _screenWidth / (float)_screenHeight, // - Aspect Ratio (Width / Height)
            0.1f,                                // - Near Clipping Plane
            1000f                                // - Far Clipping Plane
        );

        foreach (Mesh mesh in sceneObjects)
        {
            Matrix4x4 worldMatrix = mesh.WorldMatrix;
            for (int triangleIndex = 0; triangleIndex < mesh.TriangleIndices.Length; triangleIndex += 3)
            {
                // -- Get Triangle Indices -- //
                int index1 = mesh.TriangleIndices[triangleIndex];
                int index2 = mesh.TriangleIndices[triangleIndex + 1];
                int index3 = mesh.TriangleIndices[triangleIndex + 2];

                // -- Get Vertices -- //
                Vector4 v1 = mesh.Vertices[index1].ToVector4();
                Vector4 v2 = mesh.Vertices[index2].ToVector4();
                Vector4 v3 = mesh.Vertices[index3].ToVector4();

                // -- Project Vertices -- //
                Vector4 projectedV1 = perspectiveMatrix * viewMatrix * worldMatrix * v1;
                Vector4 projectedV2 = perspectiveMatrix * viewMatrix * worldMatrix * v2;
                Vector4 projectedV3 = perspectiveMatrix * viewMatrix * worldMatrix * v3;

                // -- Get Normalized Device Coordinates -- //
                Vector3 ndcV1 = new Vector3(projectedV1.X / projectedV1.W, projectedV1.Y / projectedV1.W, projectedV1.Z / projectedV1.W);
                Vector3 ndcV2 = new Vector3(projectedV2.X / projectedV2.W, projectedV2.Y / projectedV2.W, projectedV2.Z / projectedV2.W);
                Vector3 ndcV3 = new Vector3(projectedV3.X / projectedV3.W, projectedV3.Y / projectedV3.W, projectedV3.Z / projectedV3.W);

                // -- Get Scalated 2D points -- //
                Vector2 p1 = new Vector2((ndcV1.X + 1.0f) * 0.5f * _screenWidth, (1.0f - ndcV1.Y) * 0.5f * _screenHeight);
                Vector2 p2 = new Vector2((ndcV2.X + 1.0f) * 0.5f * _screenWidth, (1.0f - ndcV2.Y) * 0.5f * _screenHeight);
                Vector2 p3 = new Vector2((ndcV3.X + 1.0f) * 0.5f * _screenWidth, (1.0f - ndcV3.Y) * 0.5f * _screenHeight);

                // -- Create new ScreenTriangle with average depth -- //
                float averageDepth = (ndcV1.Z + ndcV2.Z + ndcV3.Z) / 3.0f;
                _facesToDraw.Add(new ScreenTriangle(p1, p2, p3, averageDepth));
            }
        }

        _facesToDraw.Sort((a, b) => b.AverageDepth.CompareTo(a.AverageDepth));

        // -- Draw all triangles to the Frame Buffer -- //
        foreach (ScreenTriangle triangle in _facesToDraw)
        {
            DrawFilledTriangle(triangle.PointA, triangle.PointB, triangle.PointC, Color.DarkBlue);
            DrawLine(triangle.PointA, triangle.PointB, Color.White);
            DrawLine(triangle.PointB, triangle.PointC, Color.White);
            DrawLine(triangle.PointC, triangle.PointA, Color.White);
        }

        Raylib.UpdateTexture(_screenTexture, _screenImage.Data);
        Raylib.DrawTexture(_screenTexture, 0, 0, Color.White);
    }

    // -- Helper Drawing Methods -- //
    public void ClearFrameBuffer(Color color)
    {
        for (int i = 0; i < _screenWidth * _screenHeight; i++)
        {
            _frameBuffer[i] = color;
        }
    }

    private void PutPixel(int x, int y, Color color)
    {
        if (x < 0 || x >= _screenWidth || y < 0 || y >= _screenHeight) return;
        _frameBuffer[y * _screenWidth + x] = color;
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

        bool IsPointInside(Vector2 vA, Vector2 vB, float pX, float pY)
        {
            return ((pX - vA.X) * (vB.Y - vA.Y) - (pY - vA.Y) * (vB.X - vA.X)) >= 0;
        }
    }
}
