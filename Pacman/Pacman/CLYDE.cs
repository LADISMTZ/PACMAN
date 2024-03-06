using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class CLYDE: GHOST
    {

        public CLYDE()
        {
            ghostColor = Color.Orange;
        }

        public void decideMove(PACMAN theEnemy, float x, float y, MAP map)
        {



            if (dead)
            {

                state = "dead";

                if (theEnemy.pState == "super")
                {


                    map.level[14, 19] = 'C';
                    gx = 19;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    //MoveWhenDead(theEnemy, x, y, map, 'R');

                }//end while
                else
                {

                    dead = false;
                    state = "";

                }//end else                

            }//end if


            switch (state)
            {
                case "none":
                    if (timeOfState >= 200)
                    {
                        targetX = x;
                        targetY = y - 3;
                        FollowTarget(map, x, y, 'C', theEnemy);
                    }
                    if (timeOfState >= 300)
                    {
                        state = "explore";
                    }
                    break;
                case "explore":
                    MoveWhenExploring(theEnemy, x, y, map);
                    break;
                case "hunt":
                    MoveWhenHunt(theEnemy, x, y, map);
                    break;
                case "escape":
                    MoveWhenEscape(theEnemy, x, y, map, 'C');
                    break;
                case "dead":

                    
                    break;

            }
        }
        public void MoveWhenHunt(PACMAN theEnemy, float x, float y, MAP map)
        {
            //use x and y and not px and py so the target remain more time static rather than changing each TICK
            double distanceToPacman = Math.Sqrt(Math.Pow(theEnemy.x-this.x,2)+ Math.Pow(theEnemy.y - this.y, 2));
            if (distanceToPacman <= 8)
            {
                targetX = theEnemy.x;
                targetY = theEnemy.y;
            }
            else 
            {
                targetX = 0;
                targetY = 50;
            }
            FollowTarget(map, x, y, 'C', theEnemy);

        }

        public void MoveWhenExploring(PACMAN theEnemy, float x, float y, MAP map)
        {
            targetX = 0;
            targetY = 50;
            FollowTarget(map, x, y, 'C', theEnemy);

        }

        public void revive(MAP map, PACMAN theEnemy)
        {
            map.level[14, 19] = 'C';
            gx = 19;
            gy = 14;
        }
    }
}
