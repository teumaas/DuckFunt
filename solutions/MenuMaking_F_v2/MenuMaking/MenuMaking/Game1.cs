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

namespace MenuMaking
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Cross;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        private SpriteFont font;
        int MiddleX;
        int StartLocY;
        protected override void LoadContent()
        {
            MiddleX = GraphicsDevice.Viewport.Bounds.Width / 2;
            StartLocY = GraphicsDevice.Viewport.Bounds.Height / 4;
            font = Content.Load<SpriteFont>("MenuFont");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch.Begin();

            spriteBatch.DrawString(font, "font", new Vector2(100, 100), Color.Black);
           // BG = Content.Load<Texture2D>("runway");

            Cross = Content.Load<Texture2D>("Crosshair");
            spriteBatch.End();
            Menu(true);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        int CurY;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //spriteBatch.DrawString(font, "23", new Vector2(50, 50), Color.Black);
            // TODO: Add your drawing code here

          //  spriteBatch.Begin();

          ////  spriteBatch.DrawString(font, "font", new Vector2(100, 100), Color.Black);

          //  spriteBatch.End();
            string[] MenuItems = { "Start game", "Local Leadeboard", "Settings" };
           
                for (int i = 0; i < MenuItems.Length; i++)
                {
                    spriteBatch.Begin();
                    string tempitem = MenuItems[i];
                    Vector2 size = font.MeasureString(tempitem);
                   // StartLocY = StartLocY + Convert.ToInt32(size.Y);
                    CurY = StartLocY + ((int)size.Y * i);
                    spriteBatch.DrawString(font, tempitem, new Vector2(MiddleX - Convert.ToInt32(size.X /2) , CurY), Color.Black);
                    spriteBatch.End();
                }
                spriteBatch.Begin();
                CursorUpdater Crosshair = new CursorUpdater();
                int CrossSize = 50;
                spriteBatch.Draw(Cross, new Rectangle(Crosshair.GetCursX() - CrossSize / 2, Crosshair.GetCursY() - CrossSize / 2, CrossSize, CrossSize), Color.White);
                spriteBatch.End();
            
            base.Draw(gameTime);
        }
       
        void Menu(bool enabled)
        {
            
        }
        
        void SpawnMenuItem(int CenteredX, int Y, int Num)
        {
            
        }
        void OnClickItem(int Num)
        { 
            
        }
    }
}
