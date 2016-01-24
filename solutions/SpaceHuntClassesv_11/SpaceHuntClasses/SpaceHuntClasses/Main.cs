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
using System.Timers;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Levels;

namespace SpaceHuntClasses
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    enum GameState {Intro, Menu, InGame}
    enum InputType { Wiimote, MouseKeyboard}

    public class Main : Microsoft.Xna.Framework.Game
    {
        Texture2D cursorTexture;
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameScreen gameScreen;
        IntroScreen introScreen;
        GameState gameState;
        MenuScreen menuScreen;
        private InputState inputState;
        private InputType inputType;
        private WiimoteLib.Wiimote wiiMote;
        Timer timer;
        public GameDataSaveManager saveManager;
        public Texture2D scrollTrackBarTexture;
        public Texture2D trackBarTexture;
        public LevelsManager levels;

        public List<GameData> gamedatas;

        public SpriteFont fontSize10;
        public SpriteFont fontSize14;

        public Texture2D earthLevelOverview;
        public Texture2D earthLevelBackground;
            

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        {
            LoadContent();
            var gi = new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen);
            Utility.Init(GraphicsDevice);

            saveManager = new GameDataSaveManager("LeaderBoard_Savedata.1337");
            gamedatas = saveManager.LoadGameDatas();

            levels = new LevelsManager();
            levels.InitializeLevelsDatas(gamedatas);
            

            introScreen = new IntroScreen(this, gi);
            inputState = new InputState();
            inputType = InputType.MouseKeyboard;

            //wiiMote = new WiimoteLib.Wiimote();
            //wiiMote.Connect();
            //wiiMote.SetLEDs(true, true, false, true);//test

            introScreen.Start();

            //StartGame();
            StartMenu();
        }
        
        public void InitLevels()
        {
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cursorTexture = Content.Load<Texture2D>("cursors/crossHair");
            scrollTrackBarTexture = Content.Load<Texture2D>("scrollTrackBar");
            trackBarTexture = Content.Load<Texture2D>("trackBarTexture");
            fontSize10 = Content.Load<SpriteFont>("fonts/FontSize10");
            fontSize14 = Content.Load<SpriteFont>("fonts/FontSize14");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (inputType == InputType.Wiimote)
            {
                inputState.Update(wiiMote.WiimoteState);
            }
            else //intputType == InputType.MouseKeyboard
            {
                inputState.Update(Mouse.GetState(), Keyboard.GetState());
            }

            if(gameState == GameState.InGame)
            {
                gameScreen.Update(inputState, gameTime);
            }
            else if (gameState == GameState.Menu)
            {
                menuScreen.Update(inputState, gameTime);
            }
            else //gameState == GameState.Intro
            {
                introScreen.Update(inputState, gameTime);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            if(gameState == GameState.InGame)
            {
                gameScreen.Draw(spriteBatch);
            }
            else if(gameState == GameState.Menu)
            {
                menuScreen.Draw(spriteBatch);
            }
            else // gameState == GameState.Intro
            {
                introScreen.Draw(spriteBatch);
            }
            
            spriteBatch.Draw(cursorTexture, new Rectangle(inputState.X - 50, inputState.Y - 50, 100, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ActiveMusicSound()
        {
            //TODO : finish this method or remove it and make an another one in the optionScreen
        }
        public void ActiveSpecialEffectsSound()
        {
            //TODO : finish this method or remove it and make an another one in the optionScreen
        }
        public void ActiveSound()
        {
            //TODO : finish this method or remove it and make an another one in the optionScreen
        }

        public void ChangeFullScreenMode()
        {
            graphics.IsFullScreen = !graphics.IsFullScreen;
            graphics.ApplyChanges();
        }

        public void ChangeResolution(Resolution resolution)
        {
            graphics.PreferredBackBufferWidth = resolution.width;
            graphics.PreferredBackBufferHeight = resolution.height;
            graphics.ApplyChanges();

            menuScreen.Initialize(new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen));// TODO : i can do : this.Initialize()
        }

        public void StartMenu()
        {
            menuScreen = new MenuScreen(this, new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen));
            gameState = GameState.Menu;
        }

        public void StartGame(Level level)
        {
            gameScreen = new GameScreen(this, new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen));
            gameState = GameState.InGame;
            gameScreen.Start(level);
        }

    }
}
