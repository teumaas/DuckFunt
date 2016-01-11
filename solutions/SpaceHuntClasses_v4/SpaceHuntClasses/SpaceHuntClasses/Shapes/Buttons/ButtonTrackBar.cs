using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonTrackBar : Button
    {
        private Shape scrollShape;
        private ShapeLabel label;
        private Rectangle lineRectangle;
        private ShapeInteractive negativeShape; // '-'
        private ShapeInteractive positiveShape; // '+'
        private int value;
        private int unit;

        private int Value
        {
            get { return value; }
            set
            {
                if (value >= 0 && value <= 10)
                    this.value = value;
            }
        }


        public ButtonTrackBar(GraphicsInfos graphics, Texture2D texture, Rectangle percentage, SpriteFont font, Texture2D scrollTexture, string text, int value) : base(graphics, texture, percentage)
        {
            this.Value = value;
            lineRectangle = new Rectangle(rectangle.X + rectangle.Width / 12, rectangle.Y, rectangle.Width * 10 / 12, 45);
            unit = (lineRectangle.Width) / 10;

            scrollShape = new Shape(graphics, scrollTexture, new Rectangle(lineRectangle.X + unit * Value, rectangle.Y, scrollTexture.Width, rectangle.Height));
            scrollShape.rectangle.X -= scrollShape.rectangle.Width / 2;

            label = new ShapeLabel(graphics, new Rectangle(rectangle.X - (int)font.MeasureString(text).X - 50, rectangle.Y + (rectangle.Height / 2) - ((int)font.MeasureString(text).Y / 2), (int)font.MeasureString(text).X, (int)font.MeasureString(text).Y), font, text);

            negativeShape = new ShapeInteractive(graphics, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width / 12, rectangle.Height));
            negativeShape.Release += NegativeShapeOnRelease;

            positiveShape = new ShapeInteractive(graphics, new Rectangle(lineRectangle.X + lineRectangle.Width, rectangle.Y, negativeShape.rectangle.Width, negativeShape.rectangle.Height));
            positiveShape.Release += PositiveShapeOnRelease;
        }

        public override void Update(InputState input, GameTime gameTime)
        {
            base.Update(input, gameTime);

            if (state == InteractionState.Down && input.shootControl == ControlState.Pressed)
            {
                //scrollShape.rectangle.X = mouseState.X - (mouseState.X - rectangle.X - 31) % unit;
                //Value = (scrollShape.rectangle.X - lineRectangle.X) / unit;

                int rest = (input.X - lineRectangle.X) % unit;

                Value = (input.X - lineRectangle.X + rest) / unit;
            }

            negativeShape.Update(input, gameTime);
            positiveShape.Update(input, gameTime);

            scrollShape.rectangle.X = lineRectangle.X - (scrollShape.rectangle.Width / 2) + unit * Value;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            scrollShape.Draw(batch);
        }

        public void NegativeShapeOnRelease(object sender, InteractionEventArgs e)
        {
                Value -= 1;
        }
        public void PositiveShapeOnRelease(object sender, InteractionEventArgs e)
        {
                Value += 1;
        }

    }
}
