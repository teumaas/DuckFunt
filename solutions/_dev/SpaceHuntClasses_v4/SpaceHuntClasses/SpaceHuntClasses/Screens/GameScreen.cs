using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace SpaceHuntClasses
{

    public class GameComponent1 : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch batch;

        public GameComponent1(Game game)
            : base(game)
        {

        }


        public override void Initialize()
        {

            batch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }


        public void Update(InputState input)
        {



        }

        public override void Draw(GameTime gameTime)
        
        {
            
            base.Draw(gameTime);
        }
    }
}
