using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using Microsoft.Xna.Framework.Media;
using WiimoteLib;
namespace XNA_Learning
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private SoundEffect sound;

        private Sprite sprite;
        private Sprite enemySprite;
        private Wiimote wm;

        private float wY;
        private float wX;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 900;

            graphics.IsFullScreen = false;

            Content.RootDirectory = "Content";

            wm = new Wiimote();

            wm.Connect();
            wm.SetLEDs(true, true, false, true);
            //wm.WiimoteState.

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
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            sprite = new Sprite(new Vector2(0, 0),
            Content.Load<Texture2D>("Crosshair"));
            font = Content.Load<SpriteFont>("SpriteFont1");
            sound = Content.Load<SoundEffect>("aud_pistol");

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
            // TODO: Add your update logic here

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            sprite.velocity = new Vector2(0, 0);

            sprite.location.X = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            sprite.location.Y = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;

            wX = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X * 7000;
            wY = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y * 6000;

            if (wm.WiimoteState.ButtonState.Home)
            {
                Exit();
            }
          
            if (wm.WiimoteState.ButtonState.B)
            {
                wm.PlayAudioFile(@"C:\Users\Tom\Dropbox\XNA\XNA_Learning\XNA_Learning\XNA_LearningContent\aud_pistol.wav");
            }
            

            sprite.Update(elapsed);
            base.Update(gameTime);

            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            sprite.Draw(spriteBatch);
            spriteBatch.DrawString(font, wY.ToString(), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, wX.ToString(), new Vector2(10, 30), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
