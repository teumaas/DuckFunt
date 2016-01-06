using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
namespace SpaceHunt
{
    class rpg : Weapon
    {
        SoundEffect rpgShot;
        SoundEffect rpgLaunch;
        ContentManager content;

        public void initialize()
        {
            rpgShot = content.Load<SoundEffect>("aud_rpg-1");
            rpgLaunch = content.Load<SoundEffect>("aud_rpg-2");
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
