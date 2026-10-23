namespace PracticaColas;

internal static class Program
{
    /// <summary>
    /// Punto de entrada: abre el menú principal con los tres ejercicios de colas.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.ThreadException += (_, e) =>
            MessageBox.Show("Ocurrió un error inesperado:\n" + e.Exception.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        Application.Run(new frmMenu());
    }
}
