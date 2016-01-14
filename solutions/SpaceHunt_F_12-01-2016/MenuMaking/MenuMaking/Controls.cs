using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;
using Microsoft.Xna.Framework.Input;

namespace SpaceHunt
{
    class Controls
    {
        Wiimote wiimote;
        KeyboardState CurrentKeyBoardState = Keyboard.GetState();
        MouseState mouseState = Mouse.GetState();
        
        private Controls()
        {
            wiimote.Connect();

            if (wiimote.WiimoteState.ButtonState.A)         //Crouch
            {
               
            }
            else if (wiimote.WiimoteState.ButtonState.B)    //Shoot
            {
                
            }
            else if (wiimote.WiimoteState.AccelState.RawValues.Y >= 200) //reload
            {
                
            }
            else if (wiimote.WiimoteState.ButtonState.Home) //menu
            {
                
            }

            //if (mouseState.LeftButton = true)//shoot
            //{

            //}
                if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//Shoot
                {
                    if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {

                    }
                }
                if (mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)//reload
                {
                    if (mouseState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {

                    }
                }
           
            if (CurrentKeyBoardState.IsKeyUp(Keys.Space) == true)//Crouch
            {

            }
            if (CurrentKeyBoardState.IsKeyUp(Keys.Escape) == true)//Menu
            {

            } if (CurrentKeyBoardState.IsKeyUp(Keys.Back) == true)//back
            {

            }
        }
    }
}
