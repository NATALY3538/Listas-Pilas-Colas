using System;
using System.Text;
using Practica1_Listas.Ejercicios;
using Practica1_Listas.Estructuras;
using Practica1_Listas.Modelos;

namespace Practica1_Listas
{
    /// <summary>
    /// Punto de entrada principal del proyecto de Consola para la Práctica de Listas
    /// (Unidad II: Estructuras de datos básicas - Ing. Mirian Magaly Canché Caamal).
    /// </summary>
    public static class Program
    {
        private const int OpcionProductosSupermercado = 1;
        private const int OpcionParesEImpares = 2;
        private const int OpcionAprobadosYReprobados = 3;
        private const int OpcionEliminarYOrdenarProductos = 4;
        private const int OpcionListarPalabrasPorLetra = 5;
        private const int OpcionSalir = 6;

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            if (args.Length > 0 && args[0] == "--verificar")
            {
                EjecutarPruebasAutomaticas();
                return;
            }

            EjecutarMenuInteractivo();
        }

        /// <summary>
        /// Muestra el menú de opciones ordenado acorde a cada problema de la Práctica de Listas,
        /// validando que se ejecute cada ejercicio sin salir del programa hasta seleccionar la opción 6.
        /// </summary>
        private static void EjecutarMenuInteractivo()
        {
            bool continuarEnPrograma = true;

            while (continuarEnPrograma)
            {
                Console.WriteLine();
                Console.WriteLine("======================================================================");
                Console.WriteLine("        UNIVERSIDAD TECNOLÓGICA METROPOLITANA - ESTRUCTURA DE DATOS   ");
                Console.WriteLine("                    UNIDAD II: PRÁCTICA DE LISTAS                     ");
                Console.WriteLine("======================================================================");
                Console.WriteLine("  1. Productos disponibles y retirados");
                Console.WriteLine("  2. Pares e Impares");
                Console.WriteLine("  3. Aprobados y Reprobados");
                Console.WriteLine("  4. Eliminar y ordenar productos");
                Console.WriteLine("  5. Listar palabras por letra");
                Console.WriteLine("  6. Salir");
                Console.WriteLine("======================================================================");
                Console.Write("Seleccione una opción (1-6): ");

                string? entradaOpcion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entradaOpcion))
                {
                    Console.WriteLine("\nError: Hay datos faltantes. Por favor, ingrese el número de una opción (1-6).");
                    continue;
                }

                int opcionSeleccionada;
                if (!int.TryParse(entradaOpcion.Trim(), out opcionSeleccionada))
                {
                    Console.WriteLine("\nError: Introducir sólo números. Seleccione una opción válida entre 1 y 6.");
                    continue;
                }

                Console.WriteLine();

