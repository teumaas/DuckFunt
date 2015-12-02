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
        int Lettersize;
        bool BoolMenuEnabled = true;
        int StartLocY;
        string[] MenuItems = { "Start game", "Local Leadeboard", "Settings", "Itens" };
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            
            
          //  menu.MiddleX = GraphicsDevice.Viewport.Bounds.Width / 2;
           // menu.StartLocY = GraphicsDevice.Viewport.Bounds.Height / 4;
            
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
        private SpriteFont font;
        Menu menu;
        protected override void LoadContent()
        {

            
            font = Content.Load<SpriteFont>("MenuFont");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
           // spriteBatch.Begin();
         Menu menu = new Menu(Content, graphics, spriteBatch); // maakt een nieuw menu item en geeft alles door wat nodig is om items te spawnen
           // if (BoolMenuEnabled)
            //{
             //   menu.MenuEnabled(spriteBatch);  
            //}
            
           // Menu menu = new Menu();
            StartLocY = menu.StartLocY;
           // menu.MenuEnabled(true, spriteBatch);
            //spriteBatch.DrawString(font, "font", new Vector2(100, 100), Color.Black);
           // BG = Content.Load<Texture2D>("runway");
            
            Cross = Content.Load<Texture2D>("Crosshair");
            //spriteBatch.End();
         //   menu = new Menu(Content, graphics, spriteBatch);
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
                if (BoolMenuEnabled)
                {
                    // Bepaalt op welk item er geklikt is door middel van hoogte van de muis
                    for (int i = 0; i < MenuItems.Length; i++) 
                    {
                        if (currentMouseState.Y > (StartLocY + (i * 50))) 
                        {
                            Window.Title = "You clicked: " + MenuItems[i];
                            BoolMenuEnabled = false;
                            menu.LaunchItem(i);
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
        int CurY;
       
        int CrossSize = 75;
        Circle circle;
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //if (MenuEnabled)
            //{
            //    for (int i = 0; i < MenuItems.Length; i++)
            //    {
            //        spriteBatch.Begin();
            //        string TempMenuItem = MenuItems[i];
            //        Vector2 size = font.MeasureString(TempMenuItem);
            //        CurY = StartLocY + ((int)size.Y * i);
            //        spriteBatch.DrawString(font, TempMenuItem, new Vector2(MiddleX - Convert.ToInt32(size.X / 2), CurY), Color.Black);
            //        Lettersize = (int)size.X;
            //        spriteBatch.End();
            //    }
            //}

            
          //  Menu menu = new Menu(Content);
          
            //MenuEnabled(true, spriteBatch);
            circle = new Circle(100f, 100f, 20, graphics);
            circle.Draw();
            if (BoolMenuEnabled)
            {
                Menu menu = new Menu(Content, graphics, spriteBatch);
                menu.MenuEnabled(spriteBatch);
            }
            
            
                spriteBatch.Begin();
                CursorUpdater Crosshair = new CursorUpdater(); // Staat het programma toe muis coordinaten op te halen
                spriteBatch.Draw(Cross, new Rectangle(Crosshair.GetCursX() - CrossSize / 2, Crosshair.GetCursY() - CrossSize / 2, CrossSize, CrossSize), Color.White);
               // Bind de muis zijn x en y coordinaten aan het MIDDEN van de crosshair image (vandaar de gedeelt door 2) alles is gebaseerd op CrossSize dus het is met 1 int te wijzigen aan te passen
                
                spriteBatch.End();
                base.Draw(gameTime);
        }
       
        
        
        
     
    }
}
