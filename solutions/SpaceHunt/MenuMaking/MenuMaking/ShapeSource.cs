using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt.Shapes
{
    public class ShapeSource : Shape
    {
        public Rectangle sourceRectangle;


        public ShapeSource(Texture2D texture, Rectangle rectangle, Rectangle sourceRectangle)
            : base(texture, rectangle)
        {
            this.sourceRectangle = sourceRectangle;
        }


        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }
    }
}
