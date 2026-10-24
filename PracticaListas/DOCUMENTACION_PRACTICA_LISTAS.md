# Documentación: Práctica de Listas (Unidad II - Estructura de Datos)

- **Asignatura:** Estructura de Datos
- **Docente:** Ing. Mirian Magaly Canché Caamal
- **Unidad:** Unidad II. Estructuras de datos básicas
- **Práctica:** PRÁCTICA. LISTAS (Ejercicios 1 al 5)

---

## Estructura de Datos Implementada: `ListaEnlazada<T>` y `NodoLista<T>`

Se implementó desde cero la estructura de datos genérica [`ListaEnlazada<T>`](Estructuras/ListaEnlazada.cs) apoyada en nodos enlazados [`NodoLista<T>`](Estructuras/NodoLista.cs):
- `Agregar(T elemento)`: Inserta un nuevo nodo al final de la lista.
- `IntentarBuscar(Predicate<T> predicado, out T? elementoEncontrado)`: Busca un elemento en la lista.
- `ExtraerPrimero(Predicate<T> predicado, out T? elementoEliminado)`: Elimina y devuelve el primer nodo que cumpla la condición.
- `ExtraerHaciaOtraLista(Predicate<T> predicado, ListaEnlazada<T> listaDestino)`: Saca los nodos que cumplan la condición de la lista actual y los transfiere a otra lista.
- `Ordenar(Comparison<T> comparador)`: Ordena los nodos de la lista según el criterio indicado.

---

## Ejercicio 1. Productos disponibles y retirados

### Descripción del Problema
Un supermercado requiere una aplicación que almacene los productos pasados por el escáner en una lista. Cada `Producto` (clase) contiene una cantidad y un precio generados aleatoriamente al crearse, con nombre básico (`producto1`, `producto2`, `producto3`, etc.). La aplicación debe permitir retirar elementos del almacén y mostrar tanto los productos disponibles como los retirados junto con sus cantidades.

### Análisis (Entrada, Proceso y Salida)
- **Entrada:**
  - Cantidad inicial de productos a escanear y opción para agregar más productos o indicar el nombre/número del producto a retirar (`producto1`, `producto2`, etc.).
- **Proceso:**
  1. Al crear cada instancia de [`ProductoEscaneado`](Modelos/ModelosLista.cs#L10-L30), se asigna el nombre consecutivo `productoN`, una cantidad entera aleatoria y un precio decimal aleatorio, agregándolo a `listaDisponibles`.
  2. Cuando el usuario solicita retirar un producto, se invoca `ExtraerPrimero` sobre `listaDisponibles` y el nodo extraído se inserta en `listaRetirados`.
- **Salida:**
  - Muestra la lista y cantidad total de productos disponibles y la lista y cantidad total de productos retirados.

---

## Ejercicio 2. Pares e Impares

### Descripción del Problema
Crear una aplicación que genere una lista de números aleatorios y, posteriormente, muestre todos los números pares en una lista y todos los números impares en otra lista.

### Análisis (Entrada, Proceso y Salida)
- **Entrada:**
  - Cantidad de números enteros aleatorios a generar (validando que sea un número entero positivo).
- **Proceso:**
  1. Se generan los números aleatorios y se almacenan en `listaOriginal` (`ListaEnlazada<int>`).
  2. Se recorre `listaOriginal` evaluando el módulo `numero % 2 == 0`:
     - Si es `0`, se inserta en `listaPares`.
     - Si es distinto de `0`, se inserta en `listaImpares`.
- **Salida:**
  - Muestra la lista original generada, la lista de números pares y la lista de números impares.

---

## Ejercicio 3. Aprobados y Reprobados

### Descripción del Problema
Crear una aplicación que solicite nombres de alumnos y sus respectivas calificaciones almacenándolos en una lista. La aplicación debe sacar a los alumnos que reprobaron con una calificación menor que `7` y almacenarlos nuevamente en una lista de reprobados, mostrando los alumnos que aprobaron y los alumnos que reprobaron.

### Análisis (Entrada, Proceso y Salida)
- **Entrada:**
  - Cantidad de alumnos y, por cada uno, su nombre y calificación numérica decimal (validada en el rango `0.0` a `10.0`).
- **Proceso:**
  1. Se almacenan todos los objetos [`Alumno`](Modelos/ModelosLista.cs#L36-L54) en `listaAlumnos`.
  2. Mediante `ExtraerHaciaOtraLista`, se desvinculan de `listaAlumnos` todos los nodos cuya `Calificacion < 7.0` y se insertan en `listaReprobados`.
- **Salida:**
  - Muestra la lista de alumnos aprobados (`>= 7.0`) y la lista de alumnos reprobados (`< 7.0`).

---

## Ejercicio 4. Eliminar y ordenar productos

### Descripción del Problema
Crear una aplicación que permita agregar productos con precio a una lista, eliminar productos de acuerdo a una clave de producto solicitada al usuario, mostrar los elementos ordenados alfabéticamente por nombre y mostrar el costo total de compra.

### Análisis (Entrada, Proceso y Salida)
- **Entrada:**
  - Clave, nombre y precio decimal de cada producto a agregar, así como la clave del producto que el usuario desee eliminar.
- **Proceso:**
  1. Se almacenan los objetos [`ProductoCompra`](Modelos/ModelosLista.cs#L60-L81) en `listaProductos`.
  2. Al solicitar eliminar por clave, se busca y extrae el nodo correspondiente con `ExtraerPrimero`.
  3. Se ordena `listaProductos` alfabéticamente por `Nombre` mediante el método `Ordenar` de la lista enlazada y se calcula la suma acumulada de los precios.
- **Salida:**
  - Muestra los productos ordenados por nombre y el costo total de compra formateado a dos decimales.

---

## Ejercicio 5. Listar palabras por letra

### Descripción del Problema
Crear una aplicación para almacenar palabras solicitadas al usuario en `Lista1`, separar las palabras y dividirlas en listas clasificadas por su primera letra (`Lista2`, `Lista3`, `Lista4`, ...). En caso de que el usuario agregue más palabras con letras diferentes, la aplicación debe crear nuevas listas dinámicamente si no existe aún una lista con esa letra inicial.

### Análisis (Entrada, Proceso y Salida)
- **Entrada:**
  - Palabras ingresadas por el usuario inicialmente y mediante la opción de agregar nuevas palabras.
- **Proceso:**
  1. Cada palabra ingresada se agrega a `Lista1` (`ListaEnlazada<string>`).
  2. Se obtiene la primera letra de la palabra en mayúscula y se busca en `listasClasificadas` (`ListaEnlazada<GrupoLetra>`) si ya existe una lista para dicha letra.
  3. Si ya existe, se agrega la palabra a esa lista; si no existe, se instancia un nuevo [`GrupoLetra`](Modelos/ModelosLista.cs#L87-L99) (creando una nueva `ListaEnlazada<string>`) y se añade a `listasClasificadas`.
- **Salida:**
  - Muestra `Lista1` con todas las palabras y `Lista2`, `Lista3`, `Lista4`, ... con las palabras agrupadas por su letra inicial (ej. `Fresa, Fresca` | `Orilla, Oso` | `Peso, Pez`).

---

## Ejecución del Proyecto

```bash
# Modo interactivo con menú en consola:
dotnet run --project PracticaListas

# Modo de verificación automática de los 5 ejercicios:
dotnet run --project PracticaListas -- --verificar
```
