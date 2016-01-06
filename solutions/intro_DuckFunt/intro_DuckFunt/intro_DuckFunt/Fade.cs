using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace intro_DuckFunt
{
    class Fade
    {
        Color color;
        Texture2D pic;
        Vector2 pos;
        Rectangle back;

        byte R, G, B;
        int i;

        public Fade(Texture2D pic, Vector2 pos, Rectangle back)
        {
            this.pic = pic;
            this.pos = pos;
            this.back = back;
        }

        public void Initialize(int i)
        {
            R = 0;
            G = 0;
            B = 0;
            this.i = i;
        }

        public void DrawFade(GameTime gameTime, SpriteBatch spriteBatch, float elapsed)
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;



            if (i <= 154)
            {
                i++;

                R += 1;
                G += 1;
                B += 1;

                color.R = R;
                color.G = G;
                color.B = B;

                DrawBack(spriteBatch);
            }
        }

        public void DeleteDraw(SpriteBatch spriteBatch)
        {
            if (pos.Y <= -50 && R > 0)
            {
                R -= 1;
                G -= 1;
                B -= 1;

                color.R = R;
                color.G = G;
                color.B = B;

                DrawBack(spriteBatch);
            }
        }

        private void DrawBack(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pic, back, color);
            spriteBatch.End();
        }
    }
}
