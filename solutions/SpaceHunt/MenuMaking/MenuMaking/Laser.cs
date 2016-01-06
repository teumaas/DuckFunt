using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SpaceHunt
{
    class Laser : Weapon
    // Laser sound
    //DuckFunt\source\audio\done\player\aud_laser_load.wav
    //DuckFunt\source\audio\done\player\aud_laser_shot.wav
    {
        SoundEffect laserShot;
        SoundEffect laserReload;
        ContentManager content;

        private void initialize()
        {
            laserShot = content.Load<SoundEffect>("aud_laser_shot");
            laserReload = content.Load<SoundEffect>("aud_laser_load");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                laserShot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }

        public void reload()
        {
            if (isNotPlayingSound == true)
            {
                laserReload.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;   
        }
    }
}
