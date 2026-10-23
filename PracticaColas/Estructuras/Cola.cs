using System.Collections;

namespace PracticaColas;

/// <summary>
/// Cola dinámica genérica implementada con nodos simplemente ligados.
/// Se usa en el juego de pintar coches.
/// </summary>
public class Cola<T> : IEnumerable<T>
{
    private sealed class Nodo
    {
        public T Dato { get; }
        public Nodo? Siguiente { get; set; }

        public Nodo(T dato) => Dato = dato;
    }

    private Nodo? frente;
    private Nodo? final;

    public int Cantidad { get; private set; }

    public bool EstaVacia() => frente is null;

    /// <summary>Agrega un elemento al final de la cola.</summary>
    public void Encolar(T dato)
    {
        var nuevo = new Nodo(dato);
        if (final is null)
            frente = nuevo;
        else
            final.Siguiente = nuevo;
        final = nuevo;
        Cantidad++;
    }

    /// <summary>Quita y devuelve el elemento del frente.</summary>
    public T Desencolar()
    {
        if (frente is null)
            throw new InvalidOperationException("La cola está vacía.");

        T dato = frente.Dato;
        frente = frente.Siguiente;
        if (frente is null)
            final = null;
        Cantidad--;
        return dato;
    }

    /// <summary>Consulta el elemento del frente sin quitarlo.</summary>
    public T Primero() =>
        frente is null ? throw new InvalidOperationException("La cola está vacía.") : frente.Dato;

    public void Vaciar()
    {
        frente = null;
        final = null;
        Cantidad = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (Nodo? actual = frente; actual is not null; actual = actual.Siguiente)
            yield return actual.Dato;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
