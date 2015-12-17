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

namespace SpaceHuntClasses
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    enum GameState {Menu, InGame}

    public class Main : Microsoft.Xna.Framework.Game
    {
        Texture2D texture;
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameComponent1 test;
        GameState gameState;
        MenuScreen menuScreen;
        Timer timer;
        public Texture2D scrollTrackBarTexture;
        public Texture2D trackBarTexture;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ChangeResolution(new Resolution(1920, 1080));
        }

        protected override void Initialize()
        {
            test = new GameComponent1(this);
            LoadContent();
            menuScreen = new MenuScreen(this);
            gameState = GameState.Menu;

            base.Initialize();
            Utility.Init(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("Ufo");
            scrollTrackBarTexture = Content.Load<Texture2D>("scrollTrackBar");
            trackBarTexture = Content.Load<Texture2D>("trackBarTexture");
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if(gameState == GameState.Menu)
            {
                menuScreen.Update(gameTime, Keyboard.GetState(), Mouse.GetState());
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if(gameState == GameState.Menu)
            {
                menuScreen.Draw(spriteBatch);
            }
            

            test.Draw(gameTime);
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
        }



    }
}
