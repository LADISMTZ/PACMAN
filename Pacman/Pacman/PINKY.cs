using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class PINKY: GHOST
    {

        static public string state2;
        public PINKY ()
        {
            ghostColor = Color.Pink;
            
        }

        public void decideMove(PACMAN theEnemy, float x, float y, MAP map)
        {


            state2 = state;



            if (dead)
            {

                state = "dead";

                if (theEnemy.pState == "super")
                {

                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    map.level[14, 20] = 'R';
                    gx = 20;
                    gy = 14;

                }//end if
                else
                {

                    dead = false;
                    state = "";

                }//end else                

            }//end if


            switch (state)
            {
                case "none":
                    if (timeOfState >= 100)
                    {
                        targetX = x;
                        targetY = y - 3;
                        FollowTarget(map, x, y, 'R', theEnemy);
                    }
                    if (timeOfState >= 200)
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
                    MoveWhenEscape(theEnemy, x, y, map, 'R');
                    break;
                case "dead":
                    
                    
                    break;

            }
        }
        public void MoveWhenHunt(PACMAN theEnemy, float x, float y, MAP map)
        {
            //get the target by adding 4 tiles ahead of pacman position
            switch (theEnemy.direction)
            {
                case "right":
                    targetX = theEnemy.x+4;
                    targetY = theEnemy.y;
                    break;
                case "left":
                    targetX = theEnemy.x-4;
                    targetY = theEnemy.y;
                    break;

                case "down":
                    targetX = theEnemy.x;
                    targetY = theEnemy.y+4;
                    break;

                case "up":
                    targetX = theEnemy.x;
                    targetY = theEnemy.y-4;
                    break;

            }
            
            FollowTarget(map, x, y, 'R', theEnemy);

        }

        public void MoveWhenExploring(PACMAN theEnemy, float x, float y, MAP map)
        {
            targetX = 0;
            targetY = 0;
            FollowTarget(map, x, y, 'R',theEnemy);

        }

        public void revive(MAP map, PACMAN theEnemy)
        {
            map.level[14, 20] = 'R';
            gx = 20;
            gy = 14;
        }
    }
}
