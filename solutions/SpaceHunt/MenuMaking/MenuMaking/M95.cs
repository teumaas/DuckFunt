using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace MenuMaking
{
    class M95 : Weapons
    // Sniper sound
    //DuckFunt\source\audio\done\player\aud_m95.wav
    //DuckFunt\source\audio\done\player\aud_m95_rechamber.wav
    {
        SoundEffect m95Shot;
        SoundEffect m95Rechamber;
        ContentManager content;
        

        private void initialize()
        {
            m95Shot = content.Load<SoundEffect>("aud_m95");
            m95Rechamber = content.Load<SoundEffect>("aud_m95_rechamber");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                m95Shot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
            
        }

        public void rechamber()
        {
            if (isNotPlayingSound == true)
            {
                m95Rechamber.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
            
        }
    }
}
