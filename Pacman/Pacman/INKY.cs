using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    internal class INKY : GHOST
    {
        public INKY()
        {
            ghostColor = Color.Turquoise;
        }
        public void decideMove(PACMAN theEnemy, BLINKY blinky, float x, float y, MAP map)
        {



            if (dead)
            {

                state = "dead";

                if (theEnemy.pState == "super")
                {


                    map.level[14, 21] = 'I';
                    gx = 21;
                    gy = 14;
                    map.level[(int)theEnemy.y, (int)theEnemy.x] = 'P';
                    //MoveWhenDead(theEnemy, x, y, map, 'R');

                }//end while
                else
                {

                    dead= false;
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
                        FollowTarget(map, x, y, 'I', theEnemy);
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
                    MoveWhenHunt(theEnemy,blinky, x, y, map);
                    break;
                case "escape":
                    MoveWhenEscape(theEnemy, x, y, map, 'I');
                    break;
                case "dead":
                    //state = "hunt";
                    break;

            }
        }

        public void MoveWhenHunt(PACMAN theEnemy, BLINKY blinky, float x, float y, MAP map)
        {
            float twoAheadOfPacmanX = 0;
            float twoAheadOfPacmanY = 0;
            float toBlinkyX, toBlinkyY;
            //get the tile 2 tiles ahead of pacman position
            switch (theEnemy.direction)
            {
                case "right":
                    twoAheadOfPacmanX = theEnemy.x + 2;
                    twoAheadOfPacmanY = theEnemy.y;
                    break;
                case "left":
                    twoAheadOfPacmanX = theEnemy.x - 2;
                    twoAheadOfPacmanY = theEnemy.y;
                    break;

                case "down":
                    twoAheadOfPacmanX = theEnemy.x;
                    twoAheadOfPacmanY = theEnemy.y + 2;
                    break;

                case "up":
                    twoAheadOfPacmanX = theEnemy.x;
                    twoAheadOfPacmanY = theEnemy.y - 2;
                    break;

            }
            toBlinkyX = twoAheadOfPacmanX - blinky.x;
            toBlinkyY = twoAheadOfPacmanY - blinky.y;
            targetX = twoAheadOfPacmanX + toBlinkyX;
            targetY = twoAheadOfPacmanY+ toBlinkyY;
            FollowTarget(map, x, y, 'I', theEnemy);

        }
        public void MoveWhenExploring(PACMAN theEnemy, float x, float y, MAP map)
        {
            targetX = 40;
            targetY = 50;
            FollowTarget(map, x, y, 'I',theEnemy);

        }

        public void revive(MAP map, PACMAN theEnemy)
        {
            map.level[14, 21] = 'I';
            gx = 21;
            gy = 14;
            
        }

    }
}
