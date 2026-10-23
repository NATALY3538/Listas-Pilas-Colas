namespace PracticaColas
{
    partial class frmEstacionamiento
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
            mnuOpciones = new MenuStrip();
            mnuEntrada = new ToolStripMenuItem();
            mnuSalida = new ToolStripMenuItem();
            mnuRegresar = new ToolStripMenuItem();
            pnlEncabezado = new Panel();
            picIcono = new PictureBox();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            grpEntrada = new GroupBox();
            lblPlacas = new Label();
            txtPlacas = new TextBox();
            lblPropietario = new Label();
            txtPropietario = new TextBox();
            btnEntrada = new Button();
            grpSalida = new GroupBox();
            btnSalida = new Button();
            lblTicket = new Label();
            grpAutos = new GroupBox();
            lblResumen = new Label();
            lblFrente = new Label();
            lblFinal = new Label();
            chkInverso = new CheckBox();
            dgvAutos = new DataGridView();
            colOrden = new DataGridViewTextBoxColumn();
            colPlacas = new DataGridViewTextBoxColumn();
            colPropietario = new DataGridViewTextBoxColumn();
            colHoraEntrada = new DataGridViewTextBoxColumn();
            colTiempo = new DataGridViewTextBoxColumn();
            colCosto = new DataGridViewTextBoxColumn();
            lblRecaudado = new Label();
            tmrActualizar = new System.Windows.Forms.Timer(components);
            mnuOpciones.SuspendLayout();
            pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).BeginInit();
            grpEntrada.SuspendLayout();
            grpSalida.SuspendLayout();
            grpAutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutos).BeginInit();
            SuspendLayout();
            //
            // mnuOpciones
            //
            mnuOpciones.Font = new Font("Segoe UI", 10F);
            mnuOpciones.Items.AddRange(new ToolStripItem[] { mnuEntrada, mnuSalida, mnuRegresar });
            mnuOpciones.Name = "mnuOpciones";
            mnuOpciones.Size = new Size(920, 27);
            //
            // mnuEntrada
            //
            mnuEntrada.Name = "mnuEntrada";
            mnuEntrada.ShortcutKeys = Keys.F1;
            mnuEntrada.Text = "1. Entrada de Auto (F1)";
            mnuEntrada.Click += mnuEntrada_Click;
            //
            // mnuSalida
            //
            mnuSalida.Name = "mnuSalida";
            mnuSalida.ShortcutKeys = Keys.F2;
            mnuSalida.Text = "2. Salida de Autos (F2)";
            mnuSalida.Click += mnuSalida_Click;
            //
            // mnuRegresar
            //
            mnuRegresar.Name = "mnuRegresar";
            mnuRegresar.Text = "3. Regresar al menú";
            mnuRegresar.Click += mnuRegresar_Click;
            //
            // pnlEncabezado
            //
            pnlEncabezado.BackColor = Color.FromArgb(24, 62, 111);
            pnlEncabezado.Controls.Add(lblDescripcion);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(picIcono);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(920, 80);
            //
            // picIcono
            //
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
            lblTitulo.Text = "Ejercicio 3 · Estacionamiento para autos";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(200, 220, 240);
            lblDescripcion.Location = new Point(81, 46);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Text = "Callejón sin límite de cupo: se entra por una puerta y se sale por la otra. Tarifa: $2.00 por segundo.";
            //
            // grpEntrada
            //
            grpEntrada.Controls.Add(btnEntrada);
            grpEntrada.Controls.Add(txtPropietario);
            grpEntrada.Controls.Add(lblPropietario);
            grpEntrada.Controls.Add(txtPlacas);
            grpEntrada.Controls.Add(lblPlacas);
            grpEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpEntrada.ForeColor = Color.FromArgb(24, 62, 111);
            grpEntrada.Location = new Point(16, 122);
            grpEntrada.Name = "grpEntrada";
            grpEntrada.Size = new Size(300, 214);
            grpEntrada.TabIndex = 0;
            grpEntrada.TabStop = false;
            grpEntrada.Text = "1. Entrada de Auto";
            //
            // lblPlacas
            //
            lblPlacas.AutoSize = true;
            lblPlacas.Font = new Font("Segoe UI", 9.5F);
            lblPlacas.ForeColor = Color.Black;
            lblPlacas.Location = new Point(16, 30);
            lblPlacas.Name = "lblPlacas";
            lblPlacas.Text = "Placas del auto:";
            //
            // txtPlacas
            //
            txtPlacas.CharacterCasing = CharacterCasing.Upper;
            txtPlacas.Font = new Font("Segoe UI", 10F);
            txtPlacas.Location = new Point(16, 52);
            txtPlacas.MaxLength = 10;
            txtPlacas.Name = "txtPlacas";
            txtPlacas.PlaceholderText = "Ej. YUC-123-A";
            txtPlacas.Size = new Size(266, 25);
            txtPlacas.TabIndex = 0;
            //
            // lblPropietario
            //
            lblPropietario.AutoSize = true;
            lblPropietario.Font = new Font("Segoe UI", 9.5F);
            lblPropietario.ForeColor = Color.Black;
            lblPropietario.Location = new Point(16, 88);
            lblPropietario.Name = "lblPropietario";
            lblPropietario.Text = "Nombre del propietario:";
            //
            // txtPropietario
            //
            txtPropietario.Font = new Font("Segoe UI", 10F);
            txtPropietario.Location = new Point(16, 110);
            txtPropietario.MaxLength = 60;
            txtPropietario.Name = "txtPropietario";
            txtPropietario.PlaceholderText = "Ej. Juan Pérez";
            txtPropietario.Size = new Size(266, 25);
            txtPropietario.TabIndex = 1;
            //
            // btnEntrada
            //
            btnEntrada.Location = new Point(16, 152);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(266, 44);
            btnEntrada.TabIndex = 2;
            btnEntrada.Text = "Registrar entrada";
            btnEntrada.Click += btnEntrada_Click;
            //
            // grpSalida
            //
            grpSalida.Controls.Add(lblTicket);
            grpSalida.Controls.Add(btnSalida);
            grpSalida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpSalida.ForeColor = Color.FromArgb(24, 62, 111);
            grpSalida.Location = new Point(16, 348);
            grpSalida.Name = "grpSalida";
            grpSalida.Size = new Size(300, 216);
            grpSalida.TabIndex = 1;
            grpSalida.TabStop = false;
            grpSalida.Text = "2. Salida de Autos";
            //
            // btnSalida
            //
            btnSalida.Location = new Point(16, 30);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(266, 44);
            btnSalida.TabIndex = 0;
            btnSalida.Text = "Dar salida al primer auto";
            btnSalida.Click += btnSalida_Click;
            //
            // lblTicket
            //
            lblTicket.BackColor = Color.White;
            lblTicket.BorderStyle = BorderStyle.FixedSingle;
            lblTicket.Font = new Font("Consolas", 9.5F);
            lblTicket.ForeColor = Color.Black;
            lblTicket.Location = new Point(16, 84);
            lblTicket.Name = "lblTicket";
            lblTicket.Padding = new Padding(6);
            lblTicket.Size = new Size(266, 118);
            lblTicket.Text = "Aquí aparecerá el ticket\r\ndel último auto que salió.";
            //
            // grpAutos
            //
            grpAutos.Controls.Add(lblRecaudado);
            grpAutos.Controls.Add(dgvAutos);
            grpAutos.Controls.Add(chkInverso);
            grpAutos.Controls.Add(lblFinal);
            grpAutos.Controls.Add(lblFrente);
            grpAutos.Controls.Add(lblResumen);
            grpAutos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpAutos.ForeColor = Color.FromArgb(24, 62, 111);
            grpAutos.Location = new Point(332, 122);
            grpAutos.Name = "grpAutos";
            grpAutos.Size = new Size(572, 442);
            grpAutos.TabIndex = 2;
            grpAutos.TabStop = false;
            grpAutos.Text = "Autos dentro del callejón";
            //
            // lblResumen
            //
            lblResumen.Font = new Font("Segoe UI", 9.5F);
            lblResumen.ForeColor = Color.Black;
            lblResumen.Location = new Point(16, 26);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(540, 22);
            lblResumen.Text = "Autos dentro: 0";
            //
            // lblFrente
            //
            lblFrente.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFrente.ForeColor = Color.FromArgb(39, 139, 84);
            lblFrente.Location = new Point(16, 50);
            lblFrente.Name = "lblFrente";
            lblFrente.Size = new Size(270, 22);
            lblFrente.Text = "Frente (sale primero): —";
            //
            // lblFinal
            //
            lblFinal.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblFinal.ForeColor = Color.FromArgb(192, 57, 43);
            lblFinal.Location = new Point(290, 50);
            lblFinal.Name = "lblFinal";
            lblFinal.Size = new Size(266, 22);
            lblFinal.Text = "Final (último en entrar): —";
            //
            // chkInverso
            //
            chkInverso.AutoSize = true;
            chkInverso.Font = new Font("Segoe UI", 9.5F);
            chkInverso.ForeColor = Color.Black;
            chkInverso.Location = new Point(16, 76);
            chkInverso.Name = "chkInverso";
            chkInverso.TabIndex = 0;
            chkInverso.Text = "Recorrer desde el final (usando los enlaces Anterior)";
            chkInverso.CheckedChanged += chkInverso_CheckedChanged;
            //
            // dgvAutos
            //
            dgvAutos.Columns.AddRange(new DataGridViewColumn[] { colOrden, colPlacas, colPropietario, colHoraEntrada, colTiempo, colCosto });
            dgvAutos.Location = new Point(16, 104);
            dgvAutos.Name = "dgvAutos";
            dgvAutos.Size = new Size(540, 280);
            dgvAutos.TabIndex = 1;
            //
            // colOrden
            //
            colOrden.FillWeight = 40F;
            colOrden.HeaderText = "Orden";
            colOrden.Name = "colOrden";
            //
            // colPlacas
            //
            colPlacas.FillWeight = 80F;
            colPlacas.HeaderText = "Placas";
            colPlacas.Name = "colPlacas";
            //
            // colPropietario
            //
            colPropietario.FillWeight = 120F;
            colPropietario.HeaderText = "Propietario";
            colPropietario.Name = "colPropietario";
            //
            // colHoraEntrada
            //
            colHoraEntrada.FillWeight = 70F;
            colHoraEntrada.HeaderText = "Entrada";
            colHoraEntrada.Name = "colHoraEntrada";
            //
            // colTiempo
            //
            colTiempo.FillWeight = 60F;
            colTiempo.HeaderText = "Tiempo";
            colTiempo.Name = "colTiempo";
            //
            // colCosto
            //
            colCosto.FillWeight = 70F;
            colCosto.HeaderText = "A pagar";
            colCosto.Name = "colCosto";
            //
            // lblRecaudado
            //
            lblRecaudado.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRecaudado.ForeColor = Color.FromArgb(39, 139, 84);
            lblRecaudado.Location = new Point(16, 394);
            lblRecaudado.Name = "lblRecaudado";
            lblRecaudado.Size = new Size(540, 32);
            lblRecaudado.Text = "Total recaudado: $0.00 · Autos que han salido: 0";
            lblRecaudado.TextAlign = ContentAlignment.MiddleLeft;
            //
            // tmrActualizar
            //
            tmrActualizar.Enabled = true;
            tmrActualizar.Interval = 1000;
            tmrActualizar.Tick += tmrActualizar_Tick;
            //
            // frmEstacionamiento
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(920, 580);
            Controls.Add(grpAutos);
            Controls.Add(grpSalida);
            Controls.Add(grpEntrada);
            Controls.Add(pnlEncabezado);
            Controls.Add(mnuOpciones);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = mnuOpciones;
            MaximizeBox = false;
            Name = "frmEstacionamiento";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 3 — Estacionamiento para autos";
            mnuOpciones.ResumeLayout(false);
            mnuOpciones.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcono).EndInit();
            grpEntrada.ResumeLayout(false);
            grpEntrada.PerformLayout();
            grpSalida.ResumeLayout(false);
            grpAutos.ResumeLayout(false);
            grpAutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuOpciones;
        private ToolStripMenuItem mnuEntrada;
        private ToolStripMenuItem mnuSalida;
        private ToolStripMenuItem mnuRegresar;
        private Panel pnlEncabezado;
        private PictureBox picIcono;
        private Label lblTitulo;
        private Label lblDescripcion;
        private GroupBox grpEntrada;
        private Label lblPlacas;
        private TextBox txtPlacas;
        private Label lblPropietario;
        private TextBox txtPropietario;
        private Button btnEntrada;
        private GroupBox grpSalida;
        private Button btnSalida;
        private Label lblTicket;
        private GroupBox grpAutos;
        private Label lblResumen;
        private Label lblFrente;
        private Label lblFinal;
        private CheckBox chkInverso;
        private DataGridView dgvAutos;
        private DataGridViewTextBoxColumn colOrden;
        private DataGridViewTextBoxColumn colPlacas;
        private DataGridViewTextBoxColumn colPropietario;
        private DataGridViewTextBoxColumn colHoraEntrada;
        private DataGridViewTextBoxColumn colTiempo;
        private DataGridViewTextBoxColumn colCosto;
        private Label lblRecaudado;
        private System.Windows.Forms.Timer tmrActualizar;
    }
}
