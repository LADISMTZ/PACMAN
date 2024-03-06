using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Pacman
{
    internal class CANVAS
    {
        Bitmap bmp;
        Graphics cgraphics;
        int escale = 20;
        int b, p, i, c;
        List<int> pinkys = new List<int>();
        
        BLINKY blinky;
        PINKY pinky;
        INKY inky;
        CLYDE clyde;

        public CANVAS(PictureBox pictureBox)
        {

            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            cgraphics = Graphics.FromImage(bmp);
            pictureBox.Image = bmp;

            
            blinky = new BLINKY();
            pinky = new PINKY();
            inky = new INKY();
            clyde = new CLYDE();
        }//end CANVAS


        public void drawMap(MAP map, int count, PACMAN pacman, Label ScoreLabel)
        {
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    cgraphics.FillRectangle(Brushes.Black, x * escale, y * escale, escale, escale);

                    switch (map.level[y, x])
                    {
                        case '1':


                            cgraphics.FillRectangle(Brushes.Black, x * escale, y * escale, escale, escale);
                            break;

                        case '3':


                            PILL.DrawPowerPill(cgraphics, x, y, escale, count);
                            break;

                        case '*':


                            BRICKS.DrawBrick(cgraphics, x, y, escale);
                            break;

                        case '2':


                            PILL.DrawPill(cgraphics, x, y, escale, count);
                            break;

                        case 'P':
                            
                            pacman.Anim(cgraphics, x, y, count, escale);
                            pacman.pacmanState(map, x, y, ScoreLabel, blinky, pinky, inky, clyde);

                            break;


                        case 'I':
                            inky.checkPacmanState(pacman);
                            inky.decideMove(pacman, blinky, x, y, map);
                            inky.Anim(cgraphics, x, y, count, escale);
                            
                            i++;
                            break;

                        case 'R':
                            pinky.checkPacmanState(pacman);
                            pinky.decideMove(pacman, x, y, map);
                            pinky.Anim(cgraphics, x, y, count, escale);
                            
                            //pinkys.Add(x); pinkys.Add(y);
                            p++;
                            break;

                        case 'G':
                            blinky.checkPacmanState(pacman);
                            blinky.decideMove(pacman, x, y, map);
                            blinky.Anim(cgraphics, x, y, count, escale);
                            
                            b++;
                            break;

                        
                        
                        case 'C':
                            clyde.checkPacmanState(pacman);
                            clyde.Anim(cgraphics, x, y, count, escale);
                            clyde.decideMove(pacman, x, y, map);
                            c++;
                            break;

                    }//end switch
                     //
                   


                }//end for
                

            }//end for
            if (pacman.checkWin)
            {
                if (i == 0)
                {
                    inky.revive(map, pacman);
                }
                if (p == 0)
                {
                    pinky.revive(map, pacman);
                }
                if (b == 0)
                {
                    blinky.revive(map, pacman);
                }
                if (c == 0)
                {
                    clyde.revive(map, pacman);
                }
                i = 0;
                p = 0;
                b = 0;
                c = 0;
            }
            

        }//end drawMap
    }//end class
}
