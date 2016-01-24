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
using System.Threading;


namespace SpaceHuntClasses
{

    public enum GameScreenState { Loading, Game}

    public class GameScreen : IScreen
    {
        private Main main;
        private Level level;
        private LoadScreen loadScreen;
        private GameScreenState gameScreenState;
        private Shape backgroundShape;

        public GameScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);        
        }


        public void Initialize(GraphicsInfos graphics)
        {
            loadScreen = new LoadScreen(main, graphics);
            loadScreen.Finish += LoadScreenOnFinish;
            backgroundShape = new Shape(graphics, new Rectangle(0, 0, 100, 100));
            backgroundShape.rectangle = new Rectangle(0, 0, graphics.resolution.width, graphics.resolution.height);
        }

        public void LoadContent()
        {
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if(gameScreenState == GameScreenState.Game)
            {
                
            }
            else
            {
                loadScreen.Update(input, gameTime);
            }
        }

        public void Draw(SpriteBatch batch)      
        {
            if(gameScreenState == GameScreenState.Game)
            {
                backgroundShape.Draw(batch);
            }
            else
            {
                loadScreen.Draw(batch);
            }
        }
        
        public void Start(Level level)
        {
            this.level = level;
            level.LoadGameTexture(main.Content);
            backgroundShape.SetTexture(level.gameTexture);


            loadScreen.Start(level.index);
            gameScreenState = GameScreenState.Loading;
        }

        public void LoadScreenOnFinish(object sender, EventArgs e)
        {
            gameScreenState = GameScreenState.Game;
        }
    }
}
