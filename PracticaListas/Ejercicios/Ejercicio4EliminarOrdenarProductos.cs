using System;
using System.Globalization;
using Practica1_Listas.Estructuras;
using Practica1_Listas.Modelos;

namespace Practica1_Listas.Ejercicios
{
    /// <summary>
    /// Ejercicio 4. Eliminar y ordenar productos:
    /// Permite agregar productos con precio a una lista, eliminar productos de acuerdo a una clave
    /// solicitada al usuario, mostrar los elementos ordenados por nombre y mostrar el costo total de compra.
    /// </summary>
    public static class Ejercicio4EliminarOrdenarProductos
    {
        /// <summary>
        /// Ordena la lista de productos alfabéticamente por su nombre.
        /// </summary>
        /// <param name="listaProductos">Lista de productos a ordenar.</param>
        public static void OrdenarPorNombre(ListaEnlazada<ProductoCompra> listaProductos)
        {
            listaProductos.Ordenar((a, b) => string.Compare(a.Nombre, b.Nombre, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Calcula el costo total de compra sumando el precio de todos los productos en la lista.
        /// </summary>
        /// <param name="listaProductos">Lista de productos.</param>
        /// <returns>Suma total de precios.</returns>
        public static decimal CalcularCostoTotal(ListaEnlazada<ProductoCompra> listaProductos)
        {
            decimal total = 0m;
            ProductoCompra[] productos = listaProductos.ObtenerElementos();

            for (int i = 0; i < productos.Length; i++)
            {
                total += productos[i].Precio;
            }

            return total;
        }

        /// <summary>
        /// Ejecuta el flujo interactivo en consola para el Ejercicio 4 (Eliminar y ordenar productos).
        /// </summary>
        public static void Ejecutar()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("  EJERCICIO 4: ELIMINAR Y ORDENAR PRODUCTOS DE COMPRA");
            Console.WriteLine("======================================================================");
            Console.WriteLine("Descripción: Agrega productos con clave, nombre y precio a una lista,");
            Console.WriteLine("permite eliminar por clave, ordena por nombre y calcula el costo total.\n");

            ListaEnlazada<ProductoCompra> listaProductos = new ListaEnlazada<ProductoCompra>();

            int cantidadInicial = SolicitarEnteroPositivo("¿Cuántos productos desea agregar inicialmente a la lista?: ");
            for (int i = 1; i <= cantidadInicial; i++)
            {
                Console.WriteLine($"\n--- Producto #{i} ---");
                AgregarProductoInteractivo(listaProductos);
            }

            bool enSubmenu = true;
            while (enSubmenu)
            {
                OrdenarPorNombre(listaProductos);
                MostrarListaOrdenadaYTotal(listaProductos);

                Console.WriteLine("\nOpciones de Compra (Ejercicio 4):");
                Console.WriteLine("  1. Agregar otro producto a la lista");
                Console.WriteLine("  2. Eliminar un producto por su clave");
                Console.WriteLine("  3. Volver al menú principal");
                Console.Write("Seleccione una opción (1-3): ");

                string? entradaOpcion = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(entradaOpcion))
                {
                    Console.WriteLine("Error: Hay datos faltantes.");
                    continue;
                }

                int opcion;
                if (!int.TryParse(entradaOpcion.Trim(), out opcion))
                {
                    Console.WriteLine("Error: Introducir sólo números.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n--- Nuevo Producto ---");
                        AgregarProductoInteractivo(listaProductos);
                        break;

                    case 2:
                        if (listaProductos.EstaVacia())
                        {
                            Console.WriteLine("\nAviso: La lista de productos está vacía.");
                            break;
                        }

                        string claveEliminar = SolicitarTextoNoVacio("Ingrese la clave del producto que desea eliminar: ");
                        ProductoCompra? eliminado;
                        bool fueEliminado = listaProductos.ExtraerPrimero(
                            p => string.Equals(p.Clave, claveEliminar, StringComparison.OrdinalIgnoreCase),
                            out eliminado);

                        if (fueEliminado && eliminado != null)
                        {
                            Console.WriteLine($"\nProducto eliminado correctamente: {eliminado}");
                        }
                        else
                        {
                            Console.WriteLine($"\nNo se encontró ningún producto con la clave '{claveEliminar}'.");
                        }
                        break;

                    case 3:
                        enSubmenu = false;
                        break;

                    default:
                        Console.WriteLine("Error: Opción fuera de rango (1-3).");
                        break;
                }
            }
        }

        private static void AgregarProductoInteractivo(ListaEnlazada<ProductoCompra> listaProductos)
        {
            while (true)
            {
                string clave = SolicitarTextoNoVacio("  Clave del producto : ");
                ProductoCompra? existente;
                if (listaProductos.IntentarBuscar(
                    p => string.Equals(p.Clave, clave, StringComparison.OrdinalIgnoreCase),
                    out existente))
                {
                    Console.WriteLine($"  Error: Ya existe un producto con la clave '{clave}'. Use una clave distinta.");
                    continue;
                }

                string nombre = SolicitarTextoNoVacio("  Nombre del producto: ");
                decimal precio = SolicitarPrecioDecimal("  Precio del producto: $");

                listaProductos.Agregar(new ProductoCompra(clave, nombre, precio));
                break;
            }
        }

        private static void MostrarListaOrdenadaYTotal(ListaEnlazada<ProductoCompra> listaProductos)
        {
            Console.WriteLine("\n-------- PRODUCTOS ORDENADOS POR NOMBRE Y COSTO TOTAL --------");
            ProductoCompra[] productos = listaProductos.ObtenerElementos();

            if (productos.Length == 0)
            {
                Console.WriteLine("  (No hay productos en la lista)");
            }
            else
            {
                for (int i = 0; i < productos.Length; i++)
                {
                    Console.WriteLine($"  {i + 1}. {productos[i]}");
                }
            }

            decimal costoTotal = CalcularCostoTotal(listaProductos);
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine($"  COSTO TOTAL DE COMPRA: ${costoTotal:F2}");
            Console.WriteLine("--------------------------------------------------------------");
        }

        private static string SolicitarTextoNoVacio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  Error: Hay datos faltantes.");
                    continue;
                }

                return entrada.Trim();
            }
        }

        private static decimal SolicitarPrecioDecimal(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  Error: Hay datos faltantes. Ingrese el precio.");
                    continue;
                }

                string normalizado = entrada.Trim().Replace(',', '.');
                decimal precio;
                if (!decimal.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out precio) || precio <= 0m)
                {
                    Console.WriteLine("  Error: Introducir sólo números decimales mayores que cero.");
                    continue;
                }

                return Math.Round(precio, 2);
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
                    Console.WriteLine("Error: Introducir sólo números enteros mayores que cero.\n");
                    continue;
                }

                return cantidad;
            }
        }
    }
}
