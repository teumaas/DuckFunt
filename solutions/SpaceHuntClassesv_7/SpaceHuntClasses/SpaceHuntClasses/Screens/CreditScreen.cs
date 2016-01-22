using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceHuntClasses.MessageBoxs;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes.Labels;
using System.IO;


namespace SpaceHuntClasses.Screens
{
    class CreditScreen : IScreen
    {
        private Main main;
        private Texture2D creditsTexture;
        private Shape backgroundShape;

        public CreditScreen(Main main, GraphicsInfos graphics)
        { 
            this.main = main;
            Initialize(graphics);
        }
        

        public void Initialize(GraphicsInfos graphics)
        { 
            LoadContent();
            backgroundShape = new Shape(graphics, creditsTexture, new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height));
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
            backgroundShape.Draw(spriteBatch);
        }

        public void Start()
        {
        }

        private void Leave()//go to the main menu
        {
            main.StartMenu();
        }
    }
}
