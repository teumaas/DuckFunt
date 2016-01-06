using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace SpaceHunt
{
    class Minigun : Weapon
        // Minigun sound
    {
        SoundEffect minigunShot;
        ContentManager content;

        private void initialize()
        {
            minigunShot = content.Load<SoundEffect>("aud_minigun");
        }

        public void shoot()
        {
            if (isNotPlayingSound == true)
            {
                minigunShot.Play();
                isNotPlayingSound = false;
            }
            isNotPlayingSound = true;
            
        }
    }
}
