using System.Drawing;

namespace Library.Graphical
{
    public interface IPaintable
    {
        /// <summary>
        /// Paint the object on the given graphics object.
        /// </summary>
        /// <param name="g"></param>
        void Paint(Graphics g);
    }
}
