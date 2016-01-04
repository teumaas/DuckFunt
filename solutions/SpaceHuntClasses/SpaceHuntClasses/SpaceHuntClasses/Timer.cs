using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Classes
{
    //public delegate void OnAnimation(Animation animation);
    class Timer
    {
        public bool active { get; private set; }
        private Action action;
        private float interval;
        private float timer;      


        public Timer(Action action, float interval)
        {
            this.action = action;
            this.interval = interval;
            timer = 0.0f;
            active = false;
        }

        public void Update(GameTime gameTime)
        {
            if(active)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (timer >= interval)
                {
                    action();
                    timer = 0.0f;
                }
            }
        }


        public void Start()
        {
            timer = 0.0f;
            active = true;
        }

        public void Resume()
        {
            active = true;
        }

        public void Stop()
        {
            active = false;
            timer = 0.0f;
        }
    }
}
