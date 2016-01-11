using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    enum ControlState {clicked, released}

    class ControlsState
    {
         
        public ButtonState shootState {get; private set;}
        public ButtonState crounchState { get; private set; }
        public ButtonState reloadState { get; private set; }
        public ButtonState homeButton { get; private set; }
        public ButtonState backButton { get; private set; }


        public ControlsState()
        {
            
        }

        private void Update(MouseState mouseState, KeyboardState keyboardState, InputType inputType)
        {
            
        }

    }
}
