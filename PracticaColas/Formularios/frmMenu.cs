namespace PracticaColas
{
    /// <summary>Menú principal: abre cada ejercicio y regresa aquí al cerrarlo.</summary>
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            EstilizarOpcion(btnBanco, Dibujos.CrearIconoBanco(40, Tema.Primario));
            EstilizarOpcion(btnPintarCoches, Dibujos.CrearCoche(52, 36, ColorPintura.Paleta[0].Valor));
            EstilizarOpcion(btnEstacionamiento, Dibujos.CrearIconoLetra(40, "P", Tema.Secundario));
            EstilizarOpcion(btnSalir, Dibujos.CrearIconoLetra(40, "×", Tema.Peligro));
        }

        private static void EstilizarOpcion(Button boton, Image icono)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderColor = Color.FromArgb(200, 212, 228);
            boton.FlatAppearance.MouseOverBackColor = Color.FromArgb(225, 236, 248);
            boton.BackColor = Color.White;
            boton.ForeColor = Tema.Primario;
            boton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
            boton.Image = icono;
            boton.ImageAlign = ContentAlignment.MiddleLeft;
            boton.TextAlign = ContentAlignment.MiddleLeft;
            boton.TextImageRelation = TextImageRelation.ImageBeforeText;
            boton.Padding = new Padding(14, 0, 0, 0);
        }

        private void AbrirEjercicio(Form ejercicio)
        {
            Hide();
            using (ejercicio)
                ejercicio.ShowDialog();
            Show();
            Activate();
        }

        private void btnBanco_Click(object? sender, EventArgs e) => AbrirEjercicio(new frmBanco());

        private void btnPintarCoches_Click(object? sender, EventArgs e) => AbrirEjercicio(new frmPintarCoches());

        private void btnEstacionamiento_Click(object? sender, EventArgs e) => AbrirEjercicio(new frmEstacionamiento());

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Deseas salir de la aplicación?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                Close();
        }
    }
}
