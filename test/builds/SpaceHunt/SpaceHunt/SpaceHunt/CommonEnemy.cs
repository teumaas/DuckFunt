using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    class CommonEnemy
    {
        int hp;
        Vector2 pos;
        SpriteBatch sb;
        Texture2D img;
        Texture2D bg;

        public CommonEnemy(int hp, Vector2 pos, SpriteBatch sb, Texture2D img, Texture2D bg)
        {
            this.hp = hp;
            this.pos = pos;
            this.sb = sb;
            this.img = img;
            this.bg = bg;

        }
    }
}
