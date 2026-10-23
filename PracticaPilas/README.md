# PRÁCTICA: OPERACIONES CON PILAS (STACKS)
**Asignatura:** Estructuras de Datos Orientadas a Objetos  
**Valor:** 10 c/u, Total = 40 puntos

---

## 📋 Análisis de los Ejercicios

### Ejercicio 1. Invertir palabra
* **Propósito:** Leer una palabra e invertir el orden de sus letras utilizando la propiedad **LIFO** (*Last In, First Out*).
* **Algoritmo:**
  1. Se recorre la palabra de izquierda a derecha apilando (`Push`) cada carácter en una pila de caracteres.
  2. Al desapilar (`Pop`) sucesivamente hasta que la pila quede vacía, los caracteres emergen en orden inverso exacto al que entraron.
  3. Ejemplo: `"UTM"` $\rightarrow$ Apila `U`, luego `T`, luego `M` (tope). Al desapilar: sale `M`, luego `T`, luego `U` $\rightarrow$ `"MTU"`.

### Ejercicio 2. Palíndromo
* **Propósito:** Determinar si una palabra o frase se lee igual de izquierda a derecha que de derecha a izquierda.
* **Algoritmo:**
  1. Se normaliza la entrada eliminando espacios y convirtiendo a minúsculas (para tolerar mayúsculas como `"Malayalam"` u `"Oruro"`).
  2. Se apilan todos los caracteres en una pila.
  3. Al desapilarse, se reconstruye la palabra invertida.
  4. Se compara la cadena normalizada con la cadena invertida. Si son idénticas, es un palíndromo comprobado.

### Ejercicio 3. Suma de números grandes mediante Pilas
* **Propósito:** Sumar números enteros arbitrariamente grandes que exceden la capacidad de los tipos nativos convencionales (como `long` de 64 bits).
* **Algoritmo (siguiendo el diagrama):**
  1. Se usan 3 pilas: `operand-stack1`, `operand-stack2` y `resul-stack`.
  2. Los dígitos de cada número se leen de izquierda a derecha y se apilan, de tal forma que el dígito menos significativo (unidades) queda en el tope de cada pila.
  3. En cada iteración se extrae el tope de ambas pilas (`Pop`), se suman junto con el `acarreo` previo.
  4. El dígito resultante (`suma % 10`) se apila en `resul-stack` y el nuevo acarreo es `suma / 10`.
  5. Al terminar, se desapilan todos los elementos de `resul-stack`, obteniendo el número final en su orden correcto.
  6. Ejemplo: `592 + 3784 = 4376`.

### Ejercicio 4. Reemplazar valor en Pila de enteros
* **Propósito:** Diseñar la función `Reemplazar(pila, nuevo, viejo)` que busque el valor `viejo` y lo sustituya por `nuevo`, manteniendo el orden original de la pila.
* **Algoritmo:**
  1. Se utiliza una pila auxiliar `pilaAux`.
  2. Se desapila elemento por elemento de la pila original. Si coincide con `viejo`, se apila `nuevo` en `pilaAux`; de lo contrario, se apila el elemento original.
  3. Al vaciar la pila original, `pilaAux` contiene los elementos invertidos con los reemplazos hechos.
  4. Se desapilan todos los elementos de `pilaAux` de regreso a la pila original, restaurando exactamente el orden LIFO original.

---

## 🚀 Instrucciones de Ejecución

### Opción 1: Ejecución en C# (.NET 9)
```bash
# Modo interactivo con menú por consola:
dotnet run

# Modo de pruebas automáticas con todos los ejemplos:
dotnet run -- --demo
```

### Opción 2: Ejecución en Java
```bash
# Compilar:
javac PracticaPilas.java

# Ejecutar:
java PracticaPilas
```
