using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Buttons;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.MessageBoxs
{
    public delegate void MessageBoxEventHandler(object sender, EventArgs e);

    abstract class MessageBox
    {
        private DarkBackgroundAnimation backgroundAnimation;
        protected Rectangle rectangle;
        private SpriteFont font;
        protected ButtonLabel firstButton;
        protected string text;
        public event MessageBoxEventHandler FirstButtonOnRelease;
        public event MessageBoxEventHandler SecondButtonOnRelease;
        

        public MessageBox(GraphicsInfos graphics, SpriteFont font)
        {
            //backgroundTransp    
            //backgroundAnimation = new DarkBackgroundAnimation(graphics);
            rectangle = new Rectangle(graphics.resolution.width / 2, graphics.resolution.height / 2, graphics.resolution.width / 20, graphics.resolution.height / 20);
            this.font = font;
            firstButton = new ButtonLabel(graphics, font, new Rectangle(0, 0, 0, 0), "yes");
        }

        public virtual void Update(InputState input)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            backgroundAnimation.Draw(batch);
        }
        
    }
}
