using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Buttons
{
    class ButtonLabel : Button
    {
        private Label label;

        public ButtonLabel(GraphicsInfos graphics, SpriteFont font, Rectangle rectangle, string text) : base(graphics, rectangle)
        {

        }


        public override void Draw(SpriteBatch batch)
        {
            //label.Draw(batch);
        }
    }
}
