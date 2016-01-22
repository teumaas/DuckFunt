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
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Levels;


namespace SpaceHuntClasses
{

    public enum GameScreenState { Loading, Game}

    public class GameScreen : IScreen
    {
        private Main main;
        private LoadScreen loadScreen;
        private GameScreenState gameScreenState;

        public GameScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);
            gameScreenState = GameScreenState.Game;
        }


        public void Initialize(GraphicsInfos graphics)
        {
            loadScreen = new LoadScreen(main, graphics);
        }

        public void LoadContent()
        {

        }

        public void Update(InputState input, GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch batch)      
        {
            if(gameScreenState == GameScreenState.Loading)
            {
                loadScreen.Draw(batch);
            }
        }
        
        public void Start(Level level)
        {
            loadScreen.Start(2);
        }
    }
}
