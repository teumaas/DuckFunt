using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonOption : ShapeInteractive
    {
        private Timer animation;
        private Rectangle originRectangle;

        public int z;
        public int Z
        {
            private get
            {
                return z;
            }
            set
            {
                z = value;
                rectangle.X = originRectangle.X + value;
                rectangle.Y = originRectangle.Y + value;
                rectangle.Width = originRectangle.Width - (2 * value);
                rectangle.Height = originRectangle.Height - (2 * value);
            }
        }


        public ButtonOption(Texture2D texture, Rectangle rectangle)
            : base(texture, rectangle)
        {
            originRectangle = rectangle;
            animation = new Timer(OnAnimation, 10);
            z = 0;
            Hover += OnHover;
        }


        public override void Update(GameTime gameTime, MouseState mouseState)
        {
            base.Update(gameTime, mouseState);

            if (animation.active)
            {
                animation.Update(gameTime);
            }

        }

        public override void Draw(SpriteBatch batch)
        {
            //Utility.DrawRectangleShadow(batch, rectangle, -Z + 5, 0.0f  - (z / 10));
            base.Draw(batch);
        }


        public void OnAnimation()
        {
            if (state == InteractionState.Hover)
            {
                if (z > -10)
                {
                    Z--;
                }
            }
            else
            {
                if (z < 0)
                {
                    Z++;
                }
                else
                {
                    animation.Stop();
                }
            }
        }

        protected void OnHover(object sender, InteractionEventArgs e)
        {
            if (!animation.active)
            {
                animation.Start();
            }
        }

    }
}
