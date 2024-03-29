﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    public class ShapeSource : Shape
    {
        public Rectangle sourceRectangle;


        public ShapeSource(GraphicsInfos graphics, Texture2D texture, Rectangle percentage)
            : base(graphics, texture, percentage)
        {
            sourceRectangle = new Rectangle(0, 0, rectangle.Width, 0);
        }


        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, sourceRectangle.Width, sourceRectangle.Height), sourceRectangle, Color.White);
        }
    }
}
