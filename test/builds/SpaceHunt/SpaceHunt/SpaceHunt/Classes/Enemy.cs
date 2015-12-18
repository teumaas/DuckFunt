using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt.Classes
{
    public class Enemy : Actor
    {
        int health;
        float velocity;
        ShapeInteractive ufoShapeInteractive;
        ShapeAnimated ufoDeadShapeAnimated, alienShapeAnimated;

        public Enemy(int health, float velocity, ShapeInteractive ufoShapeInteractive, ShapeAnimated ufoDeadShapeAnimated, ShapeAnimated alienShapeAnimated)
        {
            this.health = health;
            this.velocity = velocity;
            this.ufoShapeInteractive = ufoShapeInteractive;
            this.ufoDeadShapeAnimated = ufoDeadShapeAnimated;
            this.alienShapeAnimated = alienShapeAnimated;
        }

    }
}
