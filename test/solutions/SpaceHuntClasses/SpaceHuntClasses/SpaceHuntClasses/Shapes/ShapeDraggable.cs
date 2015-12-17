using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    class ShapeDraggable : ShapeInteractive
    {
        private Rectangle limits;


        public ShapeDraggable(Texture2D texture, Rectangle rectangle, Rectangle limits) : base(texture, rectangle)
        {
            this.limits = limits;
        }

        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            base.Update(gameTime, mouseState);

            if(state == InteractionState.Down)
            {
                if(mouseState.X >= limits.X && mouseState.X < limits.X + limits.Width && mouseState.Y > limits.Y && mouseState.Y < limits.Y + limits.Height)
                {
                    rectangle.X = mouseState.X;
                    rectangle.Y = mouseState.Y;
                }
            }
        }
    }
}
