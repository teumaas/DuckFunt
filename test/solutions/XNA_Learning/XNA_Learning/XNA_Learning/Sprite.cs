using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Learning
{
    class Sprite
    {
        public Vector2 location;
        public Vector2 velocity;
        public Texture2D imgAvatar;
        public Rectangle bounds;
        public Color col = Color.White;

        public Sprite(Vector2 location, Texture2D imgAvatar)
        {
            this.location = location;
            this.imgAvatar = imgAvatar;
            bounds = new Rectangle(0, 0, 35, 58);
        }

        public void Update(float elapsed)
        {

            location += velocity * elapsed;

            bounds.X = (int)location.X;
            bounds.Y = (int)location.Y;

            if (bounds.Left < 0)
            {
                location.X = 0;
            }

            if (bounds.Top < 0)
            {
                location.Y = 0;
            }

            if (bounds.Right > 800)
            {
                location.X = 800 - bounds.Width;
            }

            if (bounds.Bottom > 900)
            {
                location.Y = 900 - bounds.Height;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(imgAvatar, location, col);
        }
    }
}
