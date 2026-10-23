namespace PracticaColas
{
    /// <summary>
    /// Ejercicio 1: administra la cola de la ventanilla de un banco.
    /// Formar = InsertaCola, Atender en ventanilla = EliminaCola.
    /// </summary>
    public partial class frmBanco : Form
    {
        private const int CapacidadVentanilla = 10;

        private readonly ColaBanco cola = new(CapacidadVentanilla);
        private int siguienteTurno = 1;

        public frmBanco()
        {
            InitializeComponent();
            picIcono.Image = Dibujos.CrearIconoBanco(40, Color.White);
            cmbMovimiento.Items.AddRange(Cliente.TiposMovimiento);
            prgOcupacion.Maximum = cola.Capacidad;
            Tema.EstilizarTabla(dgvCola);
            Tema.EstilizarBoton(btnFormar, Tema.Secundario);
            Tema.EstilizarBoton(btnAtender, Tema.Exito);
            Tema.EstilizarBoton(btnRegresar, Tema.Neutro);
            AcceptButton = btnFormar;
            ActualizarVista();
        }

        private void btnFormar_Click(object? sender, EventArgs e)
        {
            string nombre = Validaciones.LimpiarTexto(txtNombre.Text);

            if (nombre.Length == 0)
            {
                Avisar("Hay datos faltantes: escribe el nombre del cliente.", txtNombre);
                return;
            }
            if (!Validaciones.EsNombreValido(nombre))
            {
                Avisar("El nombre solo debe contener letras y espacios (mínimo 2 letras).", txtNombre);
                return;
            }
            if (cmbMovimiento.SelectedIndex < 0)
            {
                Avisar("Hay datos faltantes: selecciona el tipo de movimiento.", cmbMovimiento);
                return;
            }
            if (cola.ColaLlena())
            {
                MessageBox.Show($"Sobreflujo: la cola está llena ({cola.Capacidad} clientes).\n" +
                                "Atiende a un cliente en ventanilla antes de formar a otro.",
                    "Cola llena", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var cliente = new Cliente(siguienteTurno, nombre, cmbMovimiento.Text, DateTime.Now);
                cola.InsertaCola(cliente);
                siguienteTurno++;
                ActualizarVista();

                MessageBox.Show(
                    $"Turno: {cliente.Turno}\n" +
                    $"Cliente: {cliente.Nombre}\n" +
                    $"Movimiento: {cliente.Movimiento}\n" +
                    $"Hora de llegada: {Formato.Hora(cliente.HoraLlegada)}\n\n" +
                    $"Clientes delante de él: {cola.Cantidad - 1}",
                    "Cliente formado en la cola", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombre.Clear();
                cmbMovimiento.SelectedIndex = -1;
                txtNombre.Focus();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo formar al cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtender_Click(object? sender, EventArgs e)
        {
            if (cola.ColaVacia())
            {
                MessageBox.Show("Subflujo: no hay clientes en la cola para atender.", "Cola vacía",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Cliente cliente = cola.EliminaCola();
                DateTime horaAtencion = DateTime.Now;
                TimeSpan espera = horaAtencion - cliente.HoraLlegada;

                lblUltimoAtendido.Text =
                    $"Turno {cliente.Turno}: {cliente.Nombre}\n" +
                    $"{cliente.Movimiento}\n" +
                    $"Llegó {Formato.Hora(cliente.HoraLlegada)} · atendido {Formato.Hora(horaAtencion)}\n" +
                    $"Tiempo en espera: {Formato.Duracion(espera)}";
                lstAtendidos.Items.Insert(0,
                    $"Turno {cliente.Turno} · {cliente.Nombre} · {cliente.Movimiento} · esperó {Formato.Duracion(espera)}");
                ActualizarVista();

                MessageBox.Show(
                    $"Atendiendo al turno {cliente.Turno}: {cliente.Nombre}\n" +
                    $"Movimiento: {cliente.Movimiento}\n\n" +
                    $"Hora de llegada: {Formato.Hora(cliente.HoraLlegada)}\n" +
                    $"Hora de atención: {Formato.Hora(horaAtencion)}\n" +
                    $"Tiempo en espera: {Formato.Duracion(espera)} (mm:ss)",
                    "Atender en ventanilla", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo atender", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrEspera_Tick(object? sender, EventArgs e)
        {
            // Solo refresca la columna de espera para no perder la selección de la tabla.
            DateTime ahora = DateTime.Now;
            int fila = 0;
            foreach (Cliente cliente in cola.Recorrer())
            {
                if (fila >= dgvCola.Rows.Count)
                    break;
                dgvCola.Rows[fila++].Cells[colEspera.Index].Value = Formato.Duracion(ahora - cliente.HoraLlegada);
            }
        }

        private void ActualizarVista()
        {
            dgvCola.Rows.Clear();
            DateTime ahora = DateTime.Now;
            int lugar = 1;
            foreach (Cliente cliente in cola.Recorrer())
            {
                dgvCola.Rows.Add(lugar++, cliente.Turno, cliente.Nombre, cliente.Movimiento,
                    Formato.Hora(cliente.HoraLlegada), Formato.Duracion(ahora - cliente.HoraLlegada));
            }

            if (dgvCola.Rows.Count > 0)
            {
                dgvCola.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(220, 242, 228);
                dgvCola.Rows[0].DefaultCellStyle.Font = new Font(dgvCola.Font, FontStyle.Bold);
                dgvCola.ClearSelection();
            }

            if (cola.ColaVacia())
            {
                lblFrente.Text = "Frente: -1 (cola vacía)";
                lblFinal.Text = "Final: -1 (cola vacía)";
            }
            else
            {
                Cliente primero = cola.VerFrente();
                Cliente ultimo = cola.VerFinal();
                lblFrente.Text = $"Frente: [{cola.Frente}] turno {primero.Turno} · {primero.Nombre}";
                lblFinal.Text = $"Final: [{cola.Final}] turno {ultimo.Turno} · {ultimo.Nombre}";
            }

            lblCantidad.Text = $"Clientes: {cola.Cantidad}/{cola.Capacidad}" + (cola.ColaLlena() ? " (llena)" : "");
            prgOcupacion.Value = cola.Cantidad;
            lblSiguienteTurno.Text = $"Siguiente turno: {siguienteTurno}";
        }

        private static void Avisar(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private void btnRegresar_Click(object? sender, EventArgs e) => Close();
    }
}
