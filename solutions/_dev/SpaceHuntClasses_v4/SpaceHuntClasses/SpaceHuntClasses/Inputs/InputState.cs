using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;

namespace SpaceHuntClasses
{
    public enum ControlState {Pressed, Release}

    public class InputState
    {
        public ControlState shootControl { get; private set; }
        public ControlState reloadControl { get; private set; }
        public ControlState crouchControl { get; private set; }
        public ControlState backControl { get; private set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        public InputState()
        {
            X = 0;
            Y = 0;
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {
            X = mouseState.X;
            Y = mouseState.Y;

            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//shoot = LeftButton
            {
                shootControl = ControlState.Pressed;
            }
            else
                shootControl = ControlState.Release;


            if (mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//reload = RightButton
            {
                reloadControl = ControlState.Pressed;
            }
            else
                reloadControl = ControlState.Release;


            if (keyboardState.IsKeyDown(Keys.Space))//crouch = spacebar
            {
                crouchControl = ControlState.Pressed;
            }
            else
                crouchControl = ControlState.Release;


            if (keyboardState.IsKeyDown(Keys.Escape))//back = escape
            {
                backControl = ControlState.Pressed;
            }
            else
                backControl = ControlState.Release;
        }

        public void Update(WiimoteState wiimoteState)
        {
            X = (int)wiimoteState.IRState.IRSensors[0].Position.X;
            Y = (int)wiimoteState.IRState.IRSensors[0].Position.Y;

            if (wiimoteState.ButtonState.B)
            {
                if(true) //if the wiimote is pointing at the sceen
                {
                    shootControl = ControlState.Pressed;
                    reloadControl = ControlState.Release;
                }
                else
                {
                    //reloadControl = ControlState.Pressed;
                    //shootControl = ControlState.Release;
                }
            }
            else
                shootControl = ControlState.Release;

            
        }
    }
}
