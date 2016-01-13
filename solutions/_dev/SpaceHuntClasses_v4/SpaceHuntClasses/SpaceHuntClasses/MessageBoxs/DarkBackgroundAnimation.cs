using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.MessageBoxs
{
    class DarkBackgroundAnimation
    {
        private Texture2D texture;
        private Rectangle rectangle;
        public float velocity;
        private float transparency;
        public bool active;

        public DarkBackgroundAnimation(GraphicsInfos graphics)
        {
            texture = Utility.GetBlackTexture();
            rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
            velocity = 0.01f;
        }

        public void Start() //new velocity
        {
            active = true;
        }

        public void Stop()
        {
            active = false;
        }

        public bool Update()
        {
            if (transparency != 1.0f && transparency != 0.0f)
            {
                transparency += velocity;
                return false;
            }
            else
            {
                active = false;
                return true; //else the animation is finish
            }
        }

        public void ReverseVelocity()
        {
            velocity *= -1;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, Color.Black * transparency);
        }

    }
}
