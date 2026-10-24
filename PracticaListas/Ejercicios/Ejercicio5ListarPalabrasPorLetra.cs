using System;
using Practica1_Listas.Estructuras;
using Practica1_Listas.Modelos;

namespace Practica1_Listas.Ejercicios
{
    /// <summary>
    /// Ejercicio 5. Listar palabras por letra:
    /// Almacena palabras solicitadas al usuario en Lista1 y las separa en listas clasificadas
    /// por la primera letra de la palabra (Lista2, Lista3, Lista4, ...).
    /// Si el usuario agrega más palabras con letras diferentes, crea nuevas listas dinámicamente.
    /// </summary>
    public static class Ejercicio5ListarPalabrasPorLetra
    {
        /// <summary>
        /// Agrega una palabra a la lista general (<paramref name="lista1"/>) y la clasifica en la lista
        /// correspondiente a su letra inicial dentro de <paramref name="listasPorLetra"/>, creando una nueva
        /// lista si aún no existe una para esa letra inicial.
        /// </summary>
        /// <param name="palabra">Palabra a registrar.</param>
        /// <param name="lista1">Lista general de todas las palabras ingresadas.</param>
        /// <param name="listasPorLetra">Lista de grupos clasificados por letra inicial.</param>
        public static void RegistrarPalabra(
            string palabra,
            ListaEnlazada<string> lista1,
            ListaEnlazada<GrupoLetra> listasPorLetra)
        {
            string limpia = palabra.Trim();
            lista1.Agregar(limpia);

            char inicial = char.ToUpperInvariant(limpia[0]);
            GrupoLetra? grupoExistente;

            if (listasPorLetra.IntentarBuscar(g => g.LetraInicial == inicial, out grupoExistente) && grupoExistente != null)
            {
                grupoExistente.Palabras.Agregar(limpia);
            }
            else
            {
                GrupoLetra nuevoGrupo = new GrupoLetra(inicial);
                nuevoGrupo.Palabras.Agregar(limpia);
                listasPorLetra.Agregar(nuevoGrupo);
            }
        }

        /// <summary>
        /// Ejecuta el flujo interactivo en consola para el Ejercicio 5 (Listar palabras por letra).
        /// </summary>
        public static void Ejecutar()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("  EJERCICIO 5: LISTAR Y CLASIFICAR PALABRAS POR LETRA INICIAL");
            Console.WriteLine("======================================================================");
            Console.WriteLine("Descripción: Almacena palabras en Lista1 y las divide en listas por su");
            Console.WriteLine("primera letra (Lista2, Lista3, ...), creando nuevas listas si se agregan");
            Console.WriteLine("palabras con letras iniciales diferentes.\n");

            ListaEnlazada<string> lista1General = new ListaEnlazada<string>();
            ListaEnlazada<GrupoLetra> listasClasificadas = new ListaEnlazada<GrupoLetra>();

            int cantidadInicial = SolicitarEnteroPositivo("¿Cuántas palabras desea ingresar inicialmente?: ");
            for (int i = 1; i <= cantidadInicial; i++)
            {
                string palabra = SolicitarPalabraValida($"  Ingrese la palabra #{i}: ");
                RegistrarPalabra(palabra, lista1General, listasClasificadas);
            }

            bool enSubmenu = true;
            while (enSubmenu)
            {
                MostrarListasClasificadas(lista1General, listasClasificadas);

                Console.WriteLine("\nOpciones de Palabras (Ejercicio 5):");
                Console.WriteLine("  1. Agregar otra palabra (crea nueva lista si la letra inicial no existe)");
                Console.WriteLine("  2. Volver al menú principal");
                Console.Write("Seleccione una opción (1-2): ");

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
                        string nuevaPalabra = SolicitarPalabraValida("  Ingrese la nueva palabra: ");
                        RegistrarPalabra(nuevaPalabra, lista1General, listasClasificadas);
                        break;

                    case 2:
                        enSubmenu = false;
                        break;

                    default:
                        Console.WriteLine("Error: Opción fuera de rango (1-2).");
                        break;
                }
            }
        }

        public static void MostrarListasClasificadas(
            ListaEnlazada<string> lista1General,
            ListaEnlazada<GrupoLetra> listasClasificadas)
        {
            Console.WriteLine("\n---------------- CLASIFICACIÓN DE PALABRAS POR LETRA ----------------");
            Console.WriteLine($"Lista1: {lista1General.FormatearElementos()}");

            GrupoLetra[] grupos = listasClasificadas.ObtenerElementos();
            for (int i = 0; i < grupos.Length; i++)
            {
                int numeroLista = i + 2;
                Console.WriteLine($"Lista{numeroLista} (Letra '{grupos[i].LetraInicial}'): {grupos[i].Palabras.FormatearElementos()}");
            }
            Console.WriteLine("---------------------------------------------------------------------");
        }

        private static string SolicitarPalabraValida(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("  Error: Hay datos faltantes. Ingrese una palabra.");
                    continue;
                }

                string limpia = entrada.Trim();
                if (!char.IsLetter(limpia[0]))
                {
                    Console.WriteLine("  Error: La palabra debe comenzar con una letra.");
                    continue;
                }

                return limpia;
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
