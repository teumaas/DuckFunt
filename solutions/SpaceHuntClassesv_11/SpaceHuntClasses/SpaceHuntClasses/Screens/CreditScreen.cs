using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Shapes
{
    class CreditScreen : IScreen
    {
        private Main main;
        private Texture2D creditsTexture;
        private Background background;

        public CreditScreen(Main main, GraphicsInfos graphics)
        { 
            this.main = main;
            Initialize(graphics);
        }
        

        public void Initialize(GraphicsInfos graphics)
        { 
            LoadContent();
            background = new Background(graphics, creditsTexture);
        }

        public void LoadContent()
        {
            creditsTexture = main.Content.Load<Texture2D>("textures/backgrounds/backgroundCreditScreen");
        }

        public void Update(InputState input, GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
        }

    }
}
