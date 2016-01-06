using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SpaceHunt
{
    class Ak47 : Weapon
    // Ak 47 sound
    //DuckFunt\source\audio\done\player\aud_ak47.wav
    //DuckFunt\source\audio\done\player\aud_ak457_reload-s.wav
    //DuckFunt\source\audio\done\player\aud_ak457_reload-l.wav
    {
        SoundEffect ak47Shot;
        SoundEffect ak47ReloadLong;
        SoundEffect ak47ReloadShort;
        ContentManager content;

        private void initialize()
        {
            ak47Shot = content.Load<SoundEffect>("aud_ak47");
            ak47ReloadLong = content.Load<SoundEffect>("aud_ak47-l");
            ak47ReloadShort = content.Load<SoundEffect>("aud_ak47-s");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                ak47Shot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
            
        }

        public void reloadLong()
        {
            if (isNotPlayingSound == true)
            {
                ak47ReloadLong.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true; 
        }

        public void reloadShort()
        {
            if (isNotPlayingSound == true)
            {
                ak47ReloadShort.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
        }
    }
}