                try
                {
                    switch (opcionSeleccionada)
                    {
                        case OpcionProductosSupermercado:
                            Ejercicio1ProductosSupermercado.Ejecutar();
                            PausarRegresoMenu();
                            break;

                        case OpcionParesEImpares:
                            Ejercicio2ParesImpares.Ejecutar();
                            PausarRegresoMenu();
                            break;

                        case OpcionAprobadosYReprobados:
                            Ejercicio3AprobadosReprobados.Ejecutar();
                            PausarRegresoMenu();
                            break;

                        case OpcionEliminarYOrdenarProductos:
                            Ejercicio4EliminarOrdenarProductos.Ejecutar();
                            PausarRegresoMenu();
                            break;

                        case OpcionListarPalabrasPorLetra:
                            Ejercicio5ListarPalabrasPorLetra.Ejecutar();
                            PausarRegresoMenu();
                            break;

                        case OpcionSalir:
                            continuarEnPrograma = false;
                            Console.WriteLine("Saliendo del programa de Práctica de Listas. ¡Hasta pronto!");
                            break;

                        default:
                            Console.WriteLine("Error: Opción fuera de rango. Por favor, elija un número del 1 al 6.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nSe produjo un error controlado durante la ejecución: {ex.Message}");
                    PausarRegresoMenu();
                }
            }
        }

        private static void PausarRegresoMenu()
        {
            Console.WriteLine("\nPresione ENTER para volver al menú principal...");
            Console.ReadLine();
        }

        /// <summary>
        /// Verifica automáticamente los 5 ejercicios de la Práctica de Listas.
        /// </summary>
        private static void EjecutarPruebasAutomaticas()
        {
            Console.WriteLine("=== VERIFICACIÓN DE LOS 5 EJERCICIOS DE LA PRÁCTICA LISTAS ===\n");

            // Ejercicio 1: Productos disponibles y retirados
            ListaEnlazada<ProductoEscaneado> disp = new ListaEnlazada<ProductoEscaneado>();
            ListaEnlazada<ProductoEscaneado> ret = new ListaEnlazada<ProductoEscaneado>();
            disp.Agregar(Ejercicio1ProductosSupermercado.CrearProductoAleatorio(1));
            disp.Agregar(Ejercicio1ProductosSupermercado.CrearProductoAleatorio(2));
            disp.Agregar(Ejercicio1ProductosSupermercado.CrearProductoAleatorio(3));
            ProductoEscaneado? prodRetirado;
            disp.ExtraerPrimero(p => p.Nombre == "producto2", out prodRetirado);
            if (prodRetirado != null) ret.Agregar(prodRetirado);
            Console.WriteLine($"[Ejercicio 1] Disponibles ({disp.Cantidad}): {disp.FormatearElementos()}");
            Console.WriteLine($"[Ejercicio 1] Retirados   ({ret.Cantidad}): {ret.FormatearElementos()}\n");

            // Ejercicio 2: Pares e Impares
            ListaEnlazada<int> aleatorios = new ListaEnlazada<int>();
            int[] muestra = { 14, 27, 8, 33, 42, 19 };
            for (int i = 0; i < muestra.Length; i++) aleatorios.Agregar(muestra[i]);
            ListaEnlazada<int> pares, impares;
            Ejercicio2ParesImpares.SepararParesEImpares(aleatorios, out pares, out impares);
            Console.WriteLine($"[Ejercicio 2] Original: {aleatorios.FormatearElementos()}");
            Console.WriteLine($"[Ejercicio 2] Pares   : {pares.FormatearElementos()}");
            Console.WriteLine($"[Ejercicio 2] Impares : {impares.FormatearElementos()}\n");

            // Ejercicio 3: Aprobados y Reprobados
            ListaEnlazada<Alumno> alumnos = new ListaEnlazada<Alumno>();
            alumnos.Agregar(new Alumno("Ana", 9.5m));
            alumnos.Agregar(new Alumno("Luis", 6.4m));
            alumnos.Agregar(new Alumno("Carlos", 8.0m));
            alumnos.Agregar(new Alumno("Marta", 5.8m));
            ListaEnlazada<Alumno> reprobados;
            Ejercicio3AprobadosReprobados.SepararReprobados(alumnos, out reprobados);
            Console.WriteLine($"[Ejercicio 3] Aprobados  ({alumnos.Cantidad}): {alumnos.FormatearElementos()}");
            Console.WriteLine($"[Ejercicio 3] Reprobados ({reprobados.Cantidad}): {reprobados.FormatearElementos()}\n");

            // Ejercicio 4: Eliminar y ordenar productos
            ListaEnlazada<ProductoCompra> compras = new ListaEnlazada<ProductoCompra>();
            compras.Agregar(new ProductoCompra("P03", "Zanahoria", 18.50m));
            compras.Agregar(new ProductoCompra("P01", "Arroz", 32.00m));
            compras.Agregar(new ProductoCompra("P02", "Leche", 26.50m));
            ProductoCompra? eliminado;
            compras.ExtraerPrimero(p => p.Clave == "P03", out eliminado);
            Ejercicio4EliminarOrdenarProductos.OrdenarPorNombre(compras);
            decimal total = Ejercicio4EliminarOrdenarProductos.CalcularCostoTotal(compras);
            Console.WriteLine($"[Ejercicio 4] Ordenados tras eliminar P03: {compras.FormatearElementos()} | Costo Total: ${total:F2}\n");

            // Ejercicio 5: Listar palabras por letra (ejemplo exacto del PDF)
            ListaEnlazada<string> lista1 = new ListaEnlazada<string>();
            ListaEnlazada<GrupoLetra> grupos = new ListaEnlazada<GrupoLetra>();
            string[] palabrasEjemplo = { "Fresa", "Fresca", "Orilla", "Oso", "Peso", "Pez" };
            for (int i = 0; i < palabrasEjemplo.Length; i++)
            {
                Ejercicio5ListarPalabrasPorLetra.RegistrarPalabra(palabrasEjemplo[i], lista1, grupos);
            }
            Console.WriteLine("[Ejercicio 5] Clasificación del ejemplo del PDF:");
            Ejercicio5ListarPalabrasPorLetra.MostrarListasClasificadas(lista1, grupos);
        }
    }
}
