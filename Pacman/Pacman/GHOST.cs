using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class GHOST
    {
        private Random rand;
        private SolidBrush b;
        public string state;
        //explore,hunt,scape,dead
        private int pk = 0;
        protected float gx;
        protected float gy;
        public bool dead;
        private float speedX, speedY;
        public float x, y;
        private int dirX, dirY;
        private char ghostedSpace;
        protected float targetX, targetY;
        string prevPrevMove;
        string prevMove;
        String optimumMove;
        protected int timeOfState;
        protected Color ghostColor;
        public GHOST()
        {
            rand = new Random();
            state = "none";
            gx = 0;
            gy = 0;
            x = 0;
            y = 0;
            speedX = 0f;
            speedY = 0f;
            dirX = 1;
            dirY = 1;
            targetX = 0;
            targetY = 0;
            ghostedSpace = '1';
            timeOfState = 0;
            dead = false;
        } //GHOST

        public void Anim(Graphics g, float x, float y, int cntT, int sqr)
        {

            
            if (rand == null)
                rand = new Random();
            if (state == ("escape"))
                b = new SolidBrush(Color.Green);
            else
                b = new SolidBrush(ghostColor);

            //Body of ghost
            if (state!="dead")
            {
                //Body
                g.FillEllipse(b, (x * sqr), (y * sqr), sqr, sqr); // Cuerpo del loro




                // Dibujo de la cabeza del loro
                int headWidth = sqr * 3 / 5; // Ancho de la cabeza
                int headHeight = sqr * 3 / 5; // Altura de la cabeza
                int headOffsetX = sqr / 6; // Desplazamiento horizontal de la cabeza
                int headOffsetY = sqr / 4; // Desplazamiento vertical de la cabeza

                GraphicsPath headPath = new GraphicsPath();
                headPath.AddEllipse((x * sqr) + headOffsetX, (y * sqr) - headHeight / 2 + headOffsetY, headWidth, headHeight);
                g.FillPath(b, headPath);






                // Beak
                Point[] beakPoints = {
    new Point((int)(x * sqr) + (sqr / 2), (int)(y * sqr) + (sqr / 2)), // Punto inicial (parte superior del pico)
    new Point((int)(x * sqr) + (3 * sqr / 4), (int)(y * sqr) + (sqr * 3 / 4)), // Punto medio (parte inferior derecha del pico)
    new Point((int)(x * sqr) + (sqr / 2), (int)(y * sqr) + (sqr / 2) + 16) // Punto final (parte inferior izquierda del pico)
};

                // Rellenar el pico con un color naranja
                g.FillPolygon(Brushes.Orange, beakPoints);

                // Detalles del pico
                g.DrawLine(Pens.Black, beakPoints[0], beakPoints[1]); // Línea superior del pico
                g.DrawLine(Pens.Black, beakPoints[1], beakPoints[2]); // Línea lateral 




                // Eyes
                int eyeSize = sqr / 5; // Tamaño de los ojos
                int eyeOffsetX = sqr / 4; // Desplazamiento horizontal de los ojos
                int eyeOffsetY = sqr / 4; // Desplazamiento vertical de los ojo

                if ((cntT + rand.Next(1, 17) % 11) == 0)
                {

                    g.FillEllipse(Brushes.White, (x * sqr) + eyeOffsetX, (y * sqr) + eyeOffsetY, eyeSize, eyeSize); // Ojo izquierdo
                    g.FillEllipse(Brushes.White, (x * sqr) + sqr - eyeSize - eyeOffsetX, (y * sqr) + eyeOffsetY, eyeSize, eyeSize); // Ojo derecho
                }
                else
                {

                    g.FillEllipse(Brushes.White, (x * sqr) + eyeOffsetX, (y * sqr) + eyeOffsetY, eyeSize, eyeSize);
                    g.FillEllipse(Brushes.White, (x * sqr) + sqr - eyeSize - eyeOffsetX, (y * sqr) + eyeOffsetY, eyeSize, eyeSize);


                    g.FillEllipse(Brushes.Black, (x * sqr) + sqr - eyeSize / 2 - eyeOffsetX, (y * sqr) + eyeSize / 2 + eyeOffsetY, eyeSize / 2, eyeSize / 2);
                    g.FillEllipse(Brushes.Black, (x * sqr) + eyeSize / 2 + eyeOffsetX, (y * sqr) + eyeSize / 2 + eyeOffsetY, eyeSize / 2, eyeSize / 2);
                }


                //Tail
                Point[] tailPoints = {
                    new Point((int)(x * sqr) + (sqr / 2), (int)(y * sqr) + (sqr / 2)), // Punto de inicio de la cola
                    new Point((int)(x * sqr) - (sqr / 5), (int)(y * sqr) + (3 * sqr / 4)), // Punto intermedio de la cola
                    new Point((int)(x * sqr) + (sqr / 2), (int)(y * sqr) + sqr) // Punto final de la cola
                };
                g.FillPolygon(b, tailPoints); // Dibujamos la cola
            }//END IF

            

            if(state=="dead")
            {

                if ((cntT + rand.Next(1, 17) % 11) == 0)
                {
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
                }//END IF
                else
                {
                    g.FillEllipse(Brushes.Linen, (x * sqr) + 10, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Black, (x * sqr) + 14, (y * sqr) + 8, sqr - 15, sqr - 22);

                    g.FillEllipse(Brushes.Linen, (x * sqr) + 2, (y * sqr) + 2, sqr - 12, sqr - 12);
                    g.FillEllipse(Brushes.Black, (x * sqr) + 6, (y * sqr) + 8, sqr - 18, sqr - 22);

                }//END ELSE

            }//end if

        }//END ANIM

        public void checkPacmanState(PACMAN pacman)
        {
            timeOfState++;
            if (this.state != "none")
            {
                if (pacman.pState == ("normal"))
                {
                    if (timeOfState < 300)
                    {
                        this.state = "explore";
                    }
                    else
                    {
                        this.state = "hunt";
                    }
                }
                else if (pacman.pState == ("super"))
                {

                    this.state = "escape";
                }
                else
                {
                    this.state = "explore";
                }

                if (timeOfState >= 1200)
                {
                    timeOfState = 0;
                }
            }
            

        }

        /*
        public void waitForRevive(PACMAN theEnemy, MAP map, char ghost)
        {



               state = "dead";

                if (theEnemy.pState == "super")
                {

                    MoveWhenDead(theEnemy, x, y, map, ghost);

                }//end while
                else
                {

                    dead = false;

                }//end else                



        }//end waitForRevive
        */

        public void revive(PACMAN theEnemy, MAP map,char ghost, float x, float y)
        {

            
            switch(ghost)
            {

                case 'R':
                    map.level[14, 19] = ghost;
                    gx = 19;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    break;

                case 'G':
                    map.level[14, 18] = ghost;
                    gx = 18;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    break;

                case 'I':
                    map.level[14, 20] = ghost;
                    gx = 20;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    break;

                case 'C':
                    map.level[14, 21] = ghost;
                    gx = 21;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    break;

            }//end switch

        }
        /*public void MoveWhenDead(PACMAN theEnemy, float x, float y, MAP map,char ghost)
        {
            //use x and y and not px and py so the target remain more time static rather than changing each TICK

            if(dead)
            {

                //waitForRevive(theEnemy, map, ghost);
                revive(theEnemy, map, ghost, x, y);

            }//end if
            

        }*/

        public void MoveWhenEscape(PACMAN pacman,float x, float y, MAP map, char ghost)
        {

            //get best tile option based on rand
            string nextMove = getRandomTile(x, y, map);
            //define direcition
            switch (nextMove)
            {
                case "right":
                    speedX = 0.27f;
                    speedY = 0;
                    break;
                case "left":
                    speedX = -0.27f;
                    speedY = 0;
                    break;

                case "down":
                    speedX = 0;
                    speedY = 0.27f;
                    break;

                case "up":
                    speedX = 0;
                    speedY = -0.27f;
                    break;

            }
            //update position
            float xDisplacement = speedX * (float)Math.Cos(dirX);
            float yDisplacement = speedY * (float)Math.Sin(dirY);

            gx = (gx + xDisplacement);
            gy = (gy + yDisplacement);

           
            map.level[(int)y, (int)x] = ghostedSpace;
            ghostedSpace = map.level[(int)gy, (int)gx];
            map.level[(int)gy, (int)gx] = ghost;
            this.x = (int)gx; this.y = (int)gy;
            checkPassedSpace(map, pacman, ghost, x, y);

        }

        private string getRandomTile(float x, float y, MAP map)
        {

            

            Random rand = new Random();
            List <String> possibleMoves = new List<String>();
            int[,] nextTile = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            String[] moves = { "right", "down", "left", "up" };
            //get which is the speed that is not 0 and sign so its not considered
            int skip = getSpeedVector();
            for (int i = 0; i < 4; i++)
            {
                if (i == skip)
                {
                    continue;
                }
                //check if it can move to that Tile
                if (checkIfCanEscape(x, y, nextTile[i, 0], nextTile[i, 1], map, i))
                {              


                    possibleMoves.Add(moves[i]);

                }
            }//end for
            if (possibleMoves.Count>0)
            {
                return possibleMoves[rand.Next(0, possibleMoves.Count)];
            }
            return prevMove;

        }

        public void FollowTarget(MAP map, float x, float y, char charGhost, PACMAN pacman)
        {
            //initialize ghost position
            if (gx == 0 && gy == 0)
            {
                gx = x; gy = y;
            }
            //get best tile option based on linear distance to taget
            string optimumMove = getOptimumTile(x,y,map,charGhost);
            //define direcition
            switch (optimumMove)
            {
                case "right":
                    speedX = 0.27f;
                    speedY = 0;
                    break;
                case "left":
                    speedX = -0.27f;
                    speedY = 0;
                    break;

                case "down":
                    speedX = 0;
                    speedY = 0.27f;
                    break;

                case "up":
                    speedX = 0;
                    speedY = -0.27f;
                    break;

            }
            //update position
            float xDisplacement = speedX * (float)Math.Cos(dirX);
            float yDisplacement = speedY * (float)Math.Sin(dirY);

                gx = (gx + xDisplacement);
                gy = (gy + yDisplacement);

                map.level[(int)y, (int)x] = ghostedSpace;
                ghostedSpace = map.level[(int)gy, (int)gx];
                map.level[(int)gy, (int)gx] = charGhost;
                this.x = (int)gx; this.y = (int)gy;
            checkPassedSpace(map,pacman,charGhost, x, y);

        } //end Move

        private void checkPassedSpace(MAP map, PACMAN pacman, char charGhost, float x, float y)
        {
            if (state == "escape")
            {

                if (gx==pacman.x && gy==pacman.y)
                {
                    state = "dead";
                    dead = true;
                    //map.level[(int)y, (int)x] = charGhost;

                }

            }
            else
            {
                if (state != "dead")
                {
                    if (x == pacman.x && y == pacman.y)
                    {
                        pacman.pState = "dead";
                    }

                }
            }
        }

        private String getOptimumTile(float x,float y, MAP map, char ghostChar)
        {
            optimumMove = "none";
            int possibleMoves = 0;
            int[,] nextTile = { { 1, 0 }, { 0, 1 }, { -1, 0 },  { 0, -1 } };
            String[] moves = { "right", "down", "left",  "up" };
            double min = 1000000000;
            //get which is the speed that is not 0 and sign so its not considered
            int skip = getSpeedVector();
            for (int i = 0; i < 4; i++)
            {
                if (ghostChar == 'R' || ghostChar == 'I')
                {
                    if (speedY == 0.27f)
                    {
                        prevPrevMove = "down";
                    }
                    //ignore left
                    if (speedX == 0.27f)
                    {
                        prevPrevMove = "right";
                    }
                    //ignore down
                    if (speedY == -0.27f)
                    {
                        prevPrevMove = "up";
                    }
                    //ignore right
                    if (speedX == -0.27f)
                    {

                        prevPrevMove = "left";

                    }//end if
                }
                
                //check if it can move to that Tile
                if (CheckIfCanMove(x, y, nextTile[i, 0], nextTile[i, 1], map,i))
                {
                    possibleMoves++;
                    
                        double xDistanceSquare = Math.Pow((targetX - (x + (nextTile[i, 0]))), 2);
                        double yDistanceSquare = Math.Pow((targetY - (y + (nextTile[i, 1]))), 2);
                        //calculate pithagoras 
                        double linearDistanceToTarget = Math.Sqrt(xDistanceSquare + yDistanceSquare);
                        //get min 
                        if (linearDistanceToTarget <= min)
                        {
                            min = linearDistanceToTarget;

                        if (prevPrevMove != optimumMove)
                        {

                            prevMove = prevPrevMove;

                        }//end if

                        optimumMove = moves[i];
                        }
                    
                }//end if

            }//end for
            return optimumMove;    
            
        }

        private int getSpeedVector()
        {
            //ignore up
            if (speedY== 0.27f)
            {
                return 3;
            }
            //ignore left
            if (speedX== 0.27f)
            {
                return 2;
            }
            //ignore down
            if (speedY==-0.27f)
            {
                return 1;
            }
            //ignore right
            return 0;
        }
        private bool CheckIfCanMove(float x, float y, int xAdd, int yAdd, MAP map, int blockedDirection)
        {
            //check if the next position will be a block
            if (map.level[(int)y + yAdd, (int)x + xAdd] == ('*') || blockedDirection==getSpeedVector() || optimumMove == prevMove)
            {
                return false;
            }
            if (map.level[(int)y + yAdd, (int)x + xAdd] == ('4') && state!="none")
            {
                return false;
            }
            return true;
        } //end checkIfCanMmove

        private bool checkIfCanEscape(float x, float y, int xAdd, int yAdd, MAP map, int blockedDirection)
        {
            //check if the next position will be a block
            if (map.level[(int)y + yAdd, (int)x + xAdd] == ('*') || blockedDirection == getSpeedVector())
            {
                return false;
            }
            if (map.level[(int)y + yAdd, (int)x + xAdd] == ('4') && state != "none")
            {
                return false;
            }
            return true;
        } //end checkIfCanMmove


    }//END CLASS
}
