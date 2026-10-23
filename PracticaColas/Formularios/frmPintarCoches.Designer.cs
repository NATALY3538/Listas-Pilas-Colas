namespace PracticaColas
{
    partial class frmPintarCoches
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
            lblTitulo = new Label();
            lblDescripcion = new Label();
            btnIniciar = new Button();
            btnRegresar = new Button();
            lblPintados = new Label();
            lblTiempo = new Label();
            lblSiguiente = new Label();
            lblIntervalo = new Label();
            lblRecord = new Label();
            pnlCola = new PanelDoble();
            lblInstruccion = new Label();
            flpPaleta = new FlowLayoutPanel();
            grpUltimo = new GroupBox();
            picUltimo = new PictureBox();
            lblColorSeleccionado = new Label();
            pnlMuestra = new Panel();
            lblMensaje = new Label();
            tmrLlegada = new System.Windows.Forms.Timer(components);
            tmrReloj = new System.Windows.Forms.Timer(components);
            pnlEncabezado.SuspendLayout();
            grpUltimo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUltimo).BeginInit();
            SuspendLayout();
            //
            // pnlEncabezado
            //
            pnlEncabezado.BackColor = Color.FromArgb(24, 62, 111);
            pnlEncabezado.Controls.Add(btnRegresar);
            pnlEncabezado.Controls.Add(btnIniciar);
            pnlEncabezado.Controls.Add(lblDescripcion);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(960, 80);
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Ejercicio 2 · Juego: pintar coches";
            //
            // lblDescripcion
            //
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 9.5F);
            lblDescripcion.ForeColor = Color.FromArgb(200, 220, 240);
            lblDescripcion.Location = new Point(23, 46);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Text = "Pinta los coches en el orden en que llegan. Si se juntan 5 coches en la cola, pierdes.";
            //
            // btnIniciar
            //
            btnIniciar.Location = new Point(680, 22);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(150, 36);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "▶ Iniciar juego";
            btnIniciar.Click += btnIniciar_Click;
            //
            // btnRegresar
            //
            btnRegresar.Location = new Point(840, 22);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(100, 36);
            btnRegresar.TabIndex = 1;
            btnRegresar.Text = "← Menú";
            btnRegresar.Click += btnRegresar_Click;
            //
            // lblPintados
            //
            lblPintados.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPintados.ForeColor = Color.FromArgb(39, 139, 84);
            lblPintados.Location = new Point(16, 90);
            lblPintados.Name = "lblPintados";
            lblPintados.Size = new Size(150, 26);
            lblPintados.Text = "Pintados: 0";
            //
            // lblTiempo
            //
            lblTiempo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTiempo.ForeColor = Color.FromArgb(24, 62, 111);
            lblTiempo.Location = new Point(170, 90);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(150, 26);
            lblTiempo.Text = "Tiempo: 00:00";
            //
            // lblSiguiente
            //
            lblSiguiente.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSiguiente.ForeColor = Color.FromArgb(192, 57, 43);
            lblSiguiente.Location = new Point(324, 90);
            lblSiguiente.Name = "lblSiguiente";
            lblSiguiente.Size = new Size(220, 26);
            lblSiguiente.Text = "Siguiente coche en: --";
            //
            // lblIntervalo
            //
            lblIntervalo.Font = new Font("Segoe UI", 11F);
            lblIntervalo.Location = new Point(548, 90);
            lblIntervalo.Name = "lblIntervalo";
            lblIntervalo.Size = new Size(170, 26);
            lblIntervalo.Text = "Llega uno cada 20 s";
            //
            // lblRecord
            //
            lblRecord.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRecord.ForeColor = Color.FromArgb(128, 64, 176);
            lblRecord.Location = new Point(720, 90);
            lblRecord.Name = "lblRecord";
            lblRecord.Size = new Size(224, 26);
            lblRecord.Text = "Récord: —";
            lblRecord.TextAlign = ContentAlignment.TopRight;
            //
            // pnlCola
            //
            pnlCola.BackColor = Color.FromArgb(62, 66, 75);
            pnlCola.Cursor = Cursors.Hand;
            pnlCola.Location = new Point(16, 122);
            pnlCola.Name = "pnlCola";
            pnlCola.Size = new Size(928, 240);
            pnlCola.Paint += pnlCola_Paint;
            pnlCola.MouseClick += pnlCola_MouseClick;
            //
            // lblInstruccion
            //
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInstruccion.ForeColor = Color.FromArgb(24, 62, 111);
            lblInstruccion.Location = new Point(16, 372);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Text = "1) Elige un color de la paleta   2) Haz clic en el PRIMER coche de la cola para pintarlo";
            //
            // flpPaleta
            //
            flpPaleta.Location = new Point(16, 398);
            flpPaleta.Name = "flpPaleta";
            flpPaleta.Size = new Size(700, 64);
            flpPaleta.TabIndex = 2;
            //
            // grpUltimo
            //
            grpUltimo.Controls.Add(picUltimo);
            grpUltimo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpUltimo.ForeColor = Color.FromArgb(24, 62, 111);
            grpUltimo.Location = new Point(730, 372);
            grpUltimo.Name = "grpUltimo";
            grpUltimo.Size = new Size(214, 140);
            grpUltimo.TabStop = false;
            grpUltimo.Text = "Último coche pintado";
            //
            // picUltimo
            //
            picUltimo.Location = new Point(12, 26);
            picUltimo.Name = "picUltimo";
            picUltimo.Size = new Size(190, 104);
            picUltimo.SizeMode = PictureBoxSizeMode.CenterImage;
            //
            // lblColorSeleccionado
            //
            lblColorSeleccionado.AutoSize = true;
            lblColorSeleccionado.Font = new Font("Segoe UI", 10F);
            lblColorSeleccionado.Location = new Point(52, 478);
            lblColorSeleccionado.Name = "lblColorSeleccionado";
            lblColorSeleccionado.Text = "Color seleccionado: ninguno";
            //
            // pnlMuestra
            //
            pnlMuestra.BackColor = Color.White;
            pnlMuestra.BorderStyle = BorderStyle.FixedSingle;
            pnlMuestra.Location = new Point(16, 474);
            pnlMuestra.Name = "pnlMuestra";
            pnlMuestra.Size = new Size(28, 28);
            //
            // lblMensaje
            //
            lblMensaje.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMensaje.Location = new Point(270, 474);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(446, 40);
            lblMensaje.Text = "Presiona \"Iniciar juego\" para comenzar.";
            //
            // tmrLlegada
            //
            tmrLlegada.Interval = 20000;
            tmrLlegada.Tick += tmrLlegada_Tick;
            //
            // tmrReloj
            //
            tmrReloj.Interval = 250;
            tmrReloj.Tick += tmrReloj_Tick;
            //
            // frmPintarCoches
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(960, 526);
            Controls.Add(lblMensaje);
            Controls.Add(pnlMuestra);
            Controls.Add(lblColorSeleccionado);
            Controls.Add(grpUltimo);
            Controls.Add(flpPaleta);
            Controls.Add(lblInstruccion);
            Controls.Add(pnlCola);
            Controls.Add(lblRecord);
            Controls.Add(lblIntervalo);
            Controls.Add(lblSiguiente);
            Controls.Add(lblTiempo);
            Controls.Add(lblPintados);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmPintarCoches";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 2 — Juego: pintar coches";
            FormClosing += frmPintarCoches_FormClosing;
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            grpUltimo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUltimo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Button btnIniciar;
        private Button btnRegresar;
        private Label lblPintados;
        private Label lblTiempo;
        private Label lblSiguiente;
        private Label lblIntervalo;
        private Label lblRecord;
        private PanelDoble pnlCola;
        private Label lblInstruccion;
        private FlowLayoutPanel flpPaleta;
        private GroupBox grpUltimo;
        private PictureBox picUltimo;
        private Label lblColorSeleccionado;
        private Panel pnlMuestra;
        private Label lblMensaje;
        private System.Windows.Forms.Timer tmrLlegada;
        private System.Windows.Forms.Timer tmrReloj;
    }
}
