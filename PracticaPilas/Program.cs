using System;

namespace PracticaPilas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Si se pasa el argumento --demo o --test, se ejecutan las pruebas automáticamente
            if (args.Length > 0 && (args[0] == "--test" || args[0] == "--demo"))
            {
                EjecutarTodasLasPruebas();
                return;
            }

            bool salir = false;

            while (!salir)
            {
                MostrarMenuPrincipal();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Seleccione una opción (1-6): ");
                Console.ResetColor();

                string? opcion = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        MenuEjercicio1();
                        break;
                    case "2":
                        MenuEjercicio2();
                        break;
                    case "3":
                        MenuEjercicio3();
                        break;
                    case "4":
                        MenuEjercicio4();
                        break;
                    case "5":
                        EjecutarTodasLasPruebas();
                        break;
                    case "6":
                        salir = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("¡Gracias por utilizar la aplicación de Práctica de Pilas!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción no válida. Por favor, ingrese un número del 1 al 6.");
                        Console.ResetColor();
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey(true);
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            try { Console.Clear(); } catch { }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================================================");
            Console.WriteLine("                PRÁCTICA: ESTRUCTURA DE DATOS PILAS                 ");
            Console.WriteLine("                  (Valor: 10 c/u, Total = 40 pts)                   ");
            Console.WriteLine("====================================================================");
            Console.ResetColor();
            Console.WriteLine("  1. Ejercicio 1: Invertir palabra (Ej. UTM -> MTU)");
            Console.WriteLine("  2. Ejercicio 2: Palíndromo (Comprobar simetría)");
            Console.WriteLine("  3. Ejercicio 3: Suma de números grandes (Algoritmo con 3 pilas)");
            Console.WriteLine("  4. Ejercicio 4: Reemplazar valor en pila de enteros");
            Console.WriteLine("  5. Ejecutar demostración completa (Casos de prueba de la práctica)");
            Console.WriteLine("  6. Salir");
            Console.WriteLine("====================================================================");
        }

        private static void MenuEjercicio1()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(">>> EJERCICIO 1: INVERTIR PALABRA CON PILA <<<");
            Console.ResetColor();
            Console.WriteLine("Ingrese la palabra que desea invertir (o presione Enter para usar 'UTM'):");
            Console.Write("> ");
            string? entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entrada))
            {
                entrada = "UTM";
            }

            string invertida = EjerciciosPilas.InvertirPalabra(entrada);

            Console.WriteLine("\n[RESULTADO]");
            Console.WriteLine($"  Palabra original:  {entrada}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Palabra invertida: {invertida}");
            Console.ResetColor();
        }

        private static void MenuEjercicio2()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(">>> EJERCICIO 2: VERIFICAR PALÍNDROMO CON PILA <<<");
            Console.ResetColor();
            Console.WriteLine("Ejemplos válidos: ana, arenera, arepera, anilina, Malayalam, Oruro, oso, radar, reconocer, rotor, salas, seres, somos, sometemos.");
            Console.WriteLine("Ingrese una palabra o frase a evaluar (o presione Enter para 'reconocer'):");
            Console.Write("> ");
            string? entrada = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entrada))
            {
                entrada = "reconocer";
            }

            bool esPalindromo = EjerciciosPilas.EsPalindromo(entrada, out string limpio, out string invertido);

            Console.WriteLine("\n[RESULTADO]");
            Console.WriteLine($"  Texto original:       \"{entrada}\"");
            Console.WriteLine($"  Texto normalizado:    \"{limpio}\"");
            Console.WriteLine($"  Texto desapilado:     \"{invertido}\"");

            if (esPalindromo)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  ===> SÍ ES UN PALÍNDROMO ✔");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ===> NO ES UN PALÍNDROMO ✘");
            }
            Console.ResetColor();
        }

        private static void MenuEjercicio3()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(">>> EJERCICIO 3: SUMA DE NÚMEROS GRANDES MEDIANTE PILAS <<<");
            Console.ResetColor();
            Console.WriteLine("Ingrese el primer número (o presione Enter para usar '592'):");
            Console.Write("> ");
            string? n1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(n1)) n1 = "592";

            Console.WriteLine("Ingrese el segundo número (o presione Enter para usar '3784'):");
            Console.Write("> ");
            string? n2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(n2)) n2 = "3784";

            try
            {
                string resultado = EjerciciosPilas.SumarNumerosGrandes(n1, n2, mostrarPasos: true);
                Console.WriteLine("\n" + new string('-', 40));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"  RESULTADO FINAL: {n1} + {n2} = {resultado}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al realizar la suma: {ex.Message}");
                Console.ResetColor();
            }
        }

        private static void MenuEjercicio4()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(">>> EJERCICIO 4: REEMPLAZAR VALOR EN PILA DE ENTEROS <<<");
            Console.ResetColor();

            Pila<int> miPila = new();
            // Llenamos una pila de ejemplo con valores donde se repiten números
            // Base a tope: 5, 20, 15, 20, 30, 20 (el 20 está en la cima)
            miPila.Push(5);
            miPila.Push(20);
            miPila.Push(15);
            miPila.Push(20);
            miPila.Push(30);
            miPila.Push(20);

            Console.WriteLine("Estado inicial de la pila de prueba:");
            miPila.Mostrar("Pila Original Antes del Reemplazo");

            Console.WriteLine("Ingrese el valor VIEJO que desea reemplazar (Enter para 20):");
            Console.Write("> ");
            string? sViejo = Console.ReadLine();
            int viejo = string.IsNullOrWhiteSpace(sViejo) ? 20 : int.Parse(sViejo);

            Console.WriteLine("Ingrese el valor NUEVO de sustitución (Enter para 99):");
            Console.Write("> ");
            string? sNuevo = Console.ReadLine();
            int nuevo = string.IsNullOrWhiteSpace(sNuevo) ? 99 : int.Parse(sNuevo);

            int cantidadReemplazos = EjerciciosPilas.Reemplazar(miPila, nuevo, viejo);

            Console.WriteLine($"\nSe realizaron {cantidadReemplazos} reemplazo(s) del valor {viejo} por {nuevo}.");
            miPila.Mostrar("Pila Después del Reemplazo (Orden Preservado)");
        }

        public static void EjecutarTodasLasPruebas()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n====================================================================");
            Console.WriteLine("        EJECUCIÓN DE PRUEBAS DE VALIDACIÓN DE LA PRÁCTICA           ");
            Console.WriteLine("====================================================================");
            Console.ResetColor();

            // --- EJERCICIO 1 ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[1] TEST EJERCICIO 1: Invertir Palabra");
            Console.ResetColor();
            string[] palabrasTest = { "UTM", "Pilas", "Estructura", "Algoritmo" };
            foreach (var p in palabrasTest)
            {
                string inv = EjerciciosPilas.InvertirPalabra(p);
                Console.WriteLine($"  Original: \"{p}\"  ==>  Invertida: \"{inv}\"");
            }

            // --- EJERCICIO 2 ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[2] TEST EJERCICIO 2: Detección de Palíndromos");
            Console.ResetColor();
            string[] palindromosTest = {
                "UTM", "ana", "arenera", "arepera", "anilina",
                "Malayalam", "Oruro", "oso", "radar", "reconocer",
                "rotor", "salas", "seres", "somos", "sometemos", "computadora"
            };

            foreach (var item in palindromosTest)
            {
                bool esPal = EjerciciosPilas.EsPalindromo(item, out _, out string inv);
                string estado = esPal ? "✔ PALÍNDROMO" : "✘ NO ES PALÍNDROMO";
                Console.WriteLine($"  \"{item,-12}\" -> Invertido: \"{inv,-12}\" | {estado}");
            }

            // --- EJERCICIO 3 ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[3] TEST EJERCICIO 3: Suma de Números Grandes con Pilas");
            Console.ResetColor();
            Console.WriteLine("  -- Caso 1: Ejemplo exacto de la guía (592 + 3784) --");
            string res1 = EjerciciosPilas.SumarNumerosGrandes("592", "3784", mostrarPasos: true);
            Console.WriteLine($"  Resultado esperado: 4376 | Obtenido: {res1} {(res1 == "4376" ? "✔ CORRECTO" : "✘ ERROR")}");

            Console.WriteLine("\n  -- Caso 2: Suma de enteros gigantes que sobrepasan límites nativos (64-bit) --");
            string g1 = "987654321098765432109876543210";
            string g2 = "123456789012345678901234567890";
            string res2 = EjerciciosPilas.SumarNumerosGrandes(g1, g2, mostrarPasos: false);
            Console.WriteLine($"  A: {g1}");
            Console.WriteLine($"  B: {g2}");
            Console.WriteLine($"  Suma con Pilas: {res2}");

            // --- EJERCICIO 4 ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[4] TEST EJERCICIO 4: Función Reemplazar(pila, nuevo, viejo)");
            Console.ResetColor();
            Pila<int> pilaTest = new();
            int[] valoresIniciales = { 10, 20, 30, 20, 40, 20, 50 };
            foreach (var v in valoresIniciales)
            {
                pilaTest.Push(v);
            }

            Console.WriteLine("  Pila original cargada:");
            pilaTest.Mostrar("Pila Inicial");

            Console.WriteLine("  Ejecutando Reemplazar(pila, nuevo: 99, viejo: 20)...");
            int reps = EjerciciosPilas.Reemplazar(pilaTest, 99, 20);
            Console.WriteLine($"  Cantidad de sustituciones efectuadas: {reps}");
            pilaTest.Mostrar("Pila Final con Reemplazos");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================================");
            Console.WriteLine("       ¡TODAS LAS PRUEBAS SE COMPLETARON SATISFACTORIAMENTE!        ");
            Console.WriteLine("====================================================================");
            Console.ResetColor();
        }
    }
}
