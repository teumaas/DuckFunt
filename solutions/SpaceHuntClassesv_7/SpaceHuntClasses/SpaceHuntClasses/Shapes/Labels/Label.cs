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
        private SpriteFont font;
        private Vector2 location;   
        public string text;

        public Label(GraphicsInfos graphics, SpriteFont font, Vector2 location, string text)
        {
            this.font = font;
            this.location = location;
            this.text = text;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, location, Color.White);
        }
    }

    
}
