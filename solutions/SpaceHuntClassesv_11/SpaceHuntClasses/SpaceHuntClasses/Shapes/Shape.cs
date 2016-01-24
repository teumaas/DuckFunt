using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Shapes;
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
        }

        public Shape(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle)

        {
            this.texture = texture;
            this.rectangle = rectangle;
        }

        public void ApplyPercentage(Resolution resolution)
        {
            ApplyPositionPercentage(resolution);
            ApplySizePercentage(resolution);
        }

        public void ApplyPositionPercentage(Resolution resolution)
        {
            float w = (float)((float)resolution.width / 100);
            float h = (float)resolution.height / 100;

            rectangle.X *= (int)w;
            rectangle.Y *= (int)h;
        }

        public void ApplySizePercentage(Resolution resolution)
        {
            float w = (float)((float)resolution.width / 100);
            float h = (float)resolution.height / 100;

            rectangle.Width = (int)(rectangle.Width * w);
            rectangle.Height = (int)(rectangle.Height * h);
        }

        public void ResizeWithTexture(Resolution resolution)
        {
            if (texture != null)
            {
                float h2 = 1080 / (float)resolution.height;
                rectangle.Width = (int)(texture.Width / h2);
                rectangle.Height = (int)(texture.Height / h2);
            }
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

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        
    }
 
}
