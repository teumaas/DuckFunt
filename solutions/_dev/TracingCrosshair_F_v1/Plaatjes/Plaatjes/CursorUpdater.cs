using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Plaatjes
{

    class CursorUpdater
    {
        MouseState state;
        //public void CursorUpdater()
        //{
        //    state = Mouse.GetState();
        //}
        public int GetCursX()
        {
            state = Mouse.GetState();
            return Convert.ToInt32(state.X);
        }
        public int GetCursY()   
        {
            state = Mouse.GetState();
            int i = Convert.ToInt32(state.Y);
            return i;
        }

     }   
}
