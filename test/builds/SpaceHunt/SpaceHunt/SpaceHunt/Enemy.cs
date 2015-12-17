using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    class Enemy : Actor
    {
        int health;
        float velocity;
        InteractiveShape ufoInteractiveShape;
        AnimatedShape ufoDeadAnimatedShape, alienAnimatedShape;

        public Enemy()
        {

        }

    }
}
