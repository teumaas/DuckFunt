using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Shapes.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.MessageBoxs
{
    class ControlsDataGrid
    {
        private Texture2D texture;
        private Label shootAction;
        private Label shootWiiMote;
        private Label shootMouse;
        
        public ControlsDataGrid(Texture2D texture)
        {
            this.texture = texture;
            //shootAction = new Label()
        }

        public void Udpate(MouseState mouseState, KeyboardState keyboardState)
        {
            
        }

        public void Draw(SpriteBatch batch)
        {

        }
    }
}
