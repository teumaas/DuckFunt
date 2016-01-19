using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SplashScreen
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D Splashscreen;
        private Vector2 screenSize;
        private bool cycling = true;
        private int offset = 1;
        public bool done { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //  states = states.cycling;
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Splashscreen = Content.Load<Texture2D>("Splash_SpaceHunt");
            // TODO: use this.Content to load your game content here
            //  GameState state = GameState.Default;
            screenSize = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private int offseteffect = 1;

        private int finaleffect;

        protected override void Draw(GameTime gameTime)
        {
            var width = 2048;
            var height = 274;

            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (offset > 2048 || offset == 0)
            {
                cycling = false;
                offset = 0;
            }
            if (offset != 0)
            {
                offset += 8;
            }

            if (cycling)
            {
                spriteBatch.Draw(Splashscreen, new Rectangle(0 - offset, 0, width, height), Color.White);
            }
            else if (!done && !cycling)
            {
                if (offseteffect != 0)
                {
                    spriteBatch.Draw(Splashscreen,
                        new Rectangle(0 - offset, 0, GraphicsDevice.Viewport.Width - offseteffect,
                            GraphicsDevice.Viewport.Height - offseteffect), Color.White);
                    offseteffect += 4;
                    finaleffect = offseteffect;
                }
                if (offseteffect > GraphicsDevice.Viewport.Height/3)
                {
                    offseteffect = 0;
                }
                if (offseteffect == 0)
                {
                    offset += 4;
                    spriteBatch.Draw(Splashscreen,
                        new Rectangle(0 + offset, 0, GraphicsDevice.Viewport.Width - finaleffect,
                            GraphicsDevice.Viewport.Height - finaleffect), Color.White);
                    if (offset > 2000)
                    {
                        done = true;
                    }
                }
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
