using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{

    class DarkBackgroundAnimation
    {
        private Texture2D texture;
        private Rectangle rectangle;
        public float velocity;
        private float transparency;
        public bool active;
        public bool paused;

        public DarkBackgroundAnimation(GraphicsInfos graphics, float velocity)
        {
            texture = Utility.GetBlackTexture();
            rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
            this.velocity = velocity;
            transparency = velocity;
            active = false;
            paused = false;
        }

        public void Start() 
        {
            velocity = 0.1f;
            transparency = 0.001f;
            active = true;
            paused = false;
        }

        public void Stop()
        {
            active = false;
            paused = false;
        }

        public void Resume()
        {
            paused = false;
        }

        public void Update()
        {
            if (!paused)
            {

                if(velocity > 0)
                {
                    if(transparency < 1)
                    {
                        transparency += velocity;
                    }
                    else
                    {
                        paused = true;
                    }
                }
                else
                {
                    if (transparency > 0)
                    {
                        transparency += velocity;
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
            
        }


        public void ReverseVelocity()
        {
            velocity *= -1;
            transparency += velocity;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rectangle, Color.Black * transparency);
        }

    }
}
