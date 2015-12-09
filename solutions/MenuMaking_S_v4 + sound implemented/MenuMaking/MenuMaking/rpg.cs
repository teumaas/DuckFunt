using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
namespace MenuMaking
{
    class rpg : Weapons
    {
        SoundEffect rpgShot;
        SoundEffect rpgLaunch;
        ContentManager content;

        public void initialize()
        {
            rpgShot = content.Load<SoundEffect>("");
            rpgLaunch = content.Load<SoundEffect>("");
        }
        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                rpgShot.Play();
                rpgLaunch.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }
    }
}
