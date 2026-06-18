# Documentación: Módulo Matemático (Mini 3D)

## 1. Estrcutura Principal: Matrix4x4

La estructura Matrix4x4 representa una matriz de 4 filas y 4 columnas. El componente principal de las transformaciones en 3D.


### Estructura del objeto:

- Utiliza un array bidimencional `float[,] Elements` de 4x4 (orden 4).
- Está basada en la convención de vectores de columna matemáticos.


### Operaciones:

- **Matriz x Matriz**: Implementa el producto escalar de "Fila por columna". Permite encadenar varias transformaciones en una sola matriz (Traslación x Rotación x Escala).
- **Matriz x Vector4**: Transforma un vertice 3D aplicando las operaciones en la matriz. El vector estructuralmente es una matriz de 4x1.

