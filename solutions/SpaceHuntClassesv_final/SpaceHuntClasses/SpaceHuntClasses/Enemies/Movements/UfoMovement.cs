using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Enemies.Movements
{
    class UfoMovement
    {
        private Vector2 startPosition;
        private Vector2 velocity;
        private Rectangle field;
        private Vector2 position;

        public UfoMovement(Rectangle enemiesField, Vector2 startPosition)
        {
            field = enemiesField;
            this.startPosition = startPosition;
            velocity = new Vector2(1, -2);
            position = startPosition;
        }

        public void Move()
        {
            if(position.X + velocity.X > 0 && position.X + velocity.X < field.Width)
            {
                position.X += velocity.X;
            }
            else
            {
                velocity.X *= -1;
            }

            if(position.Y + velocity.Y > 0 && position.Y + velocity.Y < field.Height)
            {
                position.Y += velocity.Y;
            }
            else
            {
                velocity.Y *= -1;
            }
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }
}
