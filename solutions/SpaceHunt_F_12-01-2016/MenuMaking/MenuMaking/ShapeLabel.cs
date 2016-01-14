using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    class ShapeLabel : Shape
    {
        private SpriteFont font;
        private string text;

        public ShapeLabel(Rectangle rectangle, SpriteFont font, string text) : base(rectangle)
        {
            this.text = text;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(font, text, new Vector2(rectangle.X, rectangle.Y), Color.Black);
        }
    }
}
