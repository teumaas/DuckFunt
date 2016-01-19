using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Screens
{
    class LevelSelectionScreen : IScreen
    {
        Buttons.Button level1Button;

        public LevelSelectionScreen(Main main, GraphicsInfos graphics)
        {

        }

        public void Initialize(Shapes.GraphicsInfos graphics)
        {
            //level1Button = ...
            //level1Button.Release += ButtonOnClick;
            //level2Button.Release += ButtonOnClick;
        }

        public void LoadContent()
        {
            
        }

        public void Update(InputState input, GameTime gameTime)
        {
            //level1Button.Update(input, gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            //level1Button.Draw(batch);
        }

        public void StartGame(Level level)
        {

        }


       
    }
}
