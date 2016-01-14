using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    public class ShapeAnimated : Shape
    {
        private Rectangle sourceRectangle;


        public ShapeAnimated(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle) : base(graphics, rectangle)
        {
            ScaleWithoutPercentage(graphics.resolution);
            sourceRectangle = new Rectangle(0, 0, rectangle.Width, rectangle.Height);
        }

        public override void ApplyPercentage(GraphicsInfos graphics)
        {
            int w = graphics.resolution.width / 100;
            int h = graphics.resolution.height / 100;

            rectangle.X = w * rectangle.X;
            rectangle.Y = h * rectangle.Y;
            rectangle.Width = h * rectangle.Width;
            rectangle.Height = h * rectangle.Height;
        }

        public void NextClip()
        {
            if (sourceRectangle.X + sourceRectangle.Width >= texture.Width)
            {
                sourceRectangle.X += sourceRectangle.Width;
            }
            else
            {
                sourceRectangle.X = 0;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }

    }
}
