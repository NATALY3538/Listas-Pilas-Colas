using System;

namespace Practica1_Listas.Estructuras
{
    /// <summary>
    /// Representa un nodo individual dentro de una Lista Enlazada genérica.
    /// </summary>
    /// <typeparam name="T">Tipo de dato almacenado en el nodo.</typeparam>
    public class NodoLista<T>
    {
        /// <summary>
        /// Valor almacenado en el nodo.
        /// </summary>
        public T Valor { get; set; }

        /// <summary>
        /// Referencia al siguiente nodo en la lista.
        /// </summary>
        public NodoLista<T>? Siguiente { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NodoLista{T}"/>.
        /// </summary>
        /// <param name="valor">Dato a almacenar.</param>
        /// <param name="siguiente">Referencia al nodo siguiente.</param>
        public NodoLista(T valor, NodoLista<T>? siguiente = null)
        {
            Valor = valor;
            Siguiente = siguiente;
        }
    }
}
