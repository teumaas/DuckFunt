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
using WiimoteLib;
using System.Management;
using MenuMaking;
using TableDrawer;

namespace SpaceHunt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SpaceHunt : Microsoft.Xna.Framework.Game
    {

        Controls controls; //Controls 
        private CursorUpdater cursorUpdater;
        private Screens screens;//Screens
        private WiimoteHandler wiimoteHandler;//WiimoteHandler
        private MessageBox messageBox;//Messagebox
        private Timer timer;//Timer
        private Shape shape;//Shape
        private GameState state; //Gamestate
        private Wiimote wiimote;
        LeaderBoardMenu lbMenu;
        private TableDrawManager tableDraw;
        private MenuScreen menu;
        public SpriteBatch spriteBatch;
        public GraphicsDeviceManager graphics;
      //private LeaderBoardMenu;

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            // Make changes to handle the new window size.            
        }

        public enum GameState
        {
            InGame, //start game
            Intro,
            Menu,
            Options, //Settings
            Loading,
            Exit, //Exit
            Leaderboard, //Local Leaderboard
            LbMenu,
            Default
        }

      
        public SpaceHunt()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            state = GameState.Intro;

            if (state == GameState.Intro)
            {
                
            }
            if (state == GameState.Leaderboard)
            {

            }

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {// Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            
            // Create a new SpriteBatch, which can be used to draw textures.
            lbMenu = new LeaderBoardMenu(spriteBatch, graphics, Content, new Vector2(20,20));
            menu = new MenuScreen(Content,graphics, spriteBatch);
            tableDraw = new TableDrawManager(graphics,Content,spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                Environment.Exit(0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Environment.Exit(0);
            }

            ///
            ///if wiimote is not connected it will throw nullexeptionerror
            ///

            //if (wiimote.WiimoteState.ButtonState.One && wiimote.WiimoteState.ButtonState.Two)
            //{
            //    wiimote.Disconnect();
            //    Environment.Exit(0);
            //}
            
            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.Black);
            switch (GameState)
            {
                case GameState.Menu:
                    menu.MenuEnabled(spriteBatch);
                    break;
                case GameState.Leaderboard:
                    tableDraw.DrawTables(new Vector2(20,20));
                    break;
                case GameState.LbMenu:
                    //lbMenu.PromptSave()
                    break;

            }
            base.Draw(gameTime);
        }
    }
}
