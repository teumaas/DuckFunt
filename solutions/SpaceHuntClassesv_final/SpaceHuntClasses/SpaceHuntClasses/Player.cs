using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    class Player
    {
        public int health;
        public int score;

        public Player()
        {

            score = 0;
        }

        public void AddPoint(int point)
        {
            score += point;
        }
    }
}
