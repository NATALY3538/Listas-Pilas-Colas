namespace PracticaColas;

/// <summary>
/// Cola circular doblemente ligada de autos (el estacionamiento tipo "callejón").
/// Los autos entran por el final y salen por el frente; el último nodo apunta al primero
/// y el primero al último, por lo que solo se guarda la referencia al frente.
/// </summary>
public class ColaCircularDobleAutos
{
    private Auto? frente;

    public int Cantidad { get; private set; }
    public Auto? Frente => frente;
    public Auto? Final => frente?.Anterior;

    public bool EstaVacia() => frente is null;

    /// <summary>Entrada de un auto: se enlaza al final de la cola.</summary>
    public void Insertar(Auto auto)
    {
        if (frente is null)
        {
            auto.Siguiente = auto;
            auto.Anterior = auto;
            frente = auto;
        }
        else
        {
            Auto final = frente.Anterior!;
            final.Siguiente = auto;
            auto.Anterior = final;
            auto.Siguiente = frente;
            frente.Anterior = auto;
        }
        Cantidad++;
    }

    /// <summary>Salida de un auto: se desenlaza el nodo del frente.</summary>
    public Auto Eliminar()
    {
        if (frente is null)
            throw new InvalidOperationException("El estacionamiento está vacío.");

        Auto saliente = frente;
        if (saliente.Siguiente == saliente)
        {
            frente = null;
        }
        else
        {
            Auto final = saliente.Anterior!;
            frente = saliente.Siguiente!;
            final.Siguiente = frente;
            frente.Anterior = final;
        }

        saliente.Siguiente = null;
        saliente.Anterior = null;
        Cantidad--;
        return saliente;
    }

    public bool ExistePlaca(string placas) =>
        Recorrer().Any(a => a.Placas.Equals(placas, StringComparison.OrdinalIgnoreCase));

    /// <summary>Recorre del frente (puerta de salida) al final (puerta de entrada).</summary>
    public IEnumerable<Auto> Recorrer()
    {
        if (frente is null)
            yield break;

        Auto actual = frente;
        do
        {
            yield return actual;
            actual = actual.Siguiente!;
        } while (actual != frente);
    }

    /// <summary>Recorre del final al frente usando los enlaces Anterior.</summary>
    public IEnumerable<Auto> RecorrerInverso()
    {
        if (frente is null)
            yield break;

        Auto final = frente.Anterior!;
        Auto actual = final;
        do
        {
            yield return actual;
            actual = actual.Anterior!;
        } while (actual != final);
    }
}
