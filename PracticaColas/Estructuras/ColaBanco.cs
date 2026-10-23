namespace PracticaColas;

/// <summary>
/// Cola circular estática (arreglo de tamaño fijo) para la ventanilla del banco.
/// Frente apunta al primer cliente y Final al último; ambos valen -1 cuando la cola está vacía.
/// </summary>
public class ColaBanco
{
    private readonly Cliente?[] elementos;

    public int Frente { get; private set; } = -1;
    public int Final { get; private set; } = -1;
    public int Cantidad { get; private set; }
    public int Capacidad => elementos.Length;

    public ColaBanco(int capacidad)
    {
        if (capacidad <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacidad), "La capacidad debe ser mayor que cero.");
        elementos = new Cliente?[capacidad];
    }

    /// <summary>Devuelve true si no hay clientes formados.</summary>
    public bool ColaVacia() => Cantidad == 0;

    /// <summary>Devuelve true si ya no cabe otro cliente (sobreflujo).</summary>
    public bool ColaLlena() => Cantidad == Capacidad;

    /// <summary>Forma al cliente al final de la cola.</summary>
    public void InsertaCola(Cliente cliente)
    {
        if (ColaLlena())
            throw new InvalidOperationException("Sobreflujo: la cola está llena.");

        if (ColaVacia())
            Frente = 0;
        Final = (Final + 1) % Capacidad;
        elementos[Final] = cliente;
        Cantidad++;
    }

    /// <summary>Saca y devuelve al primer cliente de la cola.</summary>
    public Cliente EliminaCola()
    {
        if (ColaVacia())
            throw new InvalidOperationException("Subflujo: la cola está vacía.");

        Cliente cliente = elementos[Frente]!;
        elementos[Frente] = null;
        Cantidad--;

        if (Cantidad == 0)
        {
            Frente = -1;
            Final = -1;
        }
        else
        {
            Frente = (Frente + 1) % Capacidad;
        }
        return cliente;
    }

    public Cliente VerFrente() =>
        ColaVacia() ? throw new InvalidOperationException("La cola está vacía.") : elementos[Frente]!;

    public Cliente VerFinal() =>
        ColaVacia() ? throw new InvalidOperationException("La cola está vacía.") : elementos[Final]!;

    /// <summary>Recorre la cola del frente al final sin modificarla.</summary>
    public IEnumerable<Cliente> Recorrer()
    {
        for (int i = 0; i < Cantidad; i++)
            yield return elementos[(Frente + i) % Capacidad]!;
    }
}
