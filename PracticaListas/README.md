# Práctica: Listas (Unidad II - Estructura de Datos)

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

## Ejercicios Incluidos

1. **Productos disponibles y retirados** ([`Ejercicio1ProductosSupermercado.cs`](Ejercicios/Ejercicio1ProductosSupermercado.cs)): Escaneo de productos con cantidad y precio aleatorios (`producto1`, `producto2`, ...) y retiro hacia lista de retirados.
2. **Pares e Impares** ([`Ejercicio2ParesImpares.cs`](Ejercicios/Ejercicio2ParesImpares.cs)): Generación de números enteros aleatorios y separación en lista de pares y lista de impares.
3. **Aprobados y Reprobados** ([`Ejercicio3AprobadosReprobados.cs`](Ejercicios/Ejercicio3AprobadosReprobados.cs)): Registro de alumnos con calificaciones, extracción de reprobados (`< 7.0`) a una nueva lista y visualización de aprobados y reprobados.
4. **Eliminar y ordenar productos** ([`Ejercicio4EliminarOrdenarProductos.cs`](Ejercicios/Ejercicio4EliminarOrdenarProductos.cs)): Alta de productos con clave, nombre y precio, eliminación por clave, ordenamiento alfabético por nombre y cálculo del costo total.
5. **Listar palabras por letra** ([`Ejercicio5ListarPalabrasPorLetra.cs`](Ejercicios/Ejercicio5ListarPalabrasPorLetra.cs)): Almacenamiento de palabras en `Lista1` y separación dinámica en listas clasificadas por su letra inicial (`Lista2`, `Lista3`, `Lista4`, ...).

---

## Cómo Ejecutar

```bash
# Modo interactivo con menú en consola:
dotnet run --project PracticaListas

# Modo de verificación automática de los 5 ejercicios:
dotnet run --project PracticaListas -- --verificar
```
