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


namespace MenuMaking
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    
    {
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            // Make changes to handle the new window size.            
        }
        

        int lettersize;
        bool boolMenuEnabled = true;
        private delegate void UpdateWiimoteStateDelegate(WiimoteChangedEventArgs args);

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D crossHair;
        private Texture2D backGround;
        private Weapons weapons;
        private SpriteFont font;
        private SoundEffect sound;
        private MouseState oldMouseState, currentMouseState;

        private Texture2D ufoImg;

        private Vector2 ufoDir;
        private WiimoteCollection wMC;
        Menu menu;

        private Sprite sprite;
        private Sprite enemySprite;
        private Wiimote wm;

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
        int startLocY;
        string[] menuItems = { "Start game", "Local Leadeboard", "Settings", "Itens" };
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1024;

            screanWidth = graphics.PreferredBackBufferWidth;

            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            //StartLocY = menu.StartLocY;
            p3 = new Point3F();
            accelS = new AccelState();
            wm = new Wiimote();
            y = 0;

            wm.Connect();
            wm.SetLEDs(true, false, false, false);
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

            // TODO: Add your initialization logic here
           // Menu menu = new Menu(Content, graphics, spriteBatch);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {// Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            ufoImg = Content.Load<Texture2D>("Crosshair");
            sprite = new Sprite(new Vector2(0, 0),
            Content.Load<Texture2D>("Crosshair"), screanWidth);
            ufo = new Ufo(ufoImg, Content.Load<Texture2D>("img_hostile_common_1_resize"), wm, screanWidth);

            Content.Load<Texture2D>("Crosshair");
            ufo = new Ufo(Content.Load<Texture2D>("img_hostile_common_1_resize"), Content.Load<Texture2D>("Crosshair"), wm, screenWidth);

            font = Content.Load<SpriteFont>("SpriteFont1");
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
            this.Window.AllowUserResizing = true;
            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            rect = new Rectangle(0, 0, 100, 100);
           // drawableRectangle = new Texture2D(GraphicsDevice, 1, );
            colori = Color.White;
           // Font moet vooraf geinstalleerd zijn, font staat in recourses
            font = Content.Load<SpriteFont>("MenuFont");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           // spriteBatch.Begin();
            Menu menu = new Menu(Content, graphics, spriteBatch); // maakt een nieuw menu item en geeft alles door wat nodig is om items te spawnen
            startLocY = menu.startLocY;
            crossHair = Content.Load<Texture2D>("Crosshair");
            backGround = Content.Load<Texture2D>("earth_BG_MainMenu");

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

            wm.WiimoteState.IRState.IRSensors[0].RawPosition.X = (int)screanWidth - wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;

            sprite.location.X = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            sprite.location.Y = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;

            ufo.Shoot(spriteBatch);
            sprite.velocity = new Vector2(0, 0);

            sprite.location.X = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X; //wm.WiimoteState.IRState.IRSensors[0].Position.X; 
            sprite.location.Y = wm.WiimoteState.IRState.IRSensors[2].RawPosition.Y;

            wX = wm.WiimoteState.IRState.IRSensors[0].RawPosition.X;
            wY = wm.WiimoteState.IRState.IRSensors[0].RawPosition.Y;

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

            // TODO: Add your update logic here
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released) // Als mouse butten gereleased is
            {
                if (boolMenuEnabled)
                {
                    // Bepaalt op welk item er geklikt is door middel van hoogte van de muis
                    for (int i = 0; i < menuItems.Length; i++) 
                    {
                        if (currentMouseState.Y > (startLocY + (i * 50))) 
                        {
                            Window.Title = "You clicked: " + menuItems[i];
                            boolMenuEnabled = false;
                            OnMainMenuClick(i);
                        }
                    }
                }
                
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        int curY;
       
        int crossSize = 75;
        Rectangle rect;
        Texture2D drawableRectangle;
        Color colori;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //while (true)
            //{
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(backGround, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
            spriteBatch.End();

            if (boolMenuEnabled)
            {
                Menu menu = new Menu(Content, graphics, spriteBatch);
                menu.MenuEnabled(spriteBatch);
            }
                spriteBatch.Begin();
                CursorUpdater Crosshair = new CursorUpdater(); // Staat het programma toe muis coordinaten op te halen
                spriteBatch.Draw(crossHair, new Rectangle(Crosshair.GetCursX() - crossSize / 2, Crosshair.GetCursY() - crossSize / 2, crossSize, crossSize), Color.White);
               // Bind de muis zijn x en y coordinaten aan het MIDDEN van de crosshair image (vandaar de gedeelt door 2) alles is gebaseerd op CrossSize dus het is met 1 int te wijzigen aan te passen
                
                spriteBatch.End();
                base.Draw(gameTime);
        }
        void OnMainMenuClick(int item)
        {
           Menu menu = new Menu(Content, graphics, spriteBatch);
            menu.LaunchItem(item);
        }
       
        
        
        
     
    }
}
