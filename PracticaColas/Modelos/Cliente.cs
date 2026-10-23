namespace PracticaColas;

/// <summary>Cliente formado en la ventanilla del banco.</summary>
public class Cliente
{
    public static readonly string[] TiposMovimiento =
    {
        "Depósito",
        "Retiro",
        "Pago de servicios",
        "Transferencia",
        "Consulta de saldo",
        "Cambio de cheque",
    };

    public int Turno { get; }
    public string Nombre { get; }
    public string Movimiento { get; }
    public DateTime HoraLlegada { get; }

    public Cliente(int turno, string nombre, string movimiento, DateTime horaLlegada)
    {
        Turno = turno;
        Nombre = nombre;
        Movimiento = movimiento;
        HoraLlegada = horaLlegada;
    }
}
