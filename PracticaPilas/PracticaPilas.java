import java.util.Scanner;

public class PracticaPilas {

    // --- Estructura Nodo ---
    public static class Nodo<T> {
        T dato;
        Nodo<T> siguiente;

        public Nodo(T dato, Nodo<T> siguiente) {
            this.dato = dato;
            this.siguiente = siguiente;
        }
    }

    // --- Estructura Pila Genérica ---
    public static class Pila<T> {
        private Nodo<T> tope;
        private int conteo;

        public Pila() {
            this.tope = null;
            this.conteo = 0;
        }

        public boolean estaVacia() {
            return tope == null;
        }

        public int getConteo() {
            return conteo;
        }

        public void push(T elemento) {
            tope = new Nodo<>(elemento, tope);
            conteo++;
        }

        public T pop() {
            if (estaVacia()) {
                throw new IllegalStateException("Subdesbordamiento de pila (Underflow): La pila está vacía.");
            }
            T valor = tope.dato;
            tope = tope.siguiente;
            conteo--;
            return valor;
        }

        public T peek() {
            if (estaVacia()) {
                throw new IllegalStateException("La pila está vacía.");
            }
            return tope.dato;
        }

        public void mostrar(String etiqueta) {
            System.out.println("\n--- [" + etiqueta + "] (Total: " + conteo + ") ---");
            if (estaVacia()) {
                System.out.println("  (Pila vacía)\n");
                return;
            }
            Nodo<T> actual = tope;
            boolean esCima = true;
            while (actual != null) {
                String marca = esCima ? " <-- CIMA" : "";
                System.out.printf("  | %-6s |%s\n", actual.dato, marca);
                actual = actual.siguiente;
                esCima = false;
            }
            System.out.println("  +--------+ (BASE)\n");
        }
    }

    // =========================================================================
    // EJERCICIO 1: Invertir palabra
    // =========================================================================
    public static String invertirPalabra(String palabra) {
        if (palabra == null || palabra.isEmpty()) return "";
        Pila<Character> pila = new Pila<>();
        for (int i = 0; i < palabra.length(); i++) {
            pila.push(palabra.charAt(i));
        }
        StringBuilder sb = new StringBuilder();
        while (!pila.estaVacia()) {
            sb.append(pila.pop());
        }
        return sb.toString();
    }

    // =========================================================================
    // EJERCICIO 2: Palíndromo
    // =========================================================================
    public static boolean esPalindromo(String texto) {
        if (texto == null || texto.trim().isEmpty()) return false;
        StringBuilder limpio = new StringBuilder();
        for (char c : texto.toCharArray()) {
            if (Character.isLetterOrDigit(c)) {
                limpio.append(Character.toLowerCase(c));
            }
        }
        String textoLimpio = limpio.toString();

        Pila<Character> pila = new Pila<>();
        for (int i = 0; i < textoLimpio.length(); i++) {
            pila.push(textoLimpio.charAt(i));
        }

        StringBuilder invertido = new StringBuilder();
        while (!pila.estaVacia()) {
            invertido.append(pila.pop());
        }

        return textoLimpio.equals(invertido.toString());
    }

