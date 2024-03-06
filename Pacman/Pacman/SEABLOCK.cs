using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class SEABLOCK
    {
        public SEABLOCK() { }

        public static void DrawBrick(Graphics g, int x, int y, int esc)
        {
            // Colores para simular la textura del mar
            Color color1 = Color.FromArgb(0, 119, 190); // Azul oscuro
            Color color2 = Color.FromArgb(0, 161, 255); // Azul medio
            Color color3 = Color.FromArgb(173, 216, 230); // Azul claro

            // Relleno con patrones para simular la textura del mar
            SolidBrush brush1 = new SolidBrush(color1);
            SolidBrush brush2 = new SolidBrush(color2);
            SolidBrush brush3 = new SolidBrush(color3);

            // Dibujar el ladrillo
            g.FillRectangle(brush1, x * esc, y * esc, esc, esc);
            g.FillRectangle(brush2, (x * esc) + esc / 4, (y * esc) + esc / 4, esc / 2, esc / 2);
            g.FillRectangle(brush3, (x * esc) + esc / 8, (y * esc) + esc / 8, esc / 4, esc / 4);

            // Borde del ladrillo
            Pen pen = Pens.Black;
            g.DrawRectangle(pen, x * esc, y * esc, esc, esc);
        }
    }
}
