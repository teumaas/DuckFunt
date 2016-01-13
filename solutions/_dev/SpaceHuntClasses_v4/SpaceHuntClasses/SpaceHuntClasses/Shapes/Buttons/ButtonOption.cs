using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonOption : Button
    {
        private Timer timer;
        private Rectangle originRectangle;
        private int z;

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


        public ButtonOption(GraphicsInfos graphics, Texture2D texture, Rectangle percentage)
            : base(graphics, texture, percentage)
        {
            originRectangle = rectangle;
            timer = new Timer(10);
            timer.Tick += animation_Tick;
            z = 0;
            Hover += OnHover;   
        }

        public override void Build(Resolution resolution)
        {
            base.Build(resolution);
            this.originRectangle = rectangle;
        }

        void animation_Tick(object sender, EventArgs e)
        {
            if (state == InteractionState.Hover)
            {
                if (z > -10)
                    Z--;
            }
            else
            {
                if (z < 0)
                    Z++;
                else
                    timer.Stop();
            }
        }


        public override void Update(InputState input, GameTime gameTime)
        {
            base.Update(input, gameTime);

            if (timer.active)
            {
                timer.Update(gameTime);
            }

        }

        public override void Draw(SpriteBatch batch)
        {
            //Utility.DrawRectangleShadow(batch, rectangle, -Z + 5, 0.0f  - (z / 10));
            base.Draw(batch);
        }

        protected void OnHover(object sender, InteractionEventArgs e)
        {
            if (!timer.active)
            {
                timer.Start();
            }
        }

    }
}
