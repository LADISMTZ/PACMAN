using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
        internal class PACMAN
        {
            //render attributes
            private Random rand;
            private Bitmap frame;
            private Graphics pGraphics;
            private Rectangle areaOfRendering;
            public String direction;
            public float px;
            public float py;
            public float x;
            public float y;
            private float speedX,speedY;
            private int dirX,dirY;
            private int points;
            public string pState;
            private int superTimeRemaining;
            private int pillsCount;
            public bool checkWin;
            private char ghostedSpace;

        public PACMAN()
            {
                rand = new Random();
                direction = "up";
                frame = new Bitmap(20, 20);
                pGraphics = Graphics.FromImage(frame);
                areaOfRendering = new Rectangle(0, 0, 20, 20);
                px = 0;
                py = 0;
                x = 0;
                y = 0;
                speedX = 0f;
                speedY = 0f;
                dirX = 1;
                dirY = 1;
                points = 0;
                pState = "normal";
                pillsCount = 0;
                checkWin = false;
            ghostedSpace = '1';



        }// end PACMAN

            //setters
            public void setDirection(String keyDirection)
            { direction = keyDirection; } //end setDirection

            //Draw pacman
            public void Anim(Graphics cGraphics, float x, float y, int cntT, int sqr)
            {
                //set frame transparent  so the background can be seen
                pGraphics.Clear(Color.Transparent);

                //shape of pacman
                switch (cntT % 6)
                {
                    case 0:
                        pGraphics.FillEllipse(Brushes.Yellow, 0, 0, sqr, sqr);
                        break;
                    case 1:
                        pGraphics.FillEllipse(Brushes.Yellow, 0, 0, sqr, sqr);
                        break;
                    case 2:
                        pGraphics.FillPie(Brushes.Yellow, 0, 0, sqr, sqr, 30, 300);
                        break;
                    case 3:
                        pGraphics.FillPie(Brushes.Yellow, 0, 0, sqr, sqr, 45, 240);
                        break;
                    case 4:
                        pGraphics.FillPie(Brushes.Yellow, 0, 0, sqr, sqr, 30, 300);
                        break;
                    case 5:
                        pGraphics.FillEllipse(Brushes.Yellow, 0, 0, sqr, sqr);
                        break;

                }
                //eyes of pacman
                if (((cntT + rand.Next(0, 10)) % 6) == 0)
                {
                    pGraphics.FillRectangle(Brushes.Black, sqr / 2, 6, sqr - (4 * sqr / 5), 2);
                }
                else
                {
                    pGraphics.FillEllipse(Brushes.Black, sqr / 2, 4, sqr - (4 * sqr / 5), sqr - (4 * sqr / 5));
                }
                //set direction of pacman (actually the frame in which it is drawn) based on the keyboard
                switch (direction)
                {
                    case "left":

                        frame.RotateFlip(RotateFlipType.Rotate180FlipY);
                        break;

                    case "down":

                        frame.RotateFlip(RotateFlipType.Rotate270FlipY);
                        break;

                    case "up":

                        frame.RotateFlip(RotateFlipType.Rotate90FlipY);
                        break;

                }

                //draw pacman in map using graphics from canvas
                areaOfRendering = new Rectangle((int)x * sqr, (int)y * sqr, 20, 20);
                cGraphics.DrawImage(frame, areaOfRendering);
            }//end Anim



        public void pacmanState(MAP map, float x, float y, Label Score, BLINKY blinky, PINKY pinky, INKY inky, CLYDE clyde)
        {
            

            switch (pState)
            {


                case "normal":
                    Move(map, x, y, Score, blinky,  pinky,  inky,  clyde);
                    break;

                case "super":

                    superMove(map, x, y, Score,  blinky,  pinky,  inky,  clyde);
                    superTimeRemaining--;

                    if (superTimeRemaining <= 0)
                    {
                        pState = "normal";
                    }
                    break;

                case "dead":
                    for (int z = 0; z < map.level.GetLength(0); z++)
                    {
                        for (int r = 0; r < map.level.GetLength(1); r++)
                        {
                            map.level[z, r] = '*';
                        }

                    }

                    break;

                case "win":
                    for (int z = 0; z < map.level.GetLength(0); z++)
                    {
                        for (int r = 0; r < map.level.GetLength(1); r++)
                        {
                            map.level[z, r] = 'P';
                        }


                    }
                    break;


            }
        }




        //Pacman move with the super pill
        public void superMove(MAP map, float x, float y, Label Score, BLINKY blinky, PINKY pinky, INKY inky, CLYDE clyde)
        {
            if (px == 0 && py == 0)
            {
                px = x; py = y;
            }


            bool canMove = true;
            switch (direction)
            {
                case "right":
                    canMove = CheckTheNextSpace(px, py, 1, 0, map, blinky, pinky, inky, clyde);
                    speedX = 0.385f;
                    speedY = 0;
                    break;
                case "left":
                    canMove = CheckTheNextSpace(px, py, -1, 0, map, blinky, pinky, inky, clyde);
                    speedX = -0.4f;
                    speedY = 0;
                    break;

                case "down":
                    canMove = CheckTheNextSpace(px, py, 0, 1, map, blinky, pinky, inky, clyde);
                    speedX = 0;
                    speedY = 0.34f;
                    break;

                case "up":
                    canMove = CheckTheNextSpace(px, py, 0, -1, map, blinky, pinky, inky, clyde);
                    speedX = 0;
                    speedY = -0.4f;
                    break;
            }

                    if (canMove)
            {
                float xDisplacement = speedX * (float)Math.Cos(dirX);
                float yDisplacement = speedY * (float)Math.Sin(dirY);

                px = (px + xDisplacement);
                py = (py + yDisplacement);


                /*if (ghostedSpace == 'R')
                {                   
                    
                    map.level[(int)y, (int)x] = ghostedSpace;
                    

                }//end if
                else
                {

                    

                }//end else*/

                map.level[(int)y, (int)x] = '1';
                ghostedSpace = map.level[(int)py, (int)px];
                map.level[(int)py, (int)px] = 'P';
                this.x = (int)px; this.y = (int)py;

            }
            Score.Text = ("Score " + points.ToString());
            checkVictory(map);




        } //end Super Move

          //Move PACMAN and update MAP
        public void Move(MAP map, float x, float y, Label Score, BLINKY blinky, PINKY pinky, INKY inky, CLYDE clyde)
            {
                if (px == 0 && py == 0)
                { 
                    px = x; py = y;
                }
               

                bool canMove = true;
            switch (direction)
            {
                case "right":
                    canMove = CheckTheNextSpace(px, py, 1, 0, map,blinky,pinky,inky,clyde);
                    speedX = 0.339f;
                    speedY = 0;
                    break;
                case "left":
                    canMove = CheckTheNextSpace(px, py, -1, 0, map, blinky, pinky, inky, clyde);
                    speedX = -0.35f;
                    speedY = 0;
                    break;

                case "down":
                    canMove = CheckTheNextSpace(px, py, 0, 1, map, blinky, pinky, inky, clyde);
                    speedX = 0;
                    speedY = 0.29f;
                    break;

                case "up":
                    canMove = CheckTheNextSpace(px, py, 0, -1, map, blinky, pinky, inky, clyde);
                    speedX = 0;
                    speedY = -0.35f;
                    break;

            }

            if (canMove)
                {
                    float xDisplacement = speedX * (float)Math.Cos(dirX);
                    float yDisplacement = speedY * (float)Math.Sin(dirY);

                    px = (px + xDisplacement);
                    py = (py + yDisplacement);


                map.level[(int)y, (int)x] = '1';
                ghostedSpace = map.level[(int)py, (int)px];
                map.level[(int)py, (int)px] = 'P';
                    
                this.x = (int)px; this.y = (int)py;
            }
            Score.Text = ("Score " + points.ToString());
            checkVictory(map);


        } //end Move

        private bool CheckTheNextSpace(float x, float y, int xAdd, int yAdd, MAP map,BLINKY blinky,PINKY pinky,INKY inky, CLYDE clyde)
        {
        

                if (map.level[(int)y + yAdd, (int)x + xAdd] != ('*') && map.level[(int)y + yAdd, (int)x + xAdd] != ('4'))
                {
                    if (map.level[(int)y + yAdd, (int)x + xAdd] == ('2'))
                        {
                            points++;
                        }
                

                else  if (map.level[(int)y + yAdd, (int)x + xAdd] == ('3'))
                    {
                        points += 10;
                        superTimeRemaining = 200;//10 seconds aprox
                        pState = "super";
                    }

                    else if (map.level[(int)y + yAdd, (int)x + xAdd] == 'G'|| map.level[(int)y + yAdd, (int)x + xAdd] == 'C' || map.level[(int)y + yAdd, (int)x + xAdd] == 'I' || map.level[(int)y + yAdd, (int)x + xAdd] == 'R'|| map.level[(int)y, (int)x ] == 'G' || map.level[(int)y , (int)x ] == 'C' || map.level[(int)y , (int)x ] == 'I' || map.level[(int)y , (int)x ] == 'R')
                    {
                        if (pState == "normal")
                        {
                            pState = "dead";

                    }
                        else if (pState == "super")
                        {
                            points += 50;
                        switch (map.level[(int)y + yAdd, (int)x + xAdd])
                        {
                            case 'G':
                                blinky.dead= true; break;
                            case 'R':
                                pinky.dead= true; break;
                            case 'I':
                                inky.dead = true; break;
                            case 'C':
                                clyde.dead = true; break;
                        }
                                                       
                        }
                    }

                return true;
                }


                return false;

        } //end checkIfCanMmove



        public void checkVictory(MAP map)
        {
            pillsCount = 0;
            for (int y = 0; y < map.level.GetLength(0); y++)
            {
                for (int x = 0; x < map.level.GetLength(1); x++)
                {
                    if (map.level[y, x] == '2' || map.level[y, x] == '3') { pillsCount++; }

                }

            }

            if (pillsCount <= 0) { 
                checkWin = true;
                pState = "win";
            
            }
            

        }



    }//end Class
    
}
