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
        private SplashScreen _splashScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //graphics.GraphicsDevice.Viewport.Height = 100;
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
            _splashScreen = new SplashScreen(this, spriteBatch, new Vector2(graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Content, graphics);
           
            //s
            // TODO: use this.Content to load your game content here
            //  GameState state = GameState.Default;
          //  _splashScreen.screenSize = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
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

      //  private readonly SplashScreen _splashScreen;

        protected override void Draw(GameTime gameTime)
        {
           // _splashScreen.Draw(gameTime);
            _splashScreen.Draw();
        }
    }
}