    // =========================================================================
    // EJERCICIO 3: Suma de números grandes mediante pilas
    // =========================================================================
    public static String sumarNumerosGrandes(String num1, String num2, boolean mostrarPasos) {
        num1 = (num1 == null) ? "0" : num1.trim();
        num2 = (num2 == null) ? "0" : num2.trim();

        Pila<Integer> operandStack1 = new Pila<>();
        Pila<Integer> operandStack2 = new Pila<>();
        Pila<Integer> resulStack = new Pila<>();

        for (char c : num1.toCharArray()) {
            if (Character.isDigit(c)) operandStack1.push(c - '0');
            else throw new IllegalArgumentException("Carácter no numérico en: " + num1);
        }

        for (char c : num2.toCharArray()) {
            if (Character.isDigit(c)) operandStack2.push(c - '0');
            else throw new IllegalArgumentException("Carácter no numérico en: " + num2);
        }

        if (mostrarPasos) {
            System.out.println("\n[Suma paso a paso con Pilas]");
            System.out.println("  operand-stack1 (Tope = " + (operandStack1.estaVacia() ? 0 : operandStack1.peek()) + ")");
            System.out.println("  operand-stack2 (Tope = " + (operandStack2.estaVacia() ? 0 : operandStack2.peek()) + ")");
        }

        int acarreo = 0;
        int paso = 1;
        while (!operandStack1.estaVacia() || !operandStack2.estaVacia() || acarreo > 0) {
            int d1 = operandStack1.estaVacia() ? 0 : operandStack1.pop();
            int d2 = operandStack2.estaVacia() ? 0 : operandStack2.pop();

            int suma = d1 + d2 + acarreo;
            int digito = suma % 10;
            int nuevoAcarreo = suma / 10;

            if (mostrarPasos) {
                System.out.printf("  Paso %d: %d + %d + (acarreo %d) = %d -> Se apila: %d, Nuevo acarreo: %d\n",
                        paso, d1, d2, acarreo, suma, digito, nuevoAcarreo);
            }

            resulStack.push(digito);
            acarreo = nuevoAcarreo;
            paso++;
        }

        StringBuilder resultado = new StringBuilder();
        while (!resulStack.estaVacia()) {
            resultado.append(resulStack.pop());
        }

        return resultado.toString();
    }

    // =========================================================================
    // EJERCICIO 4: Función Reemplazar
    // =========================================================================
    public static int reemplazar(Pila<Integer> pila, int nuevo, int viejo) {
        if (pila == null) throw new IllegalArgumentException("Pila no puede ser nula");
        Pila<Integer> aux = new Pila<>();
        int reemplazos = 0;

        // Desapilar y sustituir hacia aux
        while (!pila.estaVacia()) {
            int val = pila.pop();
            if (val == viejo) {
                aux.push(nuevo);
                reemplazos++;
            } else {
                aux.push(val);
            }
        }

        // Restaurar orden original LIFO
        while (!aux.estaVacia()) {
            pila.push(aux.pop());
        }

        return reemplazos;
    }

    // =========================================================================
    // MÉTODO PRINCIPAL
    // =========================================================================
    public static void main(String[] args) {
        System.out.println("====================================================================");
        System.out.println("             PRÁCTICA: OPERACIONES CON PILAS (JAVA)                 ");
        System.out.println("====================================================================");

        // Ejercicio 1
        System.out.println("\n[1] Ejercicio 1: Invertir palabra (Ejemplo UTM)");
        String palabra = "UTM";
        System.out.println("  Original:  " + palabra);
        System.out.println("  Invertida: " + invertirPalabra(palabra));

        // Ejercicio 2
        System.out.println("\n[2] Ejercicio 2: Palíndromos");
        String[] pruebas = {"UTM", "ana", "arenera", "anilina", "Malayalam", "radar", "reconocer", "sometemos"};
        for (String p : pruebas) {
            System.out.printf("  %-12s -> %s\n", p, esPalindromo(p) ? "✔ ES PALÍNDROMO" : "✘ NO ES PALÍNDROMO");
        }

        // Ejercicio 3
        System.out.println("\n[3] Ejercicio 3: Suma de Números Grandes (592 + 3784)");
        String suma = sumarNumerosGrandes("592", "3784", true);
        System.out.println("  Resultado final de 592 + 3784 = " + suma);

        // Ejercicio 4
        System.out.println("\n[4] Ejercicio 4: Reemplazar valor en Pila");
        Pila<Integer> p = new Pila<>();
        int[] vals = {10, 20, 30, 20, 40, 20, 50};
        for (int v : vals) p.push(v);
        p.mostrar("Pila Original");
        int count = reemplazar(p, 99, 20);
        System.out.println("  Reemplazos realizados (20 -> 99): " + count);
        p.mostrar("Pila Después de Reemplazar");
    }
}
