using System;
using System.Globalization;
using Practica1_Listas.Estructuras;
using Practica1_Listas.Modelos;

namespace Practica1_Listas.Ejercicios
{
    /// <summary>
    /// Ejercicio 3. Aprobados y Reprobados:
    /// Solicita nombres de alumnos y sus respectivas calificaciones y los almacena en una lista.
    /// Saca de dicha lista a los alumnos que reprobaron con calificación menor que 7 y los almacena
    /// nuevamente en una lista de reprobados, mostrando los alumnos aprobados y los reprobados.
    /// </summary>
    public static class Ejercicio3AprobadosReprobados
    {
        private const decimal CalificacionMinimaAprobatoria = 7.0m;

        /// <summary>
        /// Saca a los alumnos con calificación menor que 7 de la lista general y los almacena
        /// en la lista de reprobados, dejando en la primera lista únicamente a los aprobados.
        /// </summary>
        /// <param name="listaAlumnos">Lista inicial con todos los alumnos; tras el proceso conserva los aprobados.</param>
        /// <param name="listaReprobados">Lista donde se almacenan los alumnos extraídos con calificación menor a 7.</param>
        public static void SepararReprobados(
            ListaEnlazada<Alumno> listaAlumnos,
            out ListaEnlazada<Alumno> listaReprobados)
        {
            listaReprobados = new ListaEnlazada<Alumno>();
            listaAlumnos.ExtraerHaciaOtraLista(
                alumno => alumno.Calificacion < CalificacionMinimaAprobatoria,
                listaReprobados);
        }

        /// <summary>
        /// Ejecuta el flujo interactivo en consola para el Ejercicio 3 (Aprobados y Reprobados).
        /// </summary>
        public static void Ejecutar()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("  EJERCICIO 3: ALUMNOS APROBADOS Y REPROBADOS");
            Console.WriteLine("======================================================================");
            Console.WriteLine("Descripción: Almacena alumnos y sus calificaciones en una lista, saca");
            Console.WriteLine("a quienes tengan calificación menor que 7 hacia una lista de reprobados");
            Console.WriteLine("y muestra ambas listas.\n");

            int cantidadAlumnos = SolicitarEnteroPositivo("¿Cuántos alumnos desea registrar en la lista?: ");
            ListaEnlazada<Alumno> listaAlumnos = new ListaEnlazada<Alumno>();

            for (int i = 1; i <= cantidadAlumnos; i++)
            {
                Console.WriteLine($"\n--- Datos del Alumno #{i} ---");
                string nombre = SolicitarTextoNoVacio("  Nombre del alumno       : ");
                decimal calificacion = SolicitarCalificacionDecimal("  Calificación (0.0 - 10.0): ");
                listaAlumnos.Agregar(new Alumno(nombre, calificacion));
            }

            Console.WriteLine($"\nLista inicial capturada ({listaAlumnos.Cantidad} alumnos):");
            MostrarAlumnos(listaAlumnos);

            ListaEnlazada<Alumno> listaReprobados;
            SepararReprobados(listaAlumnos, out listaReprobados);

            Console.WriteLine("\n--- RESULTADO TRAS EXTRAER REPROBADOS (< 7.0) ---");
            Console.WriteLine($"Lista de APROBADOS ({listaAlumnos.Cantidad}):");
            MostrarAlumnos(listaAlumnos);

            Console.WriteLine($"\nLista de REPROBADOS ({listaReprobados.Cantidad}):");
            MostrarAlumnos(listaReprobados);
            Console.WriteLine("----------------------------------------------------------------------");
        }

        private static void MostrarAlumnos(ListaEnlazada<Alumno> lista)
        {
            Alumno[] alumnos = lista.ObtenerElementos();
            if (alumnos.Length == 0)
            {
                Console.WriteLine("  (Ningún alumno en esta lista)");
                return;
            }

            for (int i = 0; i < alumnos.Length; i++)
            {
                Console.WriteLine($"  {i + 1}. {alumnos[i]}");
            }
        }

        private static string SolicitarTextoNoVacio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  Error: Hay datos faltantes. Ingrese el nombre del alumno.");
                    continue;
                }

                return entrada.Trim();
            }
        }

        private static decimal SolicitarCalificacionDecimal(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  Error: Hay datos faltantes. Ingrese la calificación.");
                    continue;
                }

                string normalizado = entrada.Trim().Replace(',', '.');
                decimal calificacion;
                if (!decimal.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out calificacion))
                {
                    Console.WriteLine("  Error: Introducir sólo números decimales válidos.");
                    continue;
                }

                if (calificacion < 0m || calificacion > 10m)
                {
                    Console.WriteLine("  Error: La calificación debe estar en el rango de 0 a 10.");
                    continue;
                }

                return calificacion;
            }
        }

        private static int SolicitarEnteroPositivo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Error: Hay datos faltantes.\n");
                    continue;
                }

                int cantidad;
                if (!int.TryParse(entrada.Trim(), out cantidad) || cantidad <= 0)
                {
                    Console.WriteLine("Error: Introducir sólo números enteros mayores a cero.\n");
                    continue;
                }

                return cantidad;
            }
        }
    }
}
