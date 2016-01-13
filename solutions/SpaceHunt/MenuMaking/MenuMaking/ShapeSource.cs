using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    public class ShapeSource
    {
        public Rectangle sourceRectangle;


        public ShapeSource(Texture2D texture, Rectangle rectangle, Rectangle sourceRectangle)
        {
            this.sourceRectangle = sourceRectangle;
        }


        //public override void Draw(SpriteBatch batch)
        //{
        //    batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        //}
    }
}
