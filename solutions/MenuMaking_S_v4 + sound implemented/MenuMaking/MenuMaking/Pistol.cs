using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MenuMaking
{
    class Pistol : Weapons
    // Pistol sound
    //DuckFunt\source\audio\done\player\aud_pistol.wav
    //DuckFunt\source\audio\done\player\aud_pistol_reload-l.wav 
    //DuckFunt\source\audio\done\player\aud_pistol_reload-s.wav
    {
        SoundEffect pistolShot;
        SoundEffect pistolReloadLong;
        SoundEffect pistolReloadShort;
        ContentManager content;

        private void initialize()
        {
            pistolShot = content.Load<SoundEffect>("aud_pistol");
            pistolReloadLong = content.Load<SoundEffect>("aud_pistol_reload-l");
            pistolReloadShort = content.Load<SoundEffect>("aud_pistol_reload-s");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                pistolShot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }
        public void reloadLong()
        {
            if (isNotPlayingSound == true)
            {
                pistolReloadLong.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }

        public void reloadShort()
        {
            if (isNotPlayingSound == true)
            {
                pistolReloadShort.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }
    }
}
