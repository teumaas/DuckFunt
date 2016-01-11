using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    class Weapon
    {
        bool weaponState;
        public bool isNotPlayingSound;
        int maxAmmo;
        int maxMagazine;
        int ammo;
        int damage;
        int magazine;
        int fireRate;
        int reloadTime;
        
        //SoundEffect shootSound;
        //SoundEffect reloadSound;
        //Texture2d reloadAnimationShape;
        //Texture2D fireShape;
        //Texture2d gunShape;

        //Pistol pistol;
        //Mp5 mp5;
        //Ak47 ak47;
        //M95 m95;
        //Minigun minigun;
        //Laser laser;
        protected Weapon()
        { 
            
        }

        private void Shoot() 
        {
        
        }

        private void Reload()
        { 
        
        }
    }
}
