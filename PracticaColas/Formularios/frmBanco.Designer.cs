namespace PracticaColas
{
    partial class frmBanco
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlEncabezado = new Panel();
            picIcono = new PictureBox();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnRegresar = new Button();
            grpNuevoCliente = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblMovimiento = new Label();
            cmbMovimiento = new ComboBox();
            lblSiguienteTurno = new Label();
            btnFormar = new Button();
            grpVentanilla = new GroupBox();
            btnAtender = new Button();
            lblUltimoAtendido = new Label();
            grpCola = new GroupBox();
            lblFrente = new Label();
            lblFinal = new Label();
            lblCantidad = new Label();
            prgOcupacion = new ProgressBar();
            dgvCola = new DataGridView();
            colPosicion = new DataGridViewTextBoxColumn();
            colTurno = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colMovimiento = new DataGridViewTextBoxColumn();
            colHoraLlegada = new DataGridViewTextBoxColumn();
            colEspera = new DataGridViewTextBoxColumn();
            lblAtendidos = new Label();
            lstAtendidos = new ListBox();
            tmrEspera = new System.Windows.Forms.Timer(components);
            pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            grpNuevoCliente.SuspendLayout();
            grpVentanilla.SuspendLayout();
            grpCola.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).BeginInit();
            SuspendLayout();
            //
            // pnlEncabezado
            //
            pnlEncabezado.BackColor = Color.FromArgb(24, 62, 111);
            pnlEncabezado.Controls.Add(btnRegresar);
            pnlEncabezado.Controls.Add(lblDescripcion);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(picIcono);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(900, 80);
            //
            // picIcono
            //
            picIcono.BackColor = Color.Transparent;
            picIcono.Location = new Point(20, 16);
            picIcono.Name = "picIcono";
            picIcono.Size = new Size(48, 48);
            picIcono.SizeMode = PictureBoxSizeMode.CenterImage;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(78, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Ejercicio 1 · Ventanilla de un banco";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(200, 220, 240);
            lblDescripcion.Location = new Point(81, 46);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Text = "Los clientes se forman al final de la cola y se atienden por el frente (FIFO).";
            //
            // btnRegresar
            //
            btnRegresar.Location = new Point(770, 22);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(110, 36);
            btnRegresar.TabIndex = 10;
            btnRegresar.Text = "← Menú";
            btnRegresar.Click += btnRegresar_Click;
            //
            // grpNuevoCliente
            //
            grpNuevoCliente.Controls.Add(btnFormar);
            grpNuevoCliente.Controls.Add(lblSiguienteTurno);
            grpNuevoCliente.Controls.Add(cmbMovimiento);
            grpNuevoCliente.Controls.Add(lblMovimiento);
            grpNuevoCliente.Controls.Add(txtNombre);
            grpNuevoCliente.Controls.Add(lblNombre);
            grpNuevoCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpNuevoCliente.ForeColor = Color.FromArgb(24, 62, 111);
            grpNuevoCliente.Location = new Point(16, 96);
            grpNuevoCliente.Name = "grpNuevoCliente";
            grpNuevoCliente.Size = new Size(300, 246);
            grpNuevoCliente.TabIndex = 0;
            grpNuevoCliente.TabStop = false;
            grpNuevoCliente.Text = "Llegada de un cliente";
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F);
            lblNombre.ForeColor = Color.Black;
            lblNombre.Location = new Point(16, 30);
            lblNombre.Name = "lblNombre";
            lblNombre.Text = "Nombre del cliente:";
            //
            // txtNombre
            //
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.Location = new Point(16, 52);
            txtNombre.MaxLength = 60;
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ej. María López";
            txtNombre.Size = new Size(266, 25);
            txtNombre.TabIndex = 0;
            //
            // lblMovimiento
            //
            lblMovimiento.AutoSize = true;
            lblMovimiento.Font = new Font("Segoe UI", 9.5F);
            lblMovimiento.ForeColor = Color.Black;
            lblMovimiento.Location = new Point(16, 88);
            lblMovimiento.Name = "lblMovimiento";
            lblMovimiento.Text = "Tipo de movimiento:";
            //
            // cmbMovimiento
            //
            cmbMovimiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMovimiento.Font = new Font("Segoe UI", 10F);
            cmbMovimiento.Location = new Point(16, 110);
            cmbMovimiento.Name = "cmbMovimiento";
            cmbMovimiento.Size = new Size(266, 25);
            cmbMovimiento.TabIndex = 1;
            //
            // lblSiguienteTurno
            //
            lblSiguienteTurno.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSiguienteTurno.ForeColor = Color.FromArgb(46, 125, 195);
            lblSiguienteTurno.Location = new Point(16, 146);
            lblSiguienteTurno.Name = "lblSiguienteTurno";
            lblSiguienteTurno.Size = new Size(266, 24);
            lblSiguienteTurno.Text = "Siguiente turno: 1";
            //
            // btnFormar
            //
            btnFormar.Location = new Point(16, 182);
            btnFormar.Name = "btnFormar";
            btnFormar.Size = new Size(266, 44);
            btnFormar.TabIndex = 2;
            btnFormar.Text = "Formar en la cola";
            btnFormar.Click += btnFormar_Click;
            //
            // grpVentanilla
            //
            grpVentanilla.Controls.Add(lblUltimoAtendido);
            grpVentanilla.Controls.Add(btnAtender);
            grpVentanilla.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpVentanilla.ForeColor = Color.FromArgb(24, 62, 111);
            grpVentanilla.Location = new Point(16, 354);
            grpVentanilla.Name = "grpVentanilla";
            grpVentanilla.Size = new Size(300, 200);
            grpVentanilla.TabIndex = 1;
            grpVentanilla.TabStop = false;
            grpVentanilla.Text = "Ventanilla";
            //
            // btnAtender
            //
            btnAtender.Location = new Point(16, 30);
            btnAtender.Name = "btnAtender";
            btnAtender.Size = new Size(266, 48);
            btnAtender.TabIndex = 0;
            btnAtender.Text = "Atender en ventanilla";
            btnAtender.Click += btnAtender_Click;
            //
            // lblUltimoAtendido
            //
            lblUltimoAtendido.BackColor = Color.White;
            lblUltimoAtendido.BorderStyle = BorderStyle.FixedSingle;
            lblUltimoAtendido.Font = new Font("Segoe UI", 9.5F);
            lblUltimoAtendido.ForeColor = Color.Black;
            lblUltimoAtendido.Location = new Point(16, 88);
            lblUltimoAtendido.Name = "lblUltimoAtendido";
            lblUltimoAtendido.Padding = new Padding(6);
            lblUltimoAtendido.Size = new Size(266, 98);
            lblUltimoAtendido.Text = "Aún no se ha atendido a ningún cliente.";
            //
            // grpCola
            //
            grpCola.Controls.Add(lstAtendidos);
            grpCola.Controls.Add(lblAtendidos);
            grpCola.Controls.Add(dgvCola);
            grpCola.Controls.Add(prgOcupacion);
            grpCola.Controls.Add(lblCantidad);
            grpCola.Controls.Add(lblFinal);
            grpCola.Controls.Add(lblFrente);
            grpCola.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpCola.ForeColor = Color.FromArgb(24, 62, 111);
            grpCola.Location = new Point(332, 96);
            grpCola.Name = "grpCola";
            grpCola.Size = new Size(552, 458);
            grpCola.TabIndex = 2;
            grpCola.TabStop = false;
            grpCola.Text = "Estado de la cola";
            //
            // lblFrente
            //
            lblFrente.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFrente.ForeColor = Color.FromArgb(39, 139, 84);
            lblFrente.Location = new Point(16, 28);
            lblFrente.Name = "lblFrente";
            lblFrente.Size = new Size(340, 22);
            lblFrente.Text = "Frente: -1";
            //
            // lblFinal
            //
            lblFinal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFinal.ForeColor = Color.FromArgb(192, 57, 43);
            lblFinal.Location = new Point(16, 52);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(340, 22);
            lblFinal.Text = "Final: -1";
            //
            // lblCantidad
            //
            lblCantidad.Font = new Font("Segoe UI", 9.5F);
            lblCantidad.ForeColor = Color.Black;
            lblCantidad.Location = new Point(360, 28);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(176, 22);
            lblCantidad.Text = "Clientes: 0/10";
            lblCantidad.TextAlign = ContentAlignment.MiddleRight;
            //
            // prgOcupacion
            //
            prgOcupacion.Location = new Point(360, 54);
            prgOcupacion.Name = "prgOcupacion";
            prgOcupacion.Size = new Size(176, 16);
            //
            // dgvCola
            //
            dgvCola.Columns.AddRange(new DataGridViewColumn[] { colPosicion, colTurno, colNombre, colMovimiento, colHoraLlegada, colEspera });
            dgvCola.Location = new Point(16, 82);
            dgvCola.Name = "dgvCola";
            dgvCola.Size = new Size(520, 220);
            dgvCola.TabIndex = 0;
            //
            // colPosicion
            //
            colPosicion.FillWeight = 45F;
            colPosicion.HeaderText = "Lugar";
            colPosicion.Name = "colPosicion";
            //
            // colTurno
            //
            colTurno.FillWeight = 45F;
            colTurno.HeaderText = "Turno";
            colTurno.Name = "colTurno";
            //
            // colNombre
            //
            colNombre.FillWeight = 120F;
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            //
            // colMovimiento
            //
            colMovimiento.FillWeight = 110F;
            colMovimiento.HeaderText = "Movimiento";
            colMovimiento.Name = "colMovimiento";
            //
            // colHoraLlegada
            //
            colHoraLlegada.FillWeight = 70F;
            colHoraLlegada.HeaderText = "Llegada";
            colHoraLlegada.Name = "colHoraLlegada";
            //
            // colEspera
            //
            colEspera.FillWeight = 65F;
            colEspera.HeaderText = "Espera";
            colEspera.Name = "colEspera";
            //
            // lblAtendidos
            //
            lblAtendidos.AutoSize = true;
            lblAtendidos.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAtendidos.Location = new Point(16, 312);
            lblAtendidos.Name = "lblAtendidos";
            lblAtendidos.Text = "Clientes atendidos y su tiempo de espera:";
            //
            // lstAtendidos
            //
            lstAtendidos.Font = new Font("Segoe UI", 9.5F);
            lstAtendidos.ForeColor = Color.Black;
            lstAtendidos.ItemHeight = 17;
            lstAtendidos.Location = new Point(16, 336);
            lstAtendidos.Name = "lstAtendidos";
            lstAtendidos.Size = new Size(520, 106);
            lstAtendidos.TabIndex = 1;
            //
            // tmrEspera
            //
            tmrEspera.Enabled = true;
            tmrEspera.Interval = 1000;
            tmrEspera.Tick += tmrEspera_Tick;
            //
            // frmBanco
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(900, 570);
            Controls.Add(grpCola);
            Controls.Add(grpVentanilla);
            Controls.Add(grpNuevoCliente);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmBanco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 1 — Ventanilla de un banco";
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).EndInit();
            grpNuevoCliente.ResumeLayout(false);
            grpNuevoCliente.PerformLayout();
            grpVentanilla.ResumeLayout(false);
            grpCola.ResumeLayout(false);
            grpCola.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCola).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEncabezado;
        private PictureBox picIcono;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnRegresar;
        private GroupBox grpNuevoCliente;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblMovimiento;
        private ComboBox cmbMovimiento;
        private Label lblSiguienteTurno;
        private Button btnFormar;
        private GroupBox grpVentanilla;
        private Button btnAtender;
        private Label lblUltimoAtendido;
        private GroupBox grpCola;
        private Label lblFrente;
        private Label lblFinal;
        private Label lblCantidad;
        private ProgressBar prgOcupacion;
        private DataGridView dgvCola;
        private DataGridViewTextBoxColumn colPosicion;
        private DataGridViewTextBoxColumn colTurno;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colMovimiento;
        private DataGridViewTextBoxColumn colHoraLlegada;
        private DataGridViewTextBoxColumn colEspera;
        private Label lblAtendidos;
        private ListBox lstAtendidos;
        private System.Windows.Forms.Timer tmrEspera;
    }
}
