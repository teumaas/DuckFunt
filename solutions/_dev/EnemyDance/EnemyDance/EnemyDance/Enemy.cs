using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EnemyDance
{
    class Enemy
    {
        private int health { get; set; }
     //   private float velocity { get; set; }
        private int distance { get; set; }
        public Vector2 velocity;
        private Vector2 location;
        private Texture2D img;
        private EnemyMovement move;
        
        public Enemy(ContentManager cont, GraphicsDeviceManager gdm, EnemyMovement moveMeBabe)
        {

            img = cont.Load<Texture2D>("tumblr_mrmu0hNZJv1s6294bo1_500");
            img = new Texture2D(gdm.GraphicsDevice, 50, 100);
            this.move = moveMeBabe;

        }

        void Crash()
        {

        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            sb.Draw(img, location, Color.White);

            sb.End();
        }

        public void Update()
        {
             move.Update();
            location = move.curLoc;
            velocity = move.curVel;
            location += velocity;
        }
    }
}
