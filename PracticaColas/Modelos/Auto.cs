namespace PracticaColas;

/// <summary>
/// Auto del estacionamiento. Cada auto es un nodo de la cola circular doblemente ligada.
/// </summary>
public class Auto
{
    public const decimal TarifaPorSegundo = 2.00m;

    public string Placas { get; }
    public string Propietario { get; }
    public DateTime HoraEntrada { get; }

    public Auto? Siguiente { get; set; }
    public Auto? Anterior { get; set; }

    public Auto(string placas, string propietario, DateTime horaEntrada)
    {
        Placas = placas;
        Propietario = propietario;
        HoraEntrada = horaEntrada;
    }

    /// <summary>Segundos a cobrar: todo segundo iniciado se cobra, con un mínimo de 1.</summary>
    public long SegundosCobrados(DateTime horaSalida) =>
        Math.Max(1, (long)Math.Ceiling((horaSalida - HoraEntrada).TotalSeconds));

    public decimal CalcularCosto(DateTime horaSalida) => SegundosCobrados(horaSalida) * TarifaPorSegundo;
}
