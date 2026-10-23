using System.Drawing.Drawing2D;

namespace PracticaColas;

/// <summary>
/// Imágenes del proyecto dibujadas con GDI+ (coches e íconos del menú),
/// así el proyecto no depende de archivos de imagen externos.
/// </summary>
public static class Dibujos
{
    public static readonly Color SinPintar = Color.FromArgb(205, 208, 212);

    public static void DibujarCoche(Graphics g, RectangleF r, Color carroceria)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        float x = r.X, y = r.Y, w = r.Width, h = r.Height;

        using var brochaCarroceria = new SolidBrush(carroceria);
        using var lapizContorno = new Pen(ControlPaint.Dark(carroceria, 0.35f), 2f);
        using var brochaVidrio = new SolidBrush(Color.FromArgb(178, 218, 242));
        using var brochaLlanta = new SolidBrush(Color.FromArgb(35, 35, 40));

        PointF[] cabina =
        {
            new(x + w * 0.20f, y + h * 0.46f), new(x + w * 0.33f, y + h * 0.10f),
            new(x + w * 0.67f, y + h * 0.10f), new(x + w * 0.82f, y + h * 0.46f),
        };
        g.FillPolygon(brochaCarroceria, cabina);
        g.DrawPolygon(lapizContorno, cabina);

        using (GraphicsPath cuerpo = Redondeado(new RectangleF(x, y + h * 0.42f, w, h * 0.36f), h * 0.12f))
        {
            g.FillPath(brochaCarroceria, cuerpo);
            g.DrawPath(lapizContorno, cuerpo);
        }

        PointF[] vidrioTrasero =
        {
            new(x + w * 0.27f, y + h * 0.42f), new(x + w * 0.36f, y + h * 0.17f),
            new(x + w * 0.48f, y + h * 0.17f), new(x + w * 0.48f, y + h * 0.42f),
        };
        PointF[] vidrioDelantero =
        {
            new(x + w * 0.52f, y + h * 0.42f), new(x + w * 0.52f, y + h * 0.17f),
            new(x + w * 0.64f, y + h * 0.17f), new(x + w * 0.75f, y + h * 0.42f),
        };
        g.FillPolygon(brochaVidrio, vidrioTrasero);
        g.FillPolygon(brochaVidrio, vidrioDelantero);

        g.FillEllipse(Brushes.Gold, x + w * 0.93f, y + h * 0.50f, w * 0.06f, h * 0.10f);
        g.FillRectangle(Brushes.Firebrick, x + w * 0.005f, y + h * 0.50f, w * 0.035f, h * 0.09f);

        float radio = h * 0.17f;
        float centroY = y + h * 0.80f;
        foreach (float centroX in new[] { x + w * 0.24f, x + w * 0.76f })
        {
            g.FillEllipse(brochaLlanta, centroX - radio, centroY - radio, radio * 2, radio * 2);
            g.FillEllipse(Brushes.Silver, centroX - radio * 0.45f, centroY - radio * 0.45f, radio * 0.9f, radio * 0.9f);
        }
    }

    public static GraphicsPath Redondeado(RectangleF r, float radio)
    {
        float d = Math.Min(radio * 2, Math.Min(r.Width, r.Height));
        var ruta = new GraphicsPath();
        ruta.AddArc(r.X, r.Y, d, d, 180, 90);
        ruta.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        ruta.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        ruta.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        ruta.CloseFigure();
        return ruta;
    }

    public static Bitmap CrearCoche(int ancho, int alto, Color carroceria)
    {
        var imagen = new Bitmap(ancho, alto);
        using Graphics g = Graphics.FromImage(imagen);
        DibujarCoche(g, new RectangleF(2, 2, ancho - 4, alto - 4), carroceria);
        return imagen;
    }

    public static Bitmap CrearIconoBanco(int t, Color color)
    {
        var imagen = new Bitmap(t, t);
        using Graphics g = Graphics.FromImage(imagen);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        using var brocha = new SolidBrush(color);
        g.FillPolygon(brocha, new PointF[] { new(t * 0.5f, t * 0.04f), new(t * 0.96f, t * 0.30f), new(t * 0.04f, t * 0.30f) });
        for (int i = 0; i < 4; i++)
            g.FillRectangle(brocha, t * (0.12f + i * 0.21f), t * 0.37f, t * 0.12f, t * 0.42f);
        g.FillRectangle(brocha, t * 0.04f, t * 0.84f, t * 0.92f, t * 0.11f);
        return imagen;
    }

    public static Bitmap CrearIconoLetra(int t, string letra, Color fondo)
    {
        var imagen = new Bitmap(t, t);
        using Graphics g = Graphics.FromImage(imagen);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
        using (GraphicsPath cuadro = Redondeado(new RectangleF(1, 1, t - 2, t - 2), t * 0.18f))
        using (var brocha = new SolidBrush(fondo))
            g.FillPath(brocha, cuadro);
        using var fuente = new Font("Segoe UI", t * 0.42f, FontStyle.Bold, GraphicsUnit.Pixel);
        using var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        g.DrawString(letra, fuente, Brushes.White, new RectangleF(0, 0, t, t), formato);
        return imagen;
    }
}
