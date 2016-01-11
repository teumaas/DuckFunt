using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    public class Shape
    {
        protected Texture2D texture;
        public Rectangle rectangle;
        public Rectangle percentage;


        public Shape(GraphicsInfos graphics, Rectangle percentage)
        {
            this.percentage = percentage;
            Build(graphics.resolution);
        }

        public Shape(GraphicsInfos graphics, Texture2D texture, Rectangle percentage)
        {
            this.texture = texture;
            this.percentage = percentage;
            Build(graphics.resolution);
        }

        public virtual void Build(Resolution resolution)
        {
            int w = resolution.width / 100;
            int h = resolution.height / 100;
            rectangle.X = w * percentage.X;
            rectangle.Y = h * percentage.Y;
            rectangle.Width = h * percentage.Width;
            rectangle.Height = h * percentage.Height;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if(texture != null && rectangle != null)
                batch.Draw(texture, rectangle, Color.White);
        }

        public bool IsBuild()
        {
            return rectangle != null;
        }
        
    }
 
}
