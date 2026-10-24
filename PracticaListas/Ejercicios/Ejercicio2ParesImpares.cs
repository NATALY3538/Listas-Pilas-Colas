using System;
using Practica1_Listas.Estructuras;

namespace Practica1_Listas.Ejercicios
{
    /// <summary>
    /// Ejercicio 2. Pares e Impares:
    /// Crea una aplicación que genere una lista de números aleatorios; posterior a esto,
    /// la aplicación debe mostrar todos los números pares en una lista y todos los números impares en otra lista.
    /// </summary>
    public static class Ejercicio2ParesImpares
    {
        private static readonly Random GeneradorAleatorio = new Random();

        /// <summary>
        /// Clasifica los elementos de una lista de enteros en una lista de pares y otra de impares.
        /// </summary>
        /// <param name="listaAleatoria">Lista original de números generados.</param>
        /// <param name="listaPares">Lista de salida con todos los números pares.</param>
        /// <param name="listaImpares">Lista de salida con todos los números impares.</param>
        public static void SepararParesEImpares(
            ListaEnlazada<int> listaAleatoria,
            out ListaEnlazada<int> listaPares,
            out ListaEnlazada<int> listaImpares)
        {
            listaPares = new ListaEnlazada<int>();
            listaImpares = new ListaEnlazada<int>();

            int[] elementos = listaAleatoria.ObtenerElementos();
            for (int i = 0; i < elementos.Length; i++)
            {
                int numero = elementos[i];
                if (numero % 2 == 0)
                {
                    listaPares.Agregar(numero);
                }
                else
                {
                    listaImpares.Agregar(numero);
                }
            }
        }

        /// <summary>
        /// Ejecuta el flujo interactivo en consola para el Ejercicio 2 (Pares e Impares).
        /// </summary>
        public static void Ejecutar()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("  EJERCICIO 2: LISTA DE NÚMEROS PARES E IMPARES");
            Console.WriteLine("======================================================================");
            Console.WriteLine("Descripción: Genera una lista de números aleatorios y muestra todos");
            Console.WriteLine("los números pares en una lista y todos los impares en otra lista.\n");

            int cantidad = SolicitarCantidadPositiva("¿Cuántos números aleatorios desea generar en la lista?: ");

            ListaEnlazada<int> listaOriginal = new ListaEnlazada<int>();
            for (int i = 0; i < cantidad; i++)
            {
                listaOriginal.Agregar(GeneradorAleatorio.Next(1, 101));
            }

            ListaEnlazada<int> listaPares;
            ListaEnlazada<int> listaImpares;
            SepararParesEImpares(listaOriginal, out listaPares, out listaImpares);

            Console.WriteLine("\n--- RESULTADO DEL PROCESO ---");
            Console.WriteLine($"Lista original ({listaOriginal.Cantidad} números): {listaOriginal.FormatearElementos()}");
            Console.WriteLine($"Lista de PARES   ({listaPares.Cantidad} números): {listaPares.FormatearElementos()}");
            Console.WriteLine($"Lista de IMPARES ({listaImpares.Cantidad} números): {listaImpares.FormatearElementos()}");
            Console.WriteLine("----------------------------------------------------------------------");
        }

        private static int SolicitarCantidadPositiva(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Error: Hay datos faltantes. Ingrese la cantidad de números a generar.\n");
                    continue;
                }

                int cantidad;
                if (!int.TryParse(entrada.Trim(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Error: Introducir sólo números enteros mayores que cero.\n");
                    continue;
                }

                return cantidad;
            }
        }
    }
}
