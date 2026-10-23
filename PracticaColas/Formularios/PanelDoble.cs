namespace PracticaColas
{
    /// <summary>Panel con doble búfer para dibujar el juego sin parpadeo.</summary>
    public class PanelDoble : Panel
    {
        public PanelDoble()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}
