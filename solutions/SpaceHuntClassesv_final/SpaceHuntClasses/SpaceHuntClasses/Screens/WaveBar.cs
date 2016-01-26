using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Screens
{
    class WaveBar
    {
        private Rectangle rectangle;
        private Texture2D frameTexture;
        private Texture2D valueTexture;
        private Rectangle sourceRectangle;

        private int wave;

        public WaveBar(Vector2 position, Texture2D frameTexture, Texture2D valueTexture)
        {
            this.frameTexture = frameTexture;
            this.valueTexture = valueTexture;
            
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, frameTexture.Width, frameTexture.Height);

            wave = 1;
            sourceRectangle = new Rectangle(0, 0, rectangle.Width / 10, rectangle.Height);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(valueTexture, new Rectangle(rectangle.X, rectangle.Y, sourceRectangle.Width, rectangle.Height), sourceRectangle, Color.White);
            batch.Draw(frameTexture, rectangle, Color.White);
        }

        public void NewWave()
        {
            sourceRectangle.Width += rectangle.Width / 10;
        }
    }
}
