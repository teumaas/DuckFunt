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
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Levels;
using System.Threading;
using SpaceHuntClasses.Shapes.Labels;


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

        private Shape scoreHUD;
        private Shape healthHUD;
        private Shape ammoHUD;

        private Label scoreLabel;
        private Label healtLabel;
        private Label ammoLabel;

        private Texture2D scoreTexture;
        private Texture2D healthTexture;
        private Texture2D ammoTexture;

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

            scoreHUD = new Shape(graphics, scoreTexture, new Rectangle(5, 95, 0, 0));
            scoreHUD.rectangle.Y -= scoreHUD.rectangle.Height;
            healthHUD = new Shape(graphics, healthTexture, new Rectangle(50, 95, 0, 0));
            healthHUD.rectangle.X -= healthHUD.rectangle.Width / 2;
            healthHUD.rectangle.Y -= healthHUD.rectangle.Height;
            ammoHUD = new Shape(graphics, ammoTexture, new Rectangle(95, 95, 0, 0));
            ammoHUD.rectangle.X -= ammoHUD.rectangle.Width;
            ammoHUD.rectangle.Y -= ammoHUD.rectangle.Height;
        }

        public void LoadContent()
        {
            scoreTexture = main.Content.Load<Texture2D>("textures/scoreHUD");
            healthTexture = main.Content.Load<Texture2D>("textures/healthHUD");
            ammoTexture = main.Content.Load<Texture2D>("textures/ammoHUD");
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
                scoreHUD.Draw(batch);
                healthHUD.Draw(batch);
                ammoHUD.Draw(batch);
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
