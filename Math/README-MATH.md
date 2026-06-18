# Documentación: Módulo Matemático (Mini 3D)

## 1. Estrcutura Principal: Matrix4x4

La estructura Matrix4x4 representa una matriz de 4 filas y 4 columnas. El componente principal de las transformaciones en 3D.


### Estructura del objeto:

- Utiliza un array bidimencional `float[,] Elements` de 4x4 (orden 4).
- Está basada en la convención de vectores de columna matemáticos.


### Operaciones:

- **Matriz x Matriz**: Implementa el producto escalar de "Fila por columna". Permite encadenar varias transformaciones en una sola matriz (Traslación x Rotación x Escala).
- **Matriz x Vector4**: Transforma un vertice 3D aplicando las operaciones en la matriz. El vector estructuralmente es un vector4, equivalente a una matriz 4x1 matematicamente.


## 2. Generador de Transformaciones: MatrixFactory
Esta clase estática contiene métodos de ayuda para instanciar matrices ya configuradas (Identidad, Transformacion, etc).

### CreateTranslation(Vector3 offset)
Construye una matriz de Traslación.
* Inicializa una Matriz Identidad (1s en la diagonal) para preservar la escala y rotación actual.
* Inserta el vector de traslación (`offset.X`, `offset.Y`, `offset.Z`) en la última columna.
* Uso: Mover un objeto a una coordenada específica en el mundo.

### CreateScale(Vector3 scale)
Construye una matriz de Escala.
* Reemplaza la diagonal principal `[X, Y, Z]` por los factores de escala dados, manteniendo `W = 1`.
* Uso: Aumentar, reducir o deformar el tamaño de un objeto.

### CreateRotationX, CreateRotationY, CreateRotationZ
Construyen matrices de Rotación utilizando trigonometría espacial.
* Requieren ángulos en radianes (`angleRadians`).
* Eje Fijo: La fila y columna correspondientes al eje de rotación mantienen el valor de la matriz identidad (1), porque los valores sobre ese eje no cambian durante el giro.
* Los ejes restantes se actualizan combinando sus coordenadas originales mediante las funciones `Math.Sin` y `Math.Cos`.



## 3. Ejemplo de Uso para la Capa Engine

Para crear la posición final de un modelo en el mundo (World Matrix), las matrices deben multiplicarse. En álgebra lineal, el orden de los factores sí altera el resultado. 

Para lograr el comportamiento estándar donde un objeto se escala sobre su centro, luego gira sobre sí mismo y finalmente se mueve a su posición en el mundo, el orden de multiplicación correcto en código es:

```csharp

Matrix4x4 scale = MatrixFactory.CreateScale(new Vector3(2, 2, 2));
Matrix4x4 rot = MatrixFactory.CreateRotationY(3.14159f); // Girar 180° en radianes (dos pi son 360°)
Matrix4x4 trans = MatrixFactory.CreateTranslation(new Vector3(10, 0, 5));

// 2. Combinarlas en una matriz "World" (Orden: T * R * S)
// La matriz más a la derecha es la primera transformación en aplicarse físicamente al vértice.
Matrix4x4 worldMatrix = trans * rot * scale;

// 3. Aplicar al vértice
Vector4 vertice = new Vector4(1, 1, 1, 1);
Vector4 transformado = worldMatrix * vertice;
```
