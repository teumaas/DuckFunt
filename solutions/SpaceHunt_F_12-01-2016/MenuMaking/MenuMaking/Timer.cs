using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHunt
{
    public delegate void TimerEventHandler(object sender, EventArgs e);

    class Timer
    {
        public  TimerEventHandler Tick;
        private float interval;
        private float timer;      
        public bool active { get; private set; }


        public Timer(float interval)
        {
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
                    Tick(this, null);
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
