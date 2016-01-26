using Microsoft.Xna.Framework;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Enemies
{
    class EnemyMovement
    {
        public Vector2 curLoc;
        private Random random;
        private Vector2 lastStartLoc;
        public Vector2 curVel;
        private Resolution resolution;
        private int moveInPx;
       
        public EnemyMovement(GraphicsInfos graphics, Vector2 startLoc)
        {
            random = new Random();
            this.resolution = graphics.resolution;
            moveInPx = RandomMovementLength();
            this.curLoc = startLoc;
        }

        public Vector2 Location()
        {
            return curLoc;
        }

        public void Update()
        {
            CheckBounds();

            //   if (moveInPx > 1)
            float tempDistX = curLoc.X - lastStartLoc.X;
            float tempDistY = curLoc.Y - lastStartLoc.Y;
            float dist = (float)Math.Sqrt(tempDistX * tempDistX + tempDistY * tempDistY);

            if (dist > moveInPx)
            {
                lastStartLoc = curLoc;
                curVel = RandomDirVel();
            }
            else
            {
                moveInPx = RandomMovementLength();
            }
           
        }
        
        //public void SetStartLoc(Vector2 startLoc) // Needs to be called before update
        //{
        //    curLoc = startLoc;
        //}

        Vector2 NewPos(Vector2 vel, Vector2 pos)
        {
            return pos + vel;
        }

        Vector2 RandomDirVel()
        {
            int degree = random.Next(1, 360);
            Vector2 temp = new Vector2((float)Math.Cos(degree), (float)Math.Sin(degree));
            curVel = temp;
            return temp;

        }

        private int RandomMovementLength()
        {
            return random.Next(20, 200);
        }

        //private bool RandomBool()
        //{
        //    int temp = random.Next(1, 2);
        //    if (temp == 1)
        //    {
        //        return true;
        //    }
        //    else if(temp == 2)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        private void CheckBounds()
        {
            if (curLoc.X > resolution.width || curLoc.Y > resolution.height || curLoc.X < 0 || curLoc.Y < 0)
            {
                RandomDirVel();
            }
        }
    }
}
