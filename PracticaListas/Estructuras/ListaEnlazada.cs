using System;
using System.Text;

namespace Practica1_Listas.Estructuras
{
    /// <summary>
    /// Implementación propia de la estructura de datos Lista Simple Enlazada genérica
    /// con métodos de inserción, búsqueda, eliminación, recorrido y ordenamiento.
    /// </summary>
    /// <typeparam name="T">Tipo de elementos almacenados en la lista.</typeparam>
    public class ListaEnlazada<T>
    {
        private NodoLista<T>? _cabeza;
        private NodoLista<T>? _cola;
        private int _cantidad;

        /// <summary>
        /// Obtiene la cantidad actual de elementos en la lista.
        /// </summary>
        public int Cantidad => _cantidad;

        /// <summary>
        /// Inicializa una lista vacía.
        /// </summary>
        public ListaEnlazada()
        {
            _cabeza = null;
            _cola = null;
            _cantidad = 0;
        }

        /// <summary>
        /// Indica si la lista se encuentra vacía.
        /// </summary>
        /// <returns><c>true</c> si no contiene elementos; en caso contrario, <c>false</c>.</returns>
        public bool EstaVacia()
        {
            return _cabeza == null;
        }

        /// <summary>
        /// Inserta un nuevo elemento al final de la lista.
        /// </summary>
        /// <param name="elemento">Elemento a agregar.</param>
        public void Agregar(T elemento)
        {
            NodoLista<T> nuevoNodo = new NodoLista<T>(elemento);

            if (_cabeza == null)
            {
                _cabeza = nuevoNodo;
                _cola = nuevoNodo;
            }
            else
            {
                _cola!.Siguiente = nuevoNodo;
                _cola = nuevoNodo;
            }

            _cantidad++;
        }

        /// <summary>
        /// Busca el primer elemento que cumpla con la condición especificada.
        /// </summary>
        /// <param name="predicado">Condición de búsqueda.</param>
        /// <param name="elementoEncontrado">Elemento hallado si existe.</param>
        /// <returns><c>true</c> si se encontró el elemento; <c>false</c> en caso contrario.</returns>
        public bool IntentarBuscar(Predicate<T> predicado, out T? elementoEncontrado)
        {
            NodoLista<T>? actual = _cabeza;
            while (actual != null)
            {
                if (predicado(actual.Valor))
                {
                    elementoEncontrado = actual.Valor;
                    return true;
                }
                actual = actual.Siguiente;
            }

            elementoEncontrado = default;
            return false;
        }

        /// <summary>
        /// Extrae y elimina de la lista el primer elemento que cumpla con el predicado indicado.
        /// </summary>
        /// <param name="predicado">Condición para identificar el elemento a retirar.</param>
        /// <param name="elementoEliminado">Devuelve el elemento retirado de la lista.</param>
        /// <returns><c>true</c> si se encontró y eliminó; <c>false</c> si no existía.</returns>
        public bool ExtraerPrimero(Predicate<T> predicado, out T? elementoEliminado)
        {
            NodoLista<T>? actual = _cabeza;
            NodoLista<T>? anterior = null;

            while (actual != null)
            {
                if (predicado(actual.Valor))
                {
                    elementoEliminado = actual.Valor;

                    if (anterior == null)
                    {
                        _cabeza = actual.Siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }

                    if (actual == _cola)
                    {
                        _cola = anterior;
                    }

                    _cantidad--;
                    return true;
                }

                anterior = actual;
                actual = actual.Siguiente;
            }

            elementoEliminado = default;
            return false;
        }

        /// <summary>
        /// Extrae de esta lista todos los elementos que cumplan la condición y los transfiere a otra lista destino.
        /// </summary>
        /// <param name="predicado">Condición que determina qué elementos se extraen.</param>
        /// <param name="listaDestino">Lista donde se almacenarán los elementos extraídos.</param>
        /// <returns>Cantidad de elementos transferidos.</returns>
        public int ExtraerHaciaOtraLista(Predicate<T> predicado, ListaEnlazada<T> listaDestino)
        {
            int extraidos = 0;
            NodoLista<T>? actual = _cabeza;
            NodoLista<T>? anterior = null;

            while (actual != null)
            {
                NodoLista<T>? siguiente = actual.Siguiente;

                if (predicado(actual.Valor))
                {
                    listaDestino.Agregar(actual.Valor);

                    if (anterior == null)
                    {
                        _cabeza = siguiente;
                    }
                    else
                    {
                        anterior.Siguiente = siguiente;
                    }

                    if (actual == _cola)
                    {
                        _cola = anterior;
                    }

                    _cantidad--;
                    extraidos++;
                }
                else
                {
                    anterior = actual;
                }

                actual = siguiente;
            }

            return extraidos;
        }

        /// <summary>
        /// Ordena los elementos de la lista utilizando el comparador proporcionado (algoritmo burbuja sobre nodos).
        /// </summary>
        /// <param name="comparador">Función que compara dos elementos de tipo <typeparamref name="T"/>.</param>
        public void Ordenar(Comparison<T> comparador)
        {
            if (_cabeza == null || _cabeza.Siguiente == null)
            {
                return;
            }

            bool huboIntercambio;
            do
            {
                huboIntercambio = false;
                NodoLista<T>? actual = _cabeza;

                while (actual != null && actual.Siguiente != null)
                {
                    if (comparador(actual.Valor, actual.Siguiente.Valor) > 0)
                    {
                        T temporal = actual.Valor;
                        actual.Valor = actual.Siguiente.Valor;
                        actual.Siguiente.Valor = temporal;
                        huboIntercambio = true;
                    }
                    actual = actual.Siguiente;
                }
            } while (huboIntercambio);
        }

        /// <summary>
        /// Devuelve un arreglo con todos los elementos de la lista en su orden actual.
        /// </summary>
        /// <returns>Arreglo de elementos de tipo <typeparamref name="T"/>.</returns>
        public T[] ObtenerElementos()
        {
            T[] arreglo = new T[_cantidad];
            NodoLista<T>? actual = _cabeza;
            int indice = 0;

            while (actual != null)
            {
                arreglo[indice++] = actual.Valor;
                actual = actual.Siguiente;
            }

            return arreglo;
        }

        /// <summary>
        /// Formatea los elementos de la lista separados por coma.
        /// </summary>
        /// <returns>Cadena con los elementos separados por coma.</returns>
        public string FormatearElementos()
        {
            if (_cabeza == null)
            {
                return "(Lista vacía)";
            }

            StringBuilder constructor = new StringBuilder();
            NodoLista<T>? actual = _cabeza;

            while (actual != null)
            {
                constructor.Append(actual.Valor);
                if (actual.Siguiente != null)
                {
                    constructor.Append(", ");
                }
                actual = actual.Siguiente;
            }

            return constructor.ToString();
        }
    }
}
