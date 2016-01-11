using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiimoteLib;

namespace SpaceHunt
{
    class Controls
    {
        Wiimote wiimote;

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
            else if (wiimote.WiimoteState.ButtonState.Plus && wiimote.WiimoteState.ButtonState.Minus) // cheat point counter
            {
                
            }
        }
    }
}
