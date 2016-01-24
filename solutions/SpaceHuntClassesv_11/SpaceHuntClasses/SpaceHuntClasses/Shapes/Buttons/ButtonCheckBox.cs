using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonCheckBox : Button
    {
        public Rectangle sourceRectangle;
        private bool selected;

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                if (value)
                {
                    sourceRectangle.Y = texture.Bounds.Height / 2;
                }
                else
                {
                    sourceRectangle.Y = 0;
                }
            }
        }


        public ButtonCheckBox(GraphicsInfos graphics,Texture2D texture, Rectangle rectangle, bool selected)
            : base(graphics, texture, rectangle)
        {
            ApplyPositionPercentage(graphics.resolution);
            ResizeWithTexture(graphics.resolution);
            this.rectangle.Height /= 2;
            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height / 2);
            this.Selected = selected;
            //font.mesureString(string).X;
            Release += OnRelease;
        }

        protected void OnRelease(object sender, InteractionEventArgs e)
        {
            Action();
        }

        public virtual void Action()
        {
            Selected = !Selected;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, sourceRectangle, Color.White);
        }

    }
}
