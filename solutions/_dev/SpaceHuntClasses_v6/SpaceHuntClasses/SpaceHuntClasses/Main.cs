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
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;

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
        Texture2D texture;
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
        public Texture2D scrollTrackBarTexture;
        public Texture2D trackBarTexture;

        public SpriteFont fontSize10;
        public SpriteFont fontSize14;
            
            
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

            introScreen = new IntroScreen(this, gi);
            inputState = new InputState();
            gameState = GameState.Intro;
            inputType = InputType.MouseKeyboard;
            
            //wiiMote.Connect();
            //wiiMote.SetLEDs(true, true, false, true);//test
            introScreen.Start();

            

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("Ufo");
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

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
            
            spriteBatch.Draw(texture, new Rectangle(Mouse.GetState().X - 49, Mouse.GetState().Y - 8, 98, 16), Color.White);
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

        public void StartGame()
        {
            gameScreen = new GameScreen(this, new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen));
            gameState = GameState.InGame;
        }




    }
}
