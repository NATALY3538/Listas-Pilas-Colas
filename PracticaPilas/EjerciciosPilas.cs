using System;
using System.Text;

namespace PracticaPilas
{
    public static class EjerciciosPilas
    {
        #region Ejercicio 1: Invertir palabra
        /// <summary>
        /// Ejercicio 1: Invierte los caracteres de una palabra utilizando una pila LIFO.
        /// Ejemplo: "UTM" -> "MTU".
        /// </summary>
        /// <param name="palabra">Palabra a invertir.</param>
        /// <returns>Cadena con los caracteres en orden inverso.</returns>
        public static string InvertirPalabra(string palabra)
        {
            if (string.IsNullOrEmpty(palabra))
                return string.Empty;

            Pila<char> pilaLetras = new();

            // 1. Apilar cada carácter de izquierda a derecha
            foreach (char c in palabra)
            {
                pilaLetras.Push(c);
            }

            // 2. Desapilar los caracteres (saldrán en orden inverso por propiedad LIFO)
            StringBuilder resultado = new();
            while (!pilaLetras.EstaVacia)
            {
                resultado.Append(pilaLetras.Pop());
            }

            return resultado.ToString();
        }
        #endregion

        #region Ejercicio 2: Palíndromo
        /// <summary>
        /// Ejercicio 2: Determina si una palabra o frase es un palíndromo utilizando una pila.
        /// </summary>
        /// <param name="texto">Texto a evaluar.</param>
        /// <param name="textoLimpio">Texto normalizado sin espacios ni caracteres especiales.</param>
        /// <param name="textoInvertido">Texto invertido mediante la pila.</param>
        /// <returns>True si es palíndromo, False en caso contrario.</returns>
        public static bool EsPalindromo(string texto, out string textoLimpio, out string textoInvertido)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                textoLimpio = string.Empty;
                textoInvertido = string.Empty;
                return false;
            }

