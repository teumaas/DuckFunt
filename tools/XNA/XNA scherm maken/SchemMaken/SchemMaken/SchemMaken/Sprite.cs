using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchemMaken
{
    public class Sprite
    {
        private Texture2D texture;
        private Vector2 position;
        private int width;
        private int height;

        public Sprite(Texture2D texture, Vector2 position, int width, int height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public void Move(int x, int y)
        {
            position.X += x;
            position.Y += y;
        }
        public void MoveToPosition(Vector2 nPosition)
        {
            position = nPosition;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), Color.White);
        }
    }
}
