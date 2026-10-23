namespace PracticaColas
{
    /// <summary>
    /// Ejercicio 3: estacionamiento tipo callejón administrado con una
    /// cola circular doblemente ligada. Se cobra $2.00 por segundo.
    /// </summary>
    public partial class frmEstacionamiento : Form
    {
        private readonly ColaCircularDobleAutos callejon = new();
        private decimal totalRecaudado;
        private int autosAtendidos;

        public frmEstacionamiento()
        {
            InitializeComponent();
            picIcono.Image = Dibujos.CrearIconoLetra(40, "P", Tema.Secundario);
            Tema.EstilizarTabla(dgvAutos);
            Tema.EstilizarBoton(btnEntrada, Tema.Secundario);
            Tema.EstilizarBoton(btnSalida, Tema.Exito);
            AcceptButton = btnEntrada;
            ActualizarVista();
        }

        private void mnuEntrada_Click(object? sender, EventArgs e) => txtPlacas.Focus();

        private void mnuSalida_Click(object? sender, EventArgs e) => DarSalida();

        private void mnuRegresar_Click(object? sender, EventArgs e) => Close();

        private void btnEntrada_Click(object? sender, EventArgs e)
        {
            string placas = txtPlacas.Text.Trim().ToUpperInvariant();
            string propietario = Validaciones.LimpiarTexto(txtPropietario.Text);

            if (placas.Length == 0 || propietario.Length == 0)
            {
                Avisar("Hay datos faltantes: captura las placas y el nombre del propietario.",
                    placas.Length == 0 ? txtPlacas : txtPropietario);
                return;
            }
            if (!Validaciones.EsPlacaValida(placas))
            {
                Avisar("Placas no válidas: usa de 5 a 10 letras, números o guiones e incluye al menos un número (Ej. YUC-123-A).", txtPlacas);
                return;
            }
            if (!Validaciones.EsNombreValido(propietario))
            {
                Avisar("El nombre del propietario solo debe contener letras y espacios (mínimo 2 letras).", txtPropietario);
                return;
            }
            if (callejon.ExistePlaca(placas))
            {
                Avisar($"El auto con placas {placas} ya está dentro del estacionamiento.", txtPlacas);
                return;
            }

            var auto = new Auto(placas, propietario, DateTime.Now);
            callejon.Insertar(auto);
            ActualizarVista();

            MessageBox.Show(
                $"Entrada registrada.\n\n" +
                $"Placas: {auto.Placas}\n" +
                $"Propietario: {auto.Propietario}\n" +
                $"Hora de entrada: {Formato.Hora(auto.HoraEntrada)}\n" +
                $"Lugar en el callejón: {callejon.Cantidad}",
                "Entrada de auto", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtPlacas.Clear();
            txtPropietario.Clear();
            txtPlacas.Focus();
        }

        private void btnSalida_Click(object? sender, EventArgs e) => DarSalida();

        private void DarSalida()
        {
            if (callejon.EstaVacia())
            {
                MessageBox.Show("El estacionamiento está vacío: no hay autos para dar salida.", "Salida de autos",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Auto auto = callejon.Eliminar();
                DateTime horaSalida = DateTime.Now;
                long segundos = auto.SegundosCobrados(horaSalida);
                decimal costo = auto.CalcularCosto(horaSalida);

                totalRecaudado += costo;
                autosAtendidos++;

                lblTicket.Text =
                    $"Placas:  {auto.Placas}\n" +
                    $"Dueño:   {auto.Propietario}\n" +
                    $"Entrada: {Formato.Hora(auto.HoraEntrada)}\n" +
                    $"Salida:  {Formato.Hora(horaSalida)}\n" +
                    $"Tiempo:  {segundos} s\n" +
                    $"Total:   {Formato.Moneda(costo)}";
                ActualizarVista();

                MessageBox.Show(
                    $"Placas: {auto.Placas}\n" +
                    $"Propietario: {auto.Propietario}\n\n" +
                    $"Hora de entrada: {Formato.Hora(auto.HoraEntrada)}\n" +
                    $"Hora de salida: {Formato.Hora(horaSalida)}\n" +
                    $"Tiempo cobrado: {segundos} segundos\n\n" +
                    $"Costo: {segundos} s × {Formato.Moneda(Auto.TarifaPorSegundo)} = {Formato.Moneda(costo)}",
                    "Salida de auto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Salida de autos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkInverso_CheckedChanged(object? sender, EventArgs e) => ActualizarVista();

        private void tmrActualizar_Tick(object? sender, EventArgs e)
        {
            // Actualiza tiempo y costo acumulado sin reconstruir la tabla.
            DateTime ahora = DateTime.Now;
            int fila = 0;
            foreach (Auto auto in AutosEnOrden())
            {
                if (fila >= dgvAutos.Rows.Count)
                    break;
                DataGridViewRow renglon = dgvAutos.Rows[fila++];
                renglon.Cells[colTiempo.Index].Value = Formato.Duracion(ahora - auto.HoraEntrada);
                renglon.Cells[colCosto.Index].Value = Formato.Moneda(auto.CalcularCosto(ahora));
            }
        }

        private IEnumerable<Auto> AutosEnOrden() =>
            chkInverso.Checked ? callejon.RecorrerInverso() : callejon.Recorrer();

        private void ActualizarVista()
        {
            dgvAutos.Rows.Clear();
            DateTime ahora = DateTime.Now;
            int orden = chkInverso.Checked ? callejon.Cantidad : 1;
            foreach (Auto auto in AutosEnOrden())
            {
                dgvAutos.Rows.Add(orden, auto.Placas, auto.Propietario, Formato.Hora(auto.HoraEntrada),
                    Formato.Duracion(ahora - auto.HoraEntrada), Formato.Moneda(auto.CalcularCosto(ahora)));
                orden += chkInverso.Checked ? -1 : 1;
            }
            dgvAutos.ClearSelection();

            lblResumen.Text = $"Autos dentro: {callejon.Cantidad} · Entran por el final y salen por el frente.";
            lblFrente.Text = callejon.Frente is { } frente ? $"Frente (sale primero): {frente.Placas}" : "Frente (sale primero): —";
            lblFinal.Text = callejon.Final is { } final ? $"Final (último en entrar): {final.Placas}" : "Final (último en entrar): —";
            lblRecaudado.Text = $"Total recaudado: {Formato.Moneda(totalRecaudado)} · Autos que han salido: {autosAtendidos}";
        }

        private static void Avisar(string mensaje, Control control)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }
    }
}
