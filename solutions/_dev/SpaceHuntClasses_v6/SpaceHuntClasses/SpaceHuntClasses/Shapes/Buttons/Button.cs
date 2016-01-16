using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Buttons
{
    public class Button : ShapeInteractive
    {

        public Button(GraphicsInfos graphics, Rectangle rectangle) : base(graphics, rectangle)
        {

        }

        public Button(GraphicsInfos graphics, Texture2D texture, Rectangle rectangle)
            : base(graphics, texture, rectangle)
        {
        }
    }

}