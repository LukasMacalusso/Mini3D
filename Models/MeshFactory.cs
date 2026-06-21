namespace Mini3D.Models;

using Mini3D.Math;

public static class MeshFactory
{
    // -- Geometry Generators --

    // -- CUBE --
    public static Mesh CreateCubeMesh()
    {
        return new Mesh
        {
            Vertices = GetCubeVertices(),
            TriangleIndices = GetCubeTriangleIndices()
        };
    }

    private static Vector3[] GetCubeVertices()
    {
        Vector3[] Front() => [new(-0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, 0.5f), new(0.5f, 0.5f, 0.5f), new(-0.5f, 0.5f, 0.5f)];
        Vector3[] Back() => [new(0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, -0.5f), new(-0.5f, 0.5f, -0.5f), new(0.5f, 0.5f, -0.5f)];
        Vector3[] Left() => [new(-0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, 0.5f), new(-0.5f, 0.5f, 0.5f), new(-0.5f, 0.5f, -0.5f)];
        Vector3[] Right() => [new(0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, -0.5f), new(0.5f, 0.5f, -0.5f), new(0.5f, 0.5f, 0.5f)];
        Vector3[] Top() => [new(-0.5f, 0.5f, 0.5f), new(0.5f, 0.5f, 0.5f), new(0.5f, 0.5f, -0.5f), new(-0.5f, 0.5f, -0.5f)];
        Vector3[] Bottom() => [new(-0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, 0.5f), new(-0.5f, -0.5f, 0.5f)];

        return [.. Front(), .. Back(), .. Left(), .. Right(), .. Top(), .. Bottom()];
    }

    private static int[] GetCubeTriangleIndices()
    {
        int[] Front() => [0, 1, 2, 0, 2, 3];
        int[] Back() => [4, 5, 6, 4, 6, 7];
        int[] Left() => [8, 9, 10, 8, 10, 11];
        int[] Right() => [12, 13, 14, 12, 14, 15];
        int[] Top() => [16, 17, 18, 16, 18, 19];
        int[] Bottom() => [20, 21, 22, 20, 22, 23];

        return [.. Front(), .. Back(), .. Left(), .. Right(), .. Top(), .. Bottom()];
    }

    // -- PYRAMID --
    public static Mesh CreatePyramidMesh()
    {
        return new Mesh
        {
            Vertices = GetPyramidVertices(),
            TriangleIndices = GetPyramidTriangleIndices()
        };
    }

    private static Vector3[] GetPyramidVertices()
    {
        Vector3[] Base() => [new(-0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, 0.5f), new(-0.5f, -0.5f, 0.5f)];
        Vector3[] Front() => [new(-0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, 0.5f), new(0.0f, 0.5f, 0.0f)];
        Vector3[] Right() => [new(0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, -0.5f), new(0.0f, 0.5f, 0.0f)];
        Vector3[] Back() => [new(0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, -0.5f), new(0.0f, 0.5f, 0.0f)];
        Vector3[] Left() => [new(-0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, 0.5f), new(0.0f, 0.5f, 0.0f)];

        return [.. Base(), .. Front(), .. Right(), .. Back(), .. Left()];
    }

    private static int[] GetPyramidTriangleIndices()
    {
        int[] Base() => [0, 1, 2, 0, 2, 3];
        int[] Front() => [4, 5, 6];
        int[] Right() => [7, 8, 9];
        int[] Back() => [10, 11, 12];
        int[] Left() => [13, 14, 15];

        return [.. Base(), .. Front(), .. Right(), .. Back(), .. Left()];
    }

    // -- PRISM --
    public static Mesh CreatePrismMesh()
    {
        return new Mesh
        {
            Vertices = GetPrismVertices(),
            TriangleIndices = GetPrismTriangleIndices()
        };
    }

    private static Vector3[] GetPrismVertices()
    {
        Vector3[] Front() => [new(-0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, 0.5f), new(0.0f, 0.5f, 0.5f)];
        Vector3[] Back() => [new(0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, -0.5f), new(0.0f, 0.5f, -0.5f)];
        Vector3[] Bottom() => [new(-0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, -0.5f), new(0.5f, -0.5f, 0.5f), new(-0.5f, -0.5f, 0.5f)];
        Vector3[] Left() => [new(-0.5f, -0.5f, -0.5f), new(-0.5f, -0.5f, 0.5f), new(0.0f, 0.5f, 0.5f), new(0.0f, 0.5f, -0.5f)];
        Vector3[] Right() => [new(0.5f, -0.5f, 0.5f), new(0.5f, -0.5f, -0.5f), new(0.0f, 0.5f, -0.5f), new(0.0f, 0.5f, 0.5f)];

        return [.. Front(), .. Back(), .. Bottom(), .. Left(), .. Right()];
    }

    private static int[] GetPrismTriangleIndices()
    {
        int[] Front() => [0, 1, 2];
        int[] Back() => [3, 4, 5];
        int[] Bottom() => [6, 7, 8, 6, 8, 9];
        int[] Left() => [10, 11, 12, 10, 12, 13];
        int[] Right() => [14, 15, 16, 14, 16, 17];

        return [.. Front(), .. Back(), .. Bottom(), .. Left(), .. Right()];
    }
}