            // 1. Normalización: convertir a minúsculas y omitir espacios
            StringBuilder sbLimpio = new();
            foreach (char c in texto)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sbLimpio.Append(char.ToLowerInvariant(c));
                }
            }

            textoLimpio = sbLimpio.ToString();

            // 2. Apilar los caracteres del texto normalizado
            Pila<char> pila = new();
            foreach (char c in textoLimpio)
            {
                pila.Push(c);
            }

            // 3. Desapilar para formar la versión invertida
            StringBuilder sbInvertido = new();
            while (!pila.EstaVacia)
            {
                sbInvertido.Append(pila.Pop());
            }

            textoInvertido = sbInvertido.ToString();

            // 4. Comparar el texto normalizado con el invertido
            return textoLimpio.Equals(textoInvertido, StringComparison.Ordinal);
        }
        #endregion

        #region Ejercicio 3: Suma de números grandes
        /// <summary>
        /// Ejercicio 3: Suma dos números enteros arbitrariamente grandes utilizando pilas.
        /// Reproduce exactamente el diagrama de operand-stack1, operand-stack2 y resul-stack.
        /// </summary>
        /// <param name="num1">Primer sumando como cadena numérica.</param>
        /// <param name="num2">Segundo sumando como cadena numérica.</param>
        /// <param name="mostrarPasos">Si es verdadero, imprime el desglose visual de cada operación.</param>
        /// <returns>El resultado de la suma como cadena numérica.</returns>
        public static string SumarNumerosGrandes(string num1, string num2, bool mostrarPasos = true)
        {
            // Validar que sean números válidos
            num1 = string.IsNullOrWhiteSpace(num1) ? "0" : num1.Trim();
            num2 = string.IsNullOrWhiteSpace(num2) ? "0" : num2.Trim();

            Pila<int> operandStack1 = new();
            Pila<int> operandStack2 = new();
            Pila<int> resulStack = new();

            // 1. Cargar operand-stack1 (el último dígito queda en el tope)
            foreach (char c in num1)
            {
                if (char.IsDigit(c))
                    operandStack1.Push(c - '0');
                else
                    throw new ArgumentException($"El número '{num1}' contiene caracteres no numéricos.");
            }

            // 2. Cargar operand-stack2 (el último dígito queda en el tope)
            foreach (char c in num2)
            {
                if (char.IsDigit(c))
                    operandStack2.Push(c - '0');
                else
                    throw new ArgumentException($"El número '{num2}' contiene caracteres no numéricos.");
            }

            if (mostrarPasos)
            {
                Console.WriteLine($"\n[Carga Inicial en Pilas]");
                Console.WriteLine($"  Número 1: {num1} -> Dígitos apilados en operand-stack1 (Tope = {(operandStack1.EstaVacia ? 0 : operandStack1.Peek())})");
                Console.WriteLine($"  Número 2: {num2} -> Dígitos apilados en operand-stack2 (Tope = {(operandStack2.EstaVacia ? 0 : operandStack2.Peek())})");
                Console.WriteLine("\n[Proceso de Suma Columna por Columna con Acarreo]:");
            }

            int acarreo = 0;
            int paso = 1;

            // 3. Sumar extrayendo los dígitos de las cimas
            while (!operandStack1.EstaVacia || !operandStack2.EstaVacia || acarreo > 0)
            {
                int d1 = operandStack1.EstaVacia ? 0 : operandStack1.Pop();
                int d2 = operandStack2.EstaVacia ? 0 : operandStack2.Pop();

                int sumaColumna = d1 + d2 + acarreo;
                int digitoResultado = sumaColumna % 10;
                int nuevoAcarreo = sumaColumna / 10;

                if (mostrarPasos)
                {
                    string infoAcarreo = acarreo > 0 ? $" + (acarreo anterior {acarreo})" : "";
                    Console.WriteLine($"  Paso {paso}: {d1} + {d2}{infoAcarreo} = {sumaColumna} -> Se apila en resul-stack: {digitoResultado}, Nuevo acarreo: {nuevoAcarreo}");
                }

                resulStack.Push(digitoResultado);
                acarreo = nuevoAcarreo;
                paso++;
            }

            // 4. Vaciar resul-stack para obtener el resultado en orden correcto
            StringBuilder resultadoFinal = new();
            while (!resulStack.EstaVacia)
            {
                resultadoFinal.Append(resulStack.Pop());
            }

            return resultadoFinal.ToString();
        }
        #endregion

        #region Ejercicio 4: Reemplazar valor
        /// <summary>
        /// Ejercicio 4: Reemplaza en una pila de enteros todas las ocurrencias del valor 'viejo'
        /// por el valor 'nuevo', preservando el orden original de todos los elementos.
        /// </summary>
        /// <param name="pila">Pila a modificar.</param>
        /// <param name="nuevo">Valor de reemplazo.</param>
        /// <param name="viejo">Valor a buscar y sustituir.</param>
        /// <returns>Cantidad de reemplazos efectuados.</returns>
        public static int Reemplazar(Pila<int> pila, int nuevo, int viejo)
        {
            if (pila == null)
                throw new ArgumentNullException(nameof(pila));

            Pila<int> pilaAux = new();
            int reemplazos = 0;

            // 1. Desapilar todo hacia la pila auxiliar haciendo el reemplazo
            while (!pila.EstaVacia)
            {
                int actual = pila.Pop();
                if (actual == viejo)
                {
                    pilaAux.Push(nuevo);
                    reemplazos++;
                }
                else
                {
                    pilaAux.Push(actual);
                }
            }

            // 2. Restaurar los elementos desde la pila auxiliar hacia la pila original
            // para mantener la orientación LIFO original.
            while (!pilaAux.EstaVacia)
            {
                pila.Push(pilaAux.Pop());
            }

            return reemplazos;
        }
        #endregion
    }
}
