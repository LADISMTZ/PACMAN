using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class BLINKY: GHOST
    {
        public BLINKY()
        {
            ghostColor = Color.Red;
        }

        public void decideMove(PACMAN theEnemy, float x, float y, MAP map)
        {



            if (dead)
            {

                state = "dead";

                if (theEnemy.pState == "super")
                {


                    map.level[14, 18] = 'G';
                    gx = 18;
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
                    if (timeOfState>=0)
                    {
                        targetX = x;
                        targetY = y-3;
                        FollowTarget(map, x, y, 'G', theEnemy);
                    }
                    if (timeOfState >= 100)
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
                    MoveWhenEscape(theEnemy, x, y, map,'G');
                    break;
                case "dead":
                    
                    break;

            }
        }
        public void MoveWhenHunt(PACMAN theEnemy, float x, float y, MAP map)
        {
            //use x and y and not px and py so the target remain more time static rather than changing each TICK
            targetX = theEnemy.x;
            targetY = theEnemy.y;
            FollowTarget(map, x, y,'G',theEnemy);
              
        }
        
        public void MoveWhenExploring(PACMAN theEnemy, float x, float y, MAP map)
        {
            targetX = 40;
            targetY = 0;
            FollowTarget(map, x, y,'G', theEnemy);

        }
        public void revive(MAP map, PACMAN theEnemy)
        {
            map.level[14, 18] = 'G';
            gx = 18;
            gy = 14;
        }
    }


}
