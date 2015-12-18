using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt.Classes
{
    public class ShapeAnimated : Shape
    {
        private Rectangle sourceRectangle;
        private Action action;
        private int maxX, maxY;

        public ShapeAnimated(Texture2D texture, Rectangle rectangle, Rectangle sourceRectangle, int maxX, int maxY, Action action)
            : base(texture, rectangle)
        {
            this.sourceRectangle = sourceRectangle;
            this.action = action;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public void NextClip()
        {
            if (sourceRectangle.X + sourceRectangle.Width != maxX)
                sourceRectangle.X += sourceRectangle.Width;
            else
            {
                sourceRectangle.X = 0;
                action();
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }
    }
}
