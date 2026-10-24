using System;
using Practica1_Listas.Estructuras;
using Practica1_Listas.Modelos;

namespace Practica1_Listas.Ejercicios
{
    /// <summary>
    /// Ejercicio 1. Productos disponibles y retirados:
    /// Almacena Productos (clase) pasados por el escáner en una lista.
    /// Cada producto al crearse contiene una cantidad y un precio generados aleatoriamente,
    /// y su nombre es básico (producto1, producto2, producto3, etc.).
    /// Permite retirar elementos del almacén y mostrar la cantidad de productos disponibles y retirados.
    /// </summary>
    public static class Ejercicio1ProductosSupermercado
    {
        private static readonly Random GeneradorAleatorio = new Random();

        /// <summary>
        /// Crea un producto con nombre básico (<c>productoN</c>) y valores aleatorios de cantidad y precio.
        /// </summary>
        /// <param name="consecutivo">Número consecutivo del producto.</param>
        /// <returns>Instancia de <see cref="ProductoEscaneado"/>.</returns>
        public static ProductoEscaneado CrearProductoAleatorio(int consecutivo)
        {
            int cantidadAleatoria = GeneradorAleatorio.Next(1, 21);
            decimal precioAleatorio = Math.Round((decimal)(GeneradorAleatorio.NextDouble() * 190.0 + 10.0), 2);
            return new ProductoEscaneado($"producto{consecutivo}", cantidadAleatoria, precioAleatorio);
        }

        /// <summary>
        /// Ejecuta el flujo interactivo en consola para el Ejercicio 1 (Productos disponibles y retirados).
        /// </summary>
        public static void Ejecutar()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("  EJERCICIO 1: PRODUCTOS DISPONIBLES Y RETIRADOS (SUPERMERCADO)");
            Console.WriteLine("======================================================================");
            Console.WriteLine("Descripción: Almacena Productos (producto1, producto2, ...) con cantidad");
            Console.WriteLine("y precio aleatorios en una lista, permite retirar productos del almacén");
            Console.WriteLine("y muestra la cantidad de productos disponibles y retirados.\n");

            ListaEnlazada<ProductoEscaneado> listaDisponibles = new ListaEnlazada<ProductoEscaneado>();
            ListaEnlazada<ProductoEscaneado> listaRetirados = new ListaEnlazada<ProductoEscaneado>();
            int consecutivoProducto = 1;

            int iniciales = SolicitarEnteroPositivo("¿Cuántos productos desea pasar inicialmente por el escáner?: ");
            for (int i = 0; i < iniciales; i++)
            {
                listaDisponibles.Agregar(CrearProductoAleatorio(consecutivoProducto++));
            }

            bool enSubmenu = true;
            while (enSubmenu)
            {
                MostrarEstadoAlmacen(listaDisponibles, listaRetirados);

                Console.WriteLine("\nOpciones del Almacén (Ejercicio 1):");
                Console.WriteLine("  1. Escanear (agregar) nuevo producto aleatorio");
                Console.WriteLine("  2. Retirar un producto del almacén (por nombre, ej. producto1)");
                Console.WriteLine("  3. Volver al menú principal");
                Console.Write("Seleccione una opción (1-3): ");

                string? opcionTexto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(opcionTexto))
                {
                    Console.WriteLine("Error: Hay datos faltantes. Seleccione una opción del 1 al 3.");
                    continue;
                }

                int opcion;
                if (!int.TryParse(opcionTexto.Trim(), out opcion))
                {
                    Console.WriteLine("Error: Introducir sólo números.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ProductoEscaneado nuevo = CrearProductoAleatorio(consecutivoProducto++);
                        listaDisponibles.Agregar(nuevo);
                        Console.WriteLine($"\nProducto escaneado y agregado: {nuevo}");
                        break;

                    case 2:
                        if (listaDisponibles.EstaVacia())
                        {
                            Console.WriteLine("\nAviso: No hay productos disponibles en el almacén para retirar.");
                            break;
                        }

                        Console.Write("Ingrese el nombre o número del producto a retirar (ej. producto1 o 1): ");
                        string? entradaRetiro = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(entradaRetiro))
                        {
                            Console.WriteLine("Error: Hay datos faltantes. Debe indicar qué producto retirar.");
                            break;
                        }

                        string claveBusqueda = entradaRetiro.Trim();
                        if (int.TryParse(claveBusqueda, out int numProd))
                        {
                            claveBusqueda = $"producto{numProd}";
                        }

                        ProductoEscaneado? retirado;
                        bool exito = listaDisponibles.ExtraerPrimero(
                            p => string.Equals(p.Nombre, claveBusqueda, StringComparison.OrdinalIgnoreCase),
                            out retirado);

                        if (exito && retirado != null)
                        {
                            listaRetirados.Agregar(retirado);
                            Console.WriteLine($"\nProducto retirado correctamente: {retirado}");
                        }
                        else
                        {
                            Console.WriteLine($"\nNo se encontró '{claveBusqueda}' en la lista de productos disponibles.");
                        }
                        break;

                    case 3:
                        enSubmenu = false;
                        break;

                    default:
                        Console.WriteLine("Error: Opción no válida. Elija entre 1 y 3.");
                        break;
                }
            }
        }

        private static void MostrarEstadoAlmacen(
            ListaEnlazada<ProductoEscaneado> disponibles,
            ListaEnlazada<ProductoEscaneado> retirados)
        {
            Console.WriteLine("\n---------------- ESTADO DEL ALMACÉN DE PRODUCTOS ----------------");
            Console.WriteLine($"Cantidad de productos DISPONIBLES: {disponibles.Cantidad}");
            ProductoEscaneado[] arrDisponibles = disponibles.ObtenerElementos();
            if (arrDisponibles.Length == 0)
            {
                Console.WriteLine("  (Sin productos disponibles)");
            }
            else
            {
                for (int i = 0; i < arrDisponibles.Length; i++)
                {
                    Console.WriteLine($"  - {arrDisponibles[i]}");
                }
            }

            Console.WriteLine($"\nCantidad de productos RETIRADOS  : {retirados.Cantidad}");
            ProductoEscaneado[] arrRetirados = retirados.ObtenerElementos();
            if (arrRetirados.Length == 0)
            {
                Console.WriteLine("  (Sin productos retirados)");
            }
            else
            {
                for (int i = 0; i < arrRetirados.Length; i++)
                {
                    Console.WriteLine($"  - {arrRetirados[i]}");
                }
            }
            Console.WriteLine("-----------------------------------------------------------------");
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

                int valor;
                if (!int.TryParse(entrada.Trim(), out valor) || valor <= 0)
                {
                    Console.WriteLine("Error: Introducir sólo números enteros mayores a cero.\n");
                    continue;
                }

                return valor;
            }
        }
    }
}
