using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHunt.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    abstract class MessageBox
    {
        private float backgroundTransparency;
        protected Rectangle rectangle;
        protected string text;

        public MessageBox(Resolution resolution)
        {
            backgroundTransparency = 0f;
            //rectangle = new Rectangle(resolution.width /2, resolution.height / 2, resolution)
        }
                
        public virtual void Draw(SpriteBatch batch)
        {
            //batch.Draw(Utility.GetBlackTexture(), new Rectangle(0, 0, 1920, 1080), Color.Black * backgroundTransparency);
        }
        
    }
}
