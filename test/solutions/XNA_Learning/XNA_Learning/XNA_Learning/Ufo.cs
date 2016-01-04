<<<<<<< HEAD
﻿
=======
>>>>>>> parent of 1e35a57... Revert "nothing special"
﻿using System;
using WiimoteLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Learning
{
    class Ufo
    {
        private Texture2D ufoImg;
        private Texture2D imgAvatar;
        private Vector2 ufoDir;
        private Vector2 ufoVelocity;
        private Vector2 crossLocation;
        private Rectangle ufoRec, destRec;
        private Random rndX, rndY;
        private Wiimote wm;
        private Sprite sprite;
        public bool shot;
        public int score;
        public float screenWidth;
        

        public Ufo(Texture2D ufoImg, Texture2D imgAvatar, Wiimote wm, float screenWidth)
        {
            this.ufoImg = ufoImg;
            this.imgAvatar = imgAvatar;
            this.screenWidth = screenWidth;
            this.wm = wm;
        }

        public void Initialize()
        {
            ufoVelocity = new Vector2(3f, 1f);
            ufoDir = new Vector2(0f, 0f);
            ufoRec = new Rectangle(0, 0, 100, 31);
            destRec = new Rectangle(0 , 0, 100, 31);
<<<<<<< HEAD
=======
            sprite = new Sprite(crossLocation, imgAvatar, screenWidth);
>>>>>>> parent of 1e35a57... Revert "nothing special"
            rndX = new Random();
            rndY = new Random();
            shot = false;
        }

        
        public void Update(float screenWidth, float screenHeight , float wX, float wY)
        {
            ufoDir += ufoVelocity;

            crossLocation.X = wX;   
            crossLocation.Y = wY;
            crossLocation = new Vector2(crossLocation.X + imgAvatar.Width / 2, crossLocation.Y + imgAvatar.Height / 2);

            if (ufoDir.Y + ufoImg.Height >= screenHeight / 2)
            {
                ufoVelocity.Y *= -1;
            }

            if (ufoDir.X + ufoImg.Width >= screenWidth)
            {
                ufoVelocity.X *= -1;
            }

            if (ufoDir.Y <= 0)
            {
                ufoVelocity.Y *= -1;
            }

            if (ufoDir.X <= 0)
            {
                ufoVelocity.X *= -1;
            }
        }
        
        public bool Shoot(SpriteBatch sb)
        {
            if (wm.WiimoteState.ButtonState.A)
            {
                if (crossLocation.Y > ufoDir.Y && crossLocation.Y < ufoDir.Y + imgAvatar.Height && crossLocation.X > ufoDir.X && crossLocation.X < ufoDir.X + imgAvatar.Width)
                {
                    shot = true;
                    score++;
                }
            }
            return shot;
        }

        public void Draw(SpriteBatch sb)
        {
            if (shot == true)
            {
                ufoDir = new Vector2(rndX.Next(0, 600), rndY.Next(0, 300));
                sb.Draw(ufoImg, ufoDir, destRec, Color.White);
                shot = false;
            }
            else
            {
                sb.Draw(ufoImg, ufoDir, destRec, Color.White);
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> parent of 1e35a57... Revert "nothing special"
