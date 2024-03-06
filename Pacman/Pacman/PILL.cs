using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class PILL
    {
        static Random rand;

        public PILL() { }

        //THIS FUNCTION DRAWS THE PILL
        public static void DrawPill(Graphics g, int x, int y, int esc, int cntT)
        {
            if (rand == null)
                rand = new Random();

            if (((cntT + rand.Next(1, 5)) % 5) == 0)
            {
                g.FillEllipse(Brushes.Goldenrod, (x * esc) + 8, (y * esc) + 8, esc - 16, esc - 16);
            }//end if
            else
            {
                g.FillEllipse(Brushes.Gold, (x * esc) + 8, (y * esc) + 8, esc - 16, esc - 16);
                g.FillEllipse(Brushes.Goldenrod, (x * esc) + 10, (y * esc) + 10, esc - 20, esc - 20);

            }//end else

        }//end DrawPill


        //THIS FUNCTION DRAWS THE SUPERPILL
        public static void DrawPowerPill(Graphics g, int x, int y, int esc, int cntT)
        {

            if (rand == null);
            rand = new Random();

            if (((cntT + rand.Next(1, 5)) % 5) == 0)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(35, 200, 200, 180)), (x * esc), (y * esc), esc, esc);
                g.FillEllipse(Brushes.Yellow, (x * esc) + 3, (y * esc) + 3, esc - 6, esc - 6);
                g.FillEllipse(Brushes.Linen, (x * esc) + 5, (y * esc) + 5, esc - 10, esc - 10);
            }//end if

            else
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 200, 200, 180)), (x * esc), (y * esc), esc, esc);
                g.FillEllipse(Brushes.Orange, (x * esc) + 2, (y * esc) + 2, esc - 4, esc - 4);
                g.FillEllipse(new SolidBrush(Color.FromArgb(100, 100, 150, 180)), (x * esc) + 5, (y * esc) + 5, esc - 10, esc - 10);
            }//end else

        }//end DrawPowerPill
    }//end PILL class
}
