using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    class Background
    {
        private Texture2D texture;
        private Rectangle rectangle;

        public Background(GraphicsInfos graphics, Texture2D texture)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
            
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, Color.White);
        }
    }
}
