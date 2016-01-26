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
        private Color color;

        public Label(GraphicsInfos graphics, SpriteFont font, Vector2 location, string text)
        {
            this.font = font;
            this.location = location;
            this.text = text;
            color = Color.White; //default color
        }

        public Label(GraphicsInfos graphics, SpriteFont font, Vector2 location, string text, Color color)
        {
            this.font = font;
            this.location = location;
            this.text = text;
            this.color = color;
        }

        public void ApplyPercentage(Resolution resolution)
        {
            float w = (float)((float)resolution.width / 100);
            float h = (float)resolution.height / 100;

            location.X *= (int)w;
            location.Y *= (int)h;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, location, color);
        }
    }

    
}
