using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MenuMaking
{
    class Mp5 : Weapons
    // Mp5 sound
    //DuckFunt\source\audio\done\player\aud_mp5.wav
    {
        SoundEffect mp5Shot;
        ContentManager content;

        private void initialize()
        {
            mp5Shot = content.Load<SoundEffect>("aud_mp5");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                mp5Shot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
            
        }
    }
}
