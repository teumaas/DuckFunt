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
using TableDrawer;

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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D crossHair, backGround;
        private LeaderBoardMenu Input;
        int lettersize, startLocY;
        bool boolMenuEnabled = false;
        bool enableLeaderboard = false;
        public static bool ScoreEnabled = false;
        string[] menuItems = { "Start game", "Local Leadeboard", "Settings", "Itens" };

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            //%%%%% TableManager DrawTable = new TableManager(new Vector2(20, 20), graphics , this ); //works how to to passs this in other class/method
            //StartLocY = menu.StartLocY;
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
           // Menu menu = new Menu(Content, graphics, spriteBatch);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public SpriteFont font;
        Menu menu;
        protected override void LoadContent()
        {
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
            Input = new LeaderBoardMenu(spriteBatch, graphics, Content, new Vector2(20, 20));
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

        private MouseState oldMouseState, currentMouseState;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            
            if (currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released) // Als mouse butten gereleased is
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
           // Input.Draw();
            SaveData temp = new SaveData();
            temp.kills = 2000;
            temp.rounds = 2;
            temp.shotsFired = 2;
         //   Input.PromptSave(temp);
            Input.Draw();
            if (boolMenuEnabled)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(backGround, new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.End();
                Menu menu = new Menu(Content, graphics, spriteBatch);
                menu.MenuEnabled(spriteBatch);
            }
            
            
               
                if (ScoreEnabled)
                {
                    TableManager scoretable = new TableManager(graphics, Content, spriteBatch);
                    scoretable.DrawTables(new Vector2(90, 20));
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

        public void ViewLeaderboard()
        {
           // TableManager DrawLeaderBoard = new TableManager(graphics, Content); // hier gaat het mis!!!
         //   DrawLeaderBoard.DrawTables(spriteBatch, new Vector2(20, 20));
        }




    }
}
