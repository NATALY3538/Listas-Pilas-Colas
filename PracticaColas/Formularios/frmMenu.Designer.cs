namespace PracticaColas
{
    partial class frmMenu
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
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            btnBanco = new Button();
            btnPintarCoches = new Button();
            btnEstacionamiento = new Button();
            btnSalir = new Button();
            lblPie = new Label();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            //
            // pnlEncabezado
            //
            pnlEncabezado.BackColor = Color.FromArgb(24, 62, 111);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(484, 96);
            pnlEncabezado.TabIndex = 0;
            //
            // lblTitulo
            //
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(28, 14);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "Práctica Unidad II · Colas";
            //
            // lblSubtitulo
            //
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 220, 240);
            lblSubtitulo.Location = new Point(31, 58);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Text = "Estructura de Datos — selecciona un ejercicio";
            //
            // btnBanco
            //
            btnBanco.Location = new Point(32, 120);
            btnBanco.Name = "btnBanco";
            btnBanco.Size = new Size(420, 62);
            btnBanco.TabIndex = 1;
            btnBanco.Text = "1. Ventanilla de un banco";
            btnBanco.Click += btnBanco_Click;
            //
            // btnPintarCoches
            //
            btnPintarCoches.Location = new Point(32, 194);
            btnPintarCoches.Name = "btnPintarCoches";
            btnPintarCoches.Size = new Size(420, 62);
            btnPintarCoches.TabIndex = 2;
            btnPintarCoches.Text = "2. Juego: pintar coches";
            btnPintarCoches.Click += btnPintarCoches_Click;
            //
            // btnEstacionamiento
            //
            btnEstacionamiento.Location = new Point(32, 268);
            btnEstacionamiento.Name = "btnEstacionamiento";
            btnEstacionamiento.Size = new Size(420, 62);
            btnEstacionamiento.TabIndex = 3;
            btnEstacionamiento.Text = "3. Estacionamiento para autos";
            btnEstacionamiento.Click += btnEstacionamiento_Click;
            //
            // btnSalir
            //
            btnSalir.Location = new Point(32, 342);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(420, 62);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "4. Salir";
            btnSalir.Click += btnSalir_Click;
            //
            // lblPie
            //
            lblPie.Font = new Font("Segoe UI", 8.5F);
            lblPie.ForeColor = Color.FromArgb(96, 108, 128);
            lblPie.Location = new Point(32, 418);
            lblPie.Name = "lblPie";
            lblPie.Size = new Size(420, 22);
            lblPie.Text = "Al cerrar cada ejercicio regresas a este menú.";
            lblPie.TextAlign = ContentAlignment.MiddleCenter;
            //
            // frmMenu
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(484, 452);
            Controls.Add(lblPie);
            Controls.Add(btnSalir);
            Controls.Add(btnEstacionamiento);
            Controls.Add(btnPintarCoches);
            Controls.Add(btnBanco);
            Controls.Add(pnlEncabezado);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Práctica de Colas — Menú principal";
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnBanco;
        private Button btnPintarCoches;
        private Button btnEstacionamiento;
        private Button btnSalir;
        private Label lblPie;
    }
}
