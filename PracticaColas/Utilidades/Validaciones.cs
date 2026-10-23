using System.Text.RegularExpressions;

namespace PracticaColas;

/// <summary>Reglas de validación de los datos que captura el usuario.</summary>
public static class Validaciones
{
    private static readonly Regex PatronNombre =
        new(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ]+( [A-Za-zÁÉÍÓÚÜÑáéíóúüñ]+)*$");

    // Letras, números y guiones; al menos un número; no empieza ni termina con guion.
    private static readonly Regex PatronPlaca =
        new(@"^(?=.*\d)[A-Z0-9][A-Z0-9-]{3,8}[A-Z0-9]$");

    /// <summary>Quita espacios sobrantes al inicio, al final y entre palabras.</summary>
    public static string LimpiarTexto(string texto) => Regex.Replace(texto.Trim(), @"\s+", " ");

    public static bool EsNombreValido(string nombre) =>
        nombre.Length is >= 2 and <= 60 && PatronNombre.IsMatch(nombre);

    public static bool EsPlacaValida(string placas) => PatronPlaca.IsMatch(placas);
}

public static class Formato
{
    public static string Duracion(TimeSpan t) =>
        t.TotalHours >= 1
            ? $"{(int)t.TotalHours:00}:{t.Minutes:00}:{t.Seconds:00}"
            : $"{t.Minutes:00}:{t.Seconds:00}";

    public static string Hora(DateTime fecha) => fecha.ToString("HH:mm:ss");

    public static string Moneda(decimal cantidad) => cantidad.ToString("$#,##0.00");
}
