using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonTrackBar : Button
    {
        private int value;
        private int unit;
        private ShapeInteractive scrollShape;
        private Label label;
        private Rectangle lineRectangle;
        private ShapeInteractive negativeShape; // '-'
        private ShapeInteractive positiveShape; // '+'
        private bool down;

        private int Value
        {
            get { return value; }
            set
            {
                if (value >= 0 && value <= 10)
                    this.value = value;
            }
        }


        public ButtonTrackBar(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle, SpriteFont font, Texture2D scrollTexture, string text, int value) : base(graphics, texture, rectangle)
        {
            //lineRectangle = new Rectangle(rectangle.X + rectangle.Width / 12, rectangle.Y, rectangle.Width * 10 / 12, 45);

            this.Value = value;
            down = false;

            //NEGATIVE & POSITIVE SHAPES + EVENT 
            negativeShape = new ShapeInteractive(graphics, new Rectangle(rectangle.X, rectangle.Y, 4, 4));
            negativeShape.Release += NegativeShapeOnRelease;
            positiveShape = new ShapeInteractive(graphics, new Rectangle(rectangle.X + rectangle.Width - 4  , rectangle.Y, 4, 4));
            positiveShape.Release += PositiveShapeOnRelease;

            
            unit = (this.rectangle.Width - (2 * negativeShape.rectangle.Width)) / 10;

            scrollShape = new ShapeInteractive(graphics, scrollTexture,new Rectangle(rectangle.X, rectangle.Y, 0, 0));
            scrollShape.rectangle.X = this.rectangle.X + value * unit; 

            label = new Label(graphics, font, new Vector2(this.rectangle.X + (this.rectangle.Width / 2) - (font.MeasureString(text).X), this.rectangle.Y - (font.MeasureString(text).Y)), text);

            
        }


        public override void Update(InputState input, GameTime gameTime)
        {
            base.Update(input, gameTime);

            scrollShape.Update(input, gameTime);

            if(scrollShape.state == InteractionState.Down)
            {
                int tmp = input.X - scrollShape.rectangle.Width;
                if(tmp > )
                scrollShape.rectangle.X = input.X - scrollShape.rectangle.Width;
            }

            if (state == InteractionState.Down && input.shootControl == ControlState.Pressed)
            {
                //scrollShape.rectangle.X = mouseState.X - (mouseState.X - rectangle.X - 31) % unit;
                //Value = (scrollShape.rectangle.X - lineRectangle.X) / unit;

                int rest = (input.X - rectangle.Width - (2 * negativeShape.rectangle.Width)) % unit;
                
                Value = (input.X - rectangle.Width - (2 * negativeShape.rectangle.Width) + rest) / unit;

                //Value = (input.X - rectangle.X + negativeShape.rectangle.Width) / unit;
            }

            negativeShape.Update(input, gameTime);
            positiveShape.Update(input, gameTime);
         
            //scrollShape.rectangle.X = rectangle.X - negativeShape.rectangle.Width + unit * value;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            scrollShape.Draw(batch);
            label.Draw(batch);
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
