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
        private Shape shape;
        private int value;
        private int unit;

        public ButtonTrackBar(Texture2D texture, Rectangle rectangle, Texture2D scrollTexture, int value) : base(texture, rectangle)
        {
            this.value = value; 
            unit = rectangle.Width / 100;
            shape = new Shape(scrollTexture, new Rectangle(rectangle.X + unit * value, rectangle.Height / 9, 18, 35));
        }

        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            base.Update(gameTime, mouseState);

            if(state == InteractionState.Down)
            {
                shape.rectangle.X = mouseState.X;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            shape.Draw(batch);
        }

    }
}
