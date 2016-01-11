using Microsoft.Xna.Framework;
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


        public ShapeSource(GraphicsInfos graphics, Texture2D texture, Rectangle percentage, Rectangle sourceRectangle)
            : base(graphics, texture, percentage)
        {
            this.sourceRectangle = sourceRectangle;
        }


        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }
    }
}
