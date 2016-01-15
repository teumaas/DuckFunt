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
using MenuMaking;
using SpaceHuntClasses.Screens;
using SpaceHuntClasses.Shapes;

namespace SpaceHuntClasses
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    enum GameState { Menu, InGame }
    enum InputType { Wiimote, MouseKeyboard }

    public class Main : Microsoft.Xna.Framework.Game
    {
        Texture2D texture;
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameComponent1 test;
        GameState state;
        MenuScreen menuScreen;
        private InputState inputState;
        private InputType inputType;
        private WiimoteLib.Wiimote wiiMote;
        Timer timer;
        public Texture2D scrollTrackBarTexture;
        public Texture2D trackBarTexture;
        private Texture2D crossHair;
        private Menu menu;
        public SpriteFont fontSize10;
        public SpriteFont fontSize14;
        
       

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
           //state = GameState.LbMenu;


        }

        protected override void Initialize()
        {
            test = new GameComponent1(this);
            LoadContent();
            menuScreen = new MenuScreen(this, new GraphicsInfos(new Resolution(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), graphics.IsFullScreen));
            inputState = new InputState();
            state = GameState.Menu;
            menu = new Menu(Content, graphics, spriteBatch , 0);
            inputType = InputType.MouseKeyboard;
            //wiiMote.Connect();
            //wiiMote.SetLEDs(true, true, false, true);//test

            base.Initialize();
            Utility.Init(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("Ufo");
            crossHair = Content.Load<Texture2D>("Crosshair");
            scrollTrackBarTexture = Content.Load<Texture2D>("scrollTrackBar");
            trackBarTexture = Content.Load<Texture2D>("trackBarTexture");
            fontSize10 = Content.Load<SpriteFont>("FontSize10");
            fontSize14 = Content.Load<SpriteFont>("FontSize14");
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

            menu.Update();
            //   menuScreen.Update(inputState, gameTime);


            base.Update(gameTime);
        }

        private int crossSize = 75;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            menu.Draw(spriteBatch);
            //if (state == GameState.Menu)
            //{
            //     menuScreen.Draw(spriteBatch);
            //    //menu.MenuEnabled(spriteBatch);
            //}
            //if (state == GameState.LbMenu)
            //{

            //}
            //if (state == GameState.Leaderboard)
            //{

            //}
            CursorUpdater Crosshair = new CursorUpdater(); // Staat het programma toe muis coordinaten op te halen
            spriteBatch.Draw(crossHair, new Rectangle(Crosshair.GetCursX() - crossSize / 2, Crosshair.GetCursY() - crossSize / 2, crossSize, crossSize), Color.White);

            // test.Draw(gameTime);
            //   spriteBatch.Draw(texture, new Rectangle(Mouse.GetState().X - 49, Mouse.GetState().Y - 8, 98, 16), Color.White);
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



    }
}
