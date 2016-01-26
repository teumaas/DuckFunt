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
        public float speed;
        private float transparency;
        public bool active;
        public bool paused;
        public float maxTransparency;

        public DarkBackgroundAnimation(GraphicsInfos graphics, float velocity)
        {
            texture = Utility.GetTexture(Color.Black);
            rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
            this.velocity = velocity;
            transparency = velocity;
            active = false;
            paused = false;
            maxTransparency = 1;
            speed = velocity;
        }

        public DarkBackgroundAnimation(GraphicsInfos graphics, float velocity, Rectangle rectangle, float maxTransparency)
        {
            texture = Utility.GetTexture(Color.Black);
            this.rectangle = rectangle;
            this.velocity = velocity;
            transparency = velocity;
            active = false;
            paused = false;
            this.maxTransparency = maxTransparency;
            speed = velocity;
        }

        public void Init()
        {
            velocity = speed;
            transparency = speed;
        }

        public void Start() 
        {
            velocity = speed;
            transparency = speed;
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
                    if(transparency < maxTransparency)
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
