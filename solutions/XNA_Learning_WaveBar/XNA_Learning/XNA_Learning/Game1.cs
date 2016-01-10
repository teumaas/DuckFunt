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
using Microsoft.Xna.Framework.Media;

using System.Threading;
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
        private SpriteFont font2;
        private SoundEffect sound;

        private Texture2D waveBarFrame;
        private Texture2D waveBarProgress;
        
        private Texture2D ufoImg;

        private Vector2 ufoDir;
        private Vector2 waveBar;
        private Vector2 waveText;
        private Rectangle barValue;
        private WiimoteCollection wMC;


        private Sprite sprite;
        private Sprite enemySprite;
        private Sprite waveBarFrameSprite;
        private Sprite waveBarProgressSprite;

        private Wiimote wm;
        private MouseState mouseState;

        private AccelState accelS;
        private Point3F p3;

        private float screanWidth;

        private Ufo ufo;
        public SpriteEffects flip;

        private float wY;
        private float wX;
        private float screenWidth;
        private float screenHeight;

        private int y;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1024;

            screanWidth = graphics.PreferredBackBufferWidth;

            graphics.IsFullScreen = false;

            Content.RootDirectory = "Content";

            p3 = new Point3F();
            accelS = new AccelState();
            wm = new Wiimote();
            y = 0;

            wm.Connect();
            wm.SetLEDs(true, false, false, false);
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
            wMC = new WiimoteCollection();
            flip = SpriteEffects.FlipHorizontally;
            mouseState = new MouseState();
            waveBar = new Vector2(260, 20);

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
            
            waveBarFrame = Content.Load<Texture2D>("waveBarFrame");
            waveBarProgress = Content.Load<Texture2D>("waveBarProgress");

            ufoImg = Content.Load<Texture2D>("img_hostile_common_1_resize");
            sprite = new Sprite(new Vector2(0, 0),
            Content.Load<Texture2D>("Crosshair"), screanWidth);
            ufo = new Ufo(ufoImg, Content.Load<Texture2D>("Crosshair"), wm, screanWidth);

            Content.Load<Texture2D>("Crosshair");
            ufo = new Ufo(Content.Load<Texture2D>("Ufo_Resized"), Content.Load<Texture2D>("Crosshair"), wm, screenWidth);

            font = Content.Load<SpriteFont>("SpriteFont1");
            font2 = Content.Load<SpriteFont>("SpriteFont2");
            sound = Content.Load<SoundEffect>("aud_pistol");

            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;

            try
            {
                wMC.FindAllWiimotes();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ufo.Initialize();
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
                this.Exit();
            }
            if (wm.WiimoteState.ButtonState.One && wm.WiimoteState.ButtonState.Two)
            {
                wm.Disconnect();
                this.Exit();
            }
            
            // TODO: Add your update logic here

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            mouseState = Mouse.GetState();

            wm.WiimoteState.IRState.IRSensors[0].RawPosition.X = (int)screanWidth - wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;

            sprite.location.X = mouseState.X;
            sprite.location.Y = mouseState.Y;

            ufo.Shoot(spriteBatch);
            sprite.velocity = new Vector2(0, 0);
            waveText = new Vector2(390, 330);

            sprite.location.X = mouseState.X; //wm.WiimoteState.IRState.IRSensors[0].Position.X; 
            sprite.location.Y = mouseState.Y;

            wX = mouseState.X;
            wY = mouseState.Y;

            barValue = new Rectangle(0, 0, ufo.addValue, 50);

            if (wm.WiimoteState.ButtonState.Home)
            {
                Exit();
            }

            if (wm.WiimoteState.ButtonState.B)
            {

            }

            sprite.Update(elapsed);

            ufo.Update(screanWidth, graphics.PreferredBackBufferHeight, wX, wY);
            ufo.Shoot(spriteBatch);

            ufo.Update(screenWidth, screenHeight, wX, wY);

            base.Update(gameTime);


        }

        protected void WaveCount()
        {


            if (ufo.addValue == 50)
            {
                spriteBatch.DrawString(font2, "Wave 2", waveText, Color.White);
            }
            if (ufo.addValue == 100)
            {
                spriteBatch.DrawString(font2, "Wave 3", waveText, Color.White);
            }
            if (ufo.addValue == 150)
            {
                spriteBatch.DrawString(font2, "Wave 4", waveText, Color.White);
            }
            if (ufo.addValue == 200)
            {
                spriteBatch.DrawString(font2, "Wave 5", waveText, Color.White);
            }
            if (ufo.addValue == 250)
            {
                spriteBatch.DrawString(font2, "Wave 6", waveText, Color.White);
            }
            if (ufo.addValue == 300)
            {
                spriteBatch.DrawString(font2, "Wave 7", waveText, Color.White);
            }
            if (ufo.addValue == 350)
            {
                spriteBatch.DrawString(font2, "Wave 8", waveText, Color.White);
            }
            if (ufo.addValue == 400)
            {
                spriteBatch.DrawString(font2, "Wave 9", waveText, Color.White);
            }
            if (ufo.addValue == 450)
            {
                spriteBatch.DrawString(font2, "Wave 10", waveText, Color.White);
            }
            if (ufo.addValue == 500)
            {
                spriteBatch.DrawString(font2, "Done!", waveText, Color.White);
            }
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
            sprite.Draw(spriteBatch, wX, wY);

            ufo.Draw(spriteBatch);

            ufo.Draw(spriteBatch);
            
            sprite.Draw(spriteBatch, wX, wY);
            spriteBatch.DrawString(font, wY.ToString(), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(font, wX.ToString(), new Vector2(10, 30), Color.White);
            WaveCount();
            spriteBatch.DrawString(font, ufo.score.ToString(), new Vector2(870, 10), Color.White);
            spriteBatch.Draw(waveBarProgress, waveBar, barValue, Color.White);
            spriteBatch.Draw(waveBarFrame, waveBar, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}