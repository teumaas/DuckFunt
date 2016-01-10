using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Labels
{
    class Label
    {
        protected SpriteFont font;
        protected Vector2 position;
        public string text { get; set; }

        public Label(SpriteFont font, Vector2 position, string text)
        {
            this.font = font;
            this.position = position;
            this.text = text;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, position, Color.Black);
        }
    }

    
}
