namespace PracticaColas;

/// <summary>Color de la paleta del juego.</summary>
public sealed record ColorPintura(string Nombre, Color Valor)
{
    public static readonly ColorPintura[] Paleta =
    {
        new("Rojo", Color.FromArgb(214, 40, 40)),
        new("Azul", Color.FromArgb(33, 97, 204)),
        new("Verde", Color.FromArgb(46, 160, 67)),
        new("Amarillo", Color.FromArgb(245, 200, 30)),
        new("Naranja", Color.FromArgb(245, 128, 32)),
        new("Morado", Color.FromArgb(128, 64, 176)),
        new("Rosa", Color.FromArgb(238, 110, 170)),
    };

    public static ColorPintura Aleatorio(Random random) => Paleta[random.Next(Paleta.Length)];
}

/// <summary>Coche que espera en la cola para ser pintado.</summary>
public class Coche
{
    public int Numero { get; }
    public ColorPintura ColorSolicitado { get; }

    public Coche(int numero, ColorPintura colorSolicitado)
    {
        Numero = numero;
        ColorSolicitado = colorSolicitado;
    }
}

/// <summary>Mejor partida registrada (más coches pintados; en empate, más tiempo aguantado).</summary>
public sealed record RecordJuego(int Pintados, TimeSpan Tiempo)
{
    public bool SuperaA(RecordJuego? otro) =>
        otro is null || Pintados > otro.Pintados || (Pintados == otro.Pintados && Tiempo > otro.Tiempo);

    public override string ToString() => $"{Pintados} coches en {Formato.Duracion(Tiempo)}";
}
