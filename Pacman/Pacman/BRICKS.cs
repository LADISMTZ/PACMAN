using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class BRICKS
    {
        public BRICKS() { }

        //THIS FUNCTION DRAWS THE BRICKS
        public static void DrawBrick(Graphics g, int x, int y, int esc)
        {
            // Colores para simular la textura de roca vieja
            Color color1 = Color.FromArgb(160, 120, 80); // Marrón oscuro
            Color color2 = Color.FromArgb(180, 140, 100); // Marrón medio
            Color color3 = Color.FromArgb(200, 160, 120); // Marrón claro


            // Relleno con patrones para simular roca vieja
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
        }//end DrawBrick


    }//end BRICKS class
}
