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


        public Shape(GraphicsInfos graphics, Rectangle rectangle)
        {
            this.rectangle = rectangle;
            ApplyPercentage(graphics);
        }

        public Shape(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            ApplyPercentage(graphics);
        }

        public virtual void ApplyPercentage(GraphicsInfos graphics)
        {
            float w = (float)((float)graphics.resolution.width / 100);
            float h = (float)graphics.resolution.height / 100;

            rectangle.X *= (int)w;
            rectangle.Y *= (int)h;

            if (texture != null)
            {
                int h2 = 1080 / graphics.resolution.height;
                rectangle.Width = texture.Width / h2;
                rectangle.Height = texture.Height / h2;
            }
            else
            {
                rectangle.Width *= (int)h;
                rectangle.Height *= (int)h;
            }
        }


        public virtual void ScaleWithoutPercentage(Resolution resolution)
        {
            int w = 1920 / resolution.width;
            int h = 1080 / resolution.height;

            rectangle.X /= w;
            rectangle.Y /= h;

            rectangle.Width /= w;
            rectangle.Height /= h;
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
