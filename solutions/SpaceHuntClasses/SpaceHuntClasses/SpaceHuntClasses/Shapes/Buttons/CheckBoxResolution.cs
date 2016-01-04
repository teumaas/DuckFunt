using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes.Buttons
{
    public class ButtonCheckBoxResolution : ButtonCheckBox
    {
        public Resolution resolution { get; private set; }

        public ButtonCheckBoxResolution(Texture2D texture, Rectangle rectangle, bool selected, Resolution resolution)
            : base(texture, rectangle, selected)
        {
            this.resolution = resolution;
        }

        public override void Action()
        {
            Selected = true;
        }
    }
}
