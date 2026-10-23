namespace PracticaColas;

/// <summary>Colores y estilos compartidos por todos los formularios.</summary>
public static class Tema
{
    public static readonly Color Primario = Color.FromArgb(24, 62, 111);
    public static readonly Color Secundario = Color.FromArgb(46, 125, 195);
    public static readonly Color Fondo = Color.FromArgb(240, 244, 249);
    public static readonly Color Exito = Color.FromArgb(39, 139, 84);
    public static readonly Color Peligro = Color.FromArgb(192, 57, 43);
    public static readonly Color Neutro = Color.FromArgb(96, 108, 128);

    public static void EstilizarBoton(Button boton, Color fondo)
    {
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.FlatAppearance.MouseOverBackColor = ControlPaint.Light(fondo, 0.2f);
        boton.BackColor = fondo;
        boton.ForeColor = Color.White;
        boton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        boton.Cursor = Cursors.Hand;
    }

    public static void EstilizarTabla(DataGridView tabla)
    {
        tabla.BackgroundColor = Color.White;
        tabla.BorderStyle = BorderStyle.FixedSingle;
        tabla.EnableHeadersVisualStyles = false;
        tabla.ColumnHeadersDefaultCellStyle.BackColor = Primario;
        tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        tabla.ColumnHeadersHeight = 32;
        tabla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        tabla.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
        tabla.DefaultCellStyle.SelectionBackColor = Color.FromArgb(207, 226, 243);
        tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
        tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
        tabla.RowTemplate.Height = 28;
        tabla.RowHeadersVisible = false;
        tabla.AllowUserToAddRows = false;
        tabla.AllowUserToDeleteRows = false;
        tabla.AllowUserToResizeRows = false;
        tabla.ReadOnly = true;
        tabla.MultiSelect = false;
        tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>Negro o blanco, el que se lea mejor sobre el color de fondo.</summary>
    public static Color ColorTextoSobre(Color fondo) =>
        (fondo.R * 299 + fondo.G * 587 + fondo.B * 114) / 1000 > 150 ? Color.Black : Color.White;
}
