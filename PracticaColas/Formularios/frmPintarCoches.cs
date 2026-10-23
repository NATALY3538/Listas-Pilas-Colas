namespace PracticaColas
{
    /// <summary>
    /// Ejercicio 2: juego de pintar coches. Los coches llegan a una cola (Cola&lt;Coche&gt;)
    /// y solo se puede pintar el primero. El juego termina cuando hay 5 coches enfilados.
    /// </summary>
    public partial class frmPintarCoches : Form
    {
        private const int LimiteCola = 5;
        private const int IntervaloInicialMs = 20000;
        private const int ReduccionPorNivelMs = 3000;
        private const int IntervaloMinimoMs = 5000;
        private const int CochesPorNivel = 3;

        private static readonly string RutaRecord = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PracticaColas", "record_pintar_coches.txt");

        private readonly Cola<Coche> cola = new();
        private readonly Random random = new();
        private readonly List<Button> botonesColor = new();

        private ColorPintura? colorSeleccionado;
        private RecordJuego? record;
        private bool enJuego;
        private int pintados;
        private int numeroCoche;
        private int intervaloActualMs = IntervaloInicialMs;
        private DateTime inicioJuego;
        private DateTime proximaLlegada;

        public frmPintarCoches()
        {
            InitializeComponent();
            Tema.EstilizarBoton(btnIniciar, Tema.Exito);
            Tema.EstilizarBoton(btnRegresar, Tema.Neutro);
            CrearPaleta();
            record = CargarRecord();
            ActualizarMarcador();
        }

        private void CrearPaleta()
        {
            foreach (ColorPintura color in ColorPintura.Paleta)
            {
                var boton = new Button
                {
                    Name = "btnColor" + color.Nombre,
                    Text = color.Nombre,
                    Tag = color,
                    Size = new Size(92, 52),
                    Margin = new Padding(0, 0, 8, 0),
                    BackColor = color.Valor,
                    ForeColor = Tema.ColorTextoSobre(color.Valor),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                };
                boton.FlatAppearance.BorderColor = Color.Black;
                boton.FlatAppearance.BorderSize = 1;
                boton.Click += btnColor_Click;
                botonesColor.Add(boton);
                flpPaleta.Controls.Add(boton);
            }
        }

        private void btnIniciar_Click(object? sender, EventArgs e) => IniciarJuego();

        private void IniciarJuego()
        {
            cola.Vaciar();
            pintados = 0;
            numeroCoche = 0;
            intervaloActualMs = IntervaloInicialMs;
            inicioJuego = DateTime.Now;
            enJuego = true;
            picUltimo.Image = null;

            EnfilarCoche();
            tmrLlegada.Interval = intervaloActualMs;
            proximaLlegada = DateTime.Now.AddMilliseconds(intervaloActualMs);
            tmrLlegada.Start();
            tmrReloj.Start();

            btnIniciar.Enabled = false;
            MostrarMensaje("¡A pintar! Atiende primero al coche marcado como ATENDER.", Tema.Primario);
            ActualizarMarcador();
        }

        private void tmrLlegada_Tick(object? sender, EventArgs e)
        {
            // Tras un cambio de nivel el primer intervalo puede ser más corto; se restablece aquí.
            tmrLlegada.Interval = intervaloActualMs;
            proximaLlegada = DateTime.Now.AddMilliseconds(intervaloActualMs);
            EnfilarCoche();
        }

        private void tmrReloj_Tick(object? sender, EventArgs e) => ActualizarMarcador();

        private void EnfilarCoche()
        {
            cola.Encolar(new Coche(++numeroCoche, ColorPintura.Aleatorio(random)));
            pnlCola.Invalidate();
            if (cola.Cantidad >= LimiteCola)
                TerminarJuego();
        }

        private void btnColor_Click(object? sender, EventArgs e)
        {
            if (sender is not Button { Tag: ColorPintura color })
                return;

            colorSeleccionado = color;
            foreach (Button boton in botonesColor)
                boton.FlatAppearance.BorderSize = Equals(boton.Tag, color) ? 4 : 1;
            pnlMuestra.BackColor = color.Valor;
            lblColorSeleccionado.Text = $"Color seleccionado: {color.Nombre}";
        }

        private void pnlCola_MouseClick(object? sender, MouseEventArgs e)
        {
            if (!enJuego)
            {
                MostrarMensaje("Presiona \"Iniciar juego\" para comenzar.", Tema.Neutro);
                return;
            }

            int lugar = e.X / AnchoLugar();
            if (lugar >= cola.Cantidad)
                return;
            if (lugar > 0)
            {
                MostrarMensaje("Respeta la cola: solo puedes pintar el PRIMER coche.", Tema.Peligro);
                return;
            }
            if (colorSeleccionado is null)
            {
                MostrarMensaje("Primero selecciona un color de la paleta.", Tema.Peligro);
                return;
            }

            Coche primero = cola.Primero();
            if (colorSeleccionado != primero.ColorSolicitado)
            {
                MostrarMensaje($"Color incorrecto: el coche #{primero.Numero} pide {primero.ColorSolicitado.Nombre}.", Tema.Peligro);
                return;
            }

            Coche pintado = cola.Desencolar();
            pintados++;
            picUltimo.Image?.Dispose();
            picUltimo.Image = Dibujos.CrearCoche(180, 96, pintado.ColorSolicitado.Valor);

            if (pintados % CochesPorNivel == 0 && intervaloActualMs > IntervaloMinimoMs)
            {
                intervaloActualMs = Math.Max(IntervaloMinimoMs, intervaloActualMs - ReduccionPorNivelMs);
                ReprogramarLlegada();
                MostrarMensaje($"¡Coche #{pintado.Numero} pintado! Subes de nivel: ahora llega un coche cada {intervaloActualMs / 1000} s.", Tema.Exito);
            }
            else
            {
                MostrarMensaje($"¡Coche #{pintado.Numero} pintado de {pintado.ColorSolicitado.Nombre}!", Tema.Exito);
            }

            ActualizarMarcador();
            pnlCola.Invalidate();
        }

        /// <summary>Aplica el nuevo intervalo sin retrasar el coche que ya estaba por llegar.</summary>
        private void ReprogramarLlegada()
        {
            double restanteMs = (proximaLlegada - DateTime.Now).TotalMilliseconds;
            int esperaMs = (int)Math.Clamp(restanteMs, 1, intervaloActualMs);
            tmrLlegada.Stop();
            tmrLlegada.Interval = esperaMs;
            proximaLlegada = DateTime.Now.AddMilliseconds(esperaMs);
            tmrLlegada.Start();
        }

        private void TerminarJuego()
        {
            enJuego = false;
            tmrLlegada.Stop();
            tmrReloj.Stop();
            TimeSpan tiempoTotal = DateTime.Now - inicioJuego;

            var partida = new RecordJuego(pintados, tiempoTotal);
            bool nuevoRecord = partida.SuperaA(record);
            if (nuevoRecord)
            {
                record = partida;
                GuardarRecord(partida);
            }

            ActualizarMarcador();
            lblSiguiente.Text = "Siguiente coche en: --";
            btnIniciar.Enabled = true;
            btnIniciar.Text = "↻ Jugar de nuevo";
            MostrarMensaje("Fin del juego: se juntaron 5 coches en la cola.", Tema.Peligro);
            pnlCola.Invalidate();

            MessageBox.Show(
                $"¡Se acabó! Hay {LimiteCola} coches enfilados.\n\n" +
                $"Coches pintados: {pintados}\n" +
                $"Tiempo total: {Formato.Duracion(tiempoTotal)} (mm:ss)\n\n" +
                (nuevoRecord ? "¡Nuevo récord!" : $"Récord a superar: {record}"),
                "Fin del juego", MessageBoxButtons.OK,
                nuevoRecord ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation);
        }

        private void ActualizarMarcador()
        {
            lblPintados.Text = $"Pintados: {pintados}";
            lblIntervalo.Text = $"Llega uno cada {intervaloActualMs / 1000} s";
            lblRecord.Text = record is null ? "Récord: —" : $"Récord: {record}";

            if (enJuego)
            {
                lblTiempo.Text = $"Tiempo: {Formato.Duracion(DateTime.Now - inicioJuego)}";
                int segundos = Math.Max(0, (int)Math.Ceiling((proximaLlegada - DateTime.Now).TotalSeconds));
                lblSiguiente.Text = $"Siguiente coche en: {segundos} s";
            }
        }

        private void MostrarMensaje(string texto, Color color)
        {
            lblMensaje.Text = texto;
            lblMensaje.ForeColor = color;
        }

        private int AnchoLugar() => pnlCola.ClientSize.Width / LimiteCola;

        private void pnlCola_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int ancho = AnchoLugar();
            int alto = pnlCola.ClientSize.Height;

            using var fuenteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
            using var fuenteEtiqueta = new Font("Segoe UI", 10F, FontStyle.Bold);
            using var formatoCentro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var lapizCarril = new Pen(Color.FromArgb(240, 240, 240), 3) { DashPattern = new[] { 4f, 3f } };
            using var lapizLugar = new Pen(Color.FromArgb(120, 125, 135), 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            using var brochaTextoTenue = new SolidBrush(Color.FromArgb(150, 155, 165));

            g.DrawLine(lapizCarril, 0, alto - 14, pnlCola.ClientSize.Width, alto - 14);

            Coche[] coches = cola.ToArray();
            for (int i = 0; i < LimiteCola; i++)
            {
                var lugar = new Rectangle(i * ancho, 0, ancho, alto);
                var areaCoche = new RectangleF(lugar.X + 14, 48, ancho - 28, 100);

                if (i < coches.Length)
                {
                    Coche coche = coches[i];
                    string titulo = i == 0 ? "▶ ATENDER" : $"En espera #{i + 1}";
                    Brush brochaTitulo = i == 0 ? Brushes.Gold : Brushes.White;
                    g.DrawString(titulo, fuenteTitulo, brochaTitulo, new RectangleF(lugar.X, 6, ancho, 20), formatoCentro);
                    g.DrawString($"Coche #{coche.Numero}", fuenteTitulo, Brushes.Gainsboro, new RectangleF(lugar.X, 26, ancho, 18), formatoCentro);

                    Dibujos.DibujarCoche(g, areaCoche, Dibujos.SinPintar);

                    var etiqueta = new RectangleF(lugar.X + 24, 160, ancho - 48, 34);
                    using (var ruta = Dibujos.Redondeado(etiqueta, 8))
                    using (var brochaEtiqueta = new SolidBrush(coche.ColorSolicitado.Valor))
                    using (var brochaTexto = new SolidBrush(Tema.ColorTextoSobre(coche.ColorSolicitado.Valor)))
                    {
                        g.FillPath(brochaEtiqueta, ruta);
                        g.DrawPath(Pens.White, ruta);
                        g.DrawString(coche.ColorSolicitado.Nombre, fuenteEtiqueta, brochaTexto, etiqueta, formatoCentro);
                    }

                    if (i == 0 && enJuego)
                    {
                        using var lapizMarco = new Pen(Color.Gold, 3);
                        g.DrawRectangle(lapizMarco, lugar.X + 4, 4, ancho - 9, alto - 26);
                    }
                }
                else
                {
                    g.DrawRectangle(lapizLugar, areaCoche.X, areaCoche.Y, areaCoche.Width, areaCoche.Height + 46);
                    g.DrawString("Lugar libre", fuenteTitulo, brochaTextoTenue,
                        new RectangleF(lugar.X, areaCoche.Y, ancho, areaCoche.Height + 46), formatoCentro);
                }
            }

            if (!enJuego && coches.Length == 0)
            {
                using var fondo = new SolidBrush(Color.FromArgb(200, 30, 33, 40));
                g.FillRectangle(fondo, pnlCola.ClientRectangle);
                using var fuenteGrande = new Font("Segoe UI", 16F, FontStyle.Bold);
                g.DrawString("Presiona \"Iniciar juego\"", fuenteGrande, Brushes.White, pnlCola.ClientRectangle, formatoCentro);
            }
        }

        private static RecordJuego? CargarRecord()
        {
            try
            {
                if (!File.Exists(RutaRecord))
                    return null;
                string[] partes = File.ReadAllText(RutaRecord).Split(';');
                if (partes.Length == 2 && int.TryParse(partes[0], out int coches) && double.TryParse(partes[1],
                        System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double segundos))
                    return new RecordJuego(coches, TimeSpan.FromSeconds(segundos));
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // Si no se puede leer el récord se empieza sin él.
            }
            return null;
        }

        private static void GuardarRecord(RecordJuego nuevo)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(RutaRecord)!);
                File.WriteAllText(RutaRecord, string.Create(System.Globalization.CultureInfo.InvariantCulture,
                    $"{nuevo.Pintados};{nuevo.Tiempo.TotalSeconds}"));
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                // El récord se conserva en memoria aunque no se pueda guardar en disco.
            }
        }

        private void frmPintarCoches_FormClosing(object? sender, FormClosingEventArgs e)
        {
            tmrLlegada.Stop();
            tmrReloj.Stop();
        }

        private void btnRegresar_Click(object? sender, EventArgs e) => Close();
    }
}
