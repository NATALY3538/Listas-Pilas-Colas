using System;
using System.Text;

namespace PracticaPilas
{
    /// <summary>
    /// Representa un nodo enlazado para la estructura de datos Pila.
    /// </summary>
    /// <typeparam name="T">Tipo de dato almacenado en el nodo.</typeparam>
    public class NodoPila<T>
    {
        public T Dato { get; set; }
        public NodoPila<T>? Siguiente { get; set; }

        public NodoPila(T dato, NodoPila<T>? siguiente = null)
        {
            Dato = dato;
            Siguiente = siguiente;
        }
    }

    /// <summary>
    /// Implementación de una Pila (Stack) dinámica basada en nodos enlazados (LIFO).
    /// </summary>
    /// <typeparam name="T">Tipo de elemento administrado por la pila.</typeparam>
    public class Pila<T>
    {
        private NodoPila<T>? _tope;
        public int Conteo { get; private set; }

        public bool EstaVacia => _tope == null;

        public Pila()
        {
            _tope = null;
            Conteo = 0;
        }

        /// <summary>
        /// Inserta (apila) un elemento en la cima de la pila.
        /// </summary>
        public void Push(T elemento)
        {
            _tope = new NodoPila<T>(elemento, _tope);
            Conteo++;
        }

        /// <summary>
        /// Elimina y retorna el elemento en la cima de la pila.
        /// </summary>
        public T Pop()
        {
            if (EstaVacia)
            {
                throw new InvalidOperationException("Subdesbordamiento de pila (Underflow): La pila se encuentra vacía.");
            }

            T valor = _tope!.Dato;
            _tope = _tope.Siguiente;
            Conteo--;
            return valor;
        }

        /// <summary>
        /// Retorna el elemento en la cima de la pila sin extraerlo.
        /// </summary>
        public T Peek()
        {
            if (EstaVacia)
            {
                throw new InvalidOperationException("La pila se encuentra vacía.");
            }

            return _tope!.Dato;
        }

        /// <summary>
        /// Vacía por completo la pila.
        /// </summary>
        public void Limpiar()
        {
            _tope = null;
            Conteo = 0;
        }

        /// <summary>
        /// Muestra la representación gráfica en consola del contenido de la pila de cima a base.
        /// </summary>
        public void Mostrar(string etiqueta = "Pila")
        {
            Console.WriteLine($"\n--- [{etiqueta}] (Total elementos: {Conteo}) ---");
            if (EstaVacia)
            {
                Console.WriteLine("  (Pila vacía)");
                Console.WriteLine("  -------------\n");
                return;
            }

            NodoPila<T>? actual = _tope;
            bool esCima = true;
            while (actual != null)
            {
                string marcador = esCima ? " <-- CIMA" : "";
                Console.WriteLine($"  |  {actual.Dato, -6} |{marcador}");
                actual = actual.Siguiente;
                esCima = false;
            }
            Console.WriteLine("  +---------+ (BASE)\n");
        }

        /// <summary>
        /// Crea una copia exacta de la pila actual manteniendo el orden de sus elementos.
        /// </summary>
        public Pila<T> Clonar()
        {
            Pila<T> aux = new();
            Pila<T> clon = new();

            NodoPila<T>? actual = _tope;
            while (actual != null)
            {
                aux.Push(actual.Dato);
                actual = actual.Siguiente;
            }

            while (!aux.EstaVacia)
            {
                clon.Push(aux.Pop());
            }

            return clon;
        }
    }
}
