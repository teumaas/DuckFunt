using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    public struct Resolution
    {
        public int width;
        public int height;

        public Resolution(int Width, int Height)
        {
            width = Width;
            height = Height;
        }

        public override bool Equals(object obj)
        {
            return width == ((Resolution)obj).width;
        }

    }
}
