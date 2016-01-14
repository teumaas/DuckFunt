using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    public class GraphicsInfos
    {
        public Resolution resolution;
        public bool IsFullScreen { get; private set; }

        public GraphicsInfos(Resolution resolution, bool IsFullScreen)
        {
            this.resolution = resolution; 
            this.IsFullScreen = IsFullScreen;
        }
    }
}
