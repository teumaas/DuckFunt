using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    class ButtonMenu : ButtonLabel
    {
        private Label label;
        private Texture2D backgroundTexture;

        public ButtonMenu(GraphicsInfos graphics, Rectangle rectangle, SpriteFont font, string text, Color textColor, Texture2D backgroundTexture)
            : base(graphics, font, rectangle, text)
        {
            this.backgroundTexture = backgroundTexture;
            ApplyPositionPercentage(graphics.resolution);
            label = new Label(graphics, font, new Vector2(this.rectangle.X, this.rectangle.Y), text, textColor);
            this.rectangle.Width = (int)font.MeasureString(text).X;
            this.rectangle.Height = (int)font.MeasureString(text).Y;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(backgroundTexture, new Rectangle(rectangle.X - 10, rectangle.Y - 10, rectangle.Width + 20, rectangle.Height + 20), Color.White);
            label.Draw(batch);
        }
    }
}
