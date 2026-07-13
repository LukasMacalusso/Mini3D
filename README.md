# Mini3D
Mini3D is a software-based 3D rendering engine developed in C#. It implements a complete graphics pipeline on the CPU, handling spatial transformations, perspective projection, and triangle rasterization without relying on hardware acceleration or external mathematics libraries

# Technical Showcase
- Custom Math Library: Implements proprietary Matrix4x4, Vector2, Vector3, and Vector4 structures with custom operator overloading for efficient matrix multiplications.
- CPU Graphics Pipeline: Executes the full pipeline translating vertices from Local Space to World Space, View Space, and finally to Screen Space.
- Perspective Projection: Calculates perspective division to remap the View Frustum into Normalized Device Coordinates (NDC).
- Software Rasterization: Evaluates point-inside-triangle logic using bounding boxes and 2D cross-product edge functions.
- Spatial Occlusion: Sorts and renders polygons by average Z-depth using the Painter's Algorithm.
- Hardware Abstraction: Utilizes Raylib-cs strictly for window initialization, input capture, and 2D framebuffer pixel drawing.

# Quick Start
## PreRequisites
- .NET SDK installed on your machine.
## Run
dotnet build Mini3D.csproj
dotnet run --project Mini3D.csproj
