﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceHuntClasses;
using TableDrawer;


namespace MenuMaking
{
    class Menu //: Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Color textColor;
        public Color colorBG;
        private SpriteFont font;
        private MouseState currentMouseState;
        private MouseState oldMouseState;
        int lettersize;
        SpriteBatch sprites;
        string[] menuItems = { "Start game", "Local Leadeboard", "Settings", "Items" };
        GraphicsDeviceManager graphics;
        ContentManager content;
        private LeaderBoardMenu lbMenu;
        private HighScoresSaveManager saveManager;
        private TableManager tblManager;
        public int middleX;
        public int startLocY;
        Rectangle rectBG;
        //public enum GameState
        //{
        //    InGame, //start game
        //    Intro,
        //    Menu,
        //    Options, //Settings
        //    Loading,
        //    Exit, //Exit
        //    Leaderboard, //Local Leaderboard
        //    Dead,
        //}
        public static int where { get; set; }
        Texture2D backGroundtexture;
        private bool fullscreen = false;
        public Menu(ContentManager content, GraphicsDeviceManager graphDeviceManager, SpriteBatch spriteBatch, int waar)
        {
            this.sprites = spriteBatch;
            this.graphics = graphDeviceManager;
            this.content = content;
           // Sp v vcvvvvxbvvvvvvvvvvvvvvvvvvbbbbbbbbbbbbbvgv bgaceHuntClasses.Main.GameState.Leaderboard;
            LoadContent();
            where = waar;
            lbMenu.PromptSave(new SaveData());
        }

        public void Draw()
        {

            //switch (GameState)
            //{
            //    case GameState.Menu:

            //        break;
            //    case GameState.Leaderboard:

            //        break;
            //    case GameState.Dead:
                    
            //        break;
            //}
        }

        public void BuildBG(Color color, int LocationX, int LocationY, int width, int height)
        {
            
            rectBG = new Rectangle(LocationX, LocationY, width, height);
            sprites.Begin();

            backGroundtexture = new Texture2D(graphics.GraphicsDevice , 1 , 1);
            backGroundtexture.SetData(new[] { color });
            sprites.Draw(backGroundtexture, rectBG, color);
            sprites.End();
        }
        public void LoadContent()
        {
         //   graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = fullscreen;
            textColor = new Color(); //foreground
            textColor.R = 65;
            textColor.G = 103;
            textColor.B = 136;
            textColor.A = 200;
            
          //  GameState bla = new GameState;
            colorBG = new Color();
            colorBG.R = 0;
            colorBG.G = 244;
            colorBG.B = 200;
            colorBG.A = 180; //transpa
          // graphics.ApplyChanges();   
            sprites = new SpriteBatch(graphics.GraphicsDevice);
            font = content.Load<SpriteFont>("MenuFont");
            middleX = graphics.GraphicsDevice.Viewport.Width / 2; // Midden is het helft van de breedte van het beeldscherm
            startLocY = graphics.GraphicsDevice.Viewport.Height  / 4; // Begin op 1 4de van het beeldscherms lengte met het menu
            tblManager = new TableManager(graphics, content, sprites);
            saveManager = new HighScoresSaveManager("LeaderBoard_Savedata.1337");
            lbMenu = new LeaderBoardMenu(sprites,graphics, content, new Vector2(graphics.GraphicsDevice.Viewport.Width/2,graphics.GraphicsDevice.Viewport.Height/2) );
        }
       
        public void OnHover(int HoveringAbove)
        { 
        
        }
        public void LaunchItem(int OnClick)
        {
            
            switch (OnClick)
            {
                case 0:
                    break;
                case 1:
              //     TableManager scoretable = new TableManager(graphics, content , sprites);
            //        scoretable.DrawTables(new Vector2(0,0));
                   // state = GameState.
                //    Game1.ScoreEnabled = true;
                    break;
                    
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        int CurY;
        private int offset;
        public void Draw(SpriteBatch spriteBatch)
        {
            if (where == 0)
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    string TempMenuItem = menuItems[i];
                    //Color temp = new Color();
                    //temp.R = 0;
                    //temp.G = 244;
                    //temp.B = 200;
                    //temp.A = 180; //transpa
                    Vector2 size = font.MeasureString(TempMenuItem);
                    CurY = startLocY + ((int)size.Y * i) + offset;
                    BuildBG(colorBG, ((middleX - ((int)size.X / 2)) - 2), CurY - 5, (int)size.X + 3, (int)size.Y + 3); // Pakt de tekstgrootte + een paar pixels verschil voor de looks
                    sprites.Begin();
                    //Color TextColor = new Color();
                    //TextColor.R = 65;
                    //TextColor.G = 103;
                    //TextColor.B = 136;
                    //TextColor.A = 200;
                    offset += 10;
                    sprites.DrawString(font, TempMenuItem, new Vector2(middleX - Convert.ToInt32(size.X / 2), CurY), textColor);
                    //  startLocY += 10;
                    lettersize = (int)size.X;

                    sprites.End();
                }
                CurY = startLocY;
                offset = 0;   
            }
            if (where == 1)
            {
                tblManager.DrawTables(new Vector2(10,10));
            }
            if (where == 2)
            {
                lbMenu.Draw();
            }
            if (where == 3)
            {
                
            }
                


        }

        public void Update()
        {
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                // Als mouse butten gereleased is
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (currentMouseState.Y > (startLocY + (i * 50)) && currentMouseState.Y < (startLocY + (i * 50) + 50))
                    {
                        //  this.Title = "You clicked: " + menuItems[i];
                        LaunchItem(i);
                        where = i;
                        //  boolMenuEnabled = false;
                        // OnMainMenuClick(i);

                    }
                }
            }
        }

        public void Effect(int ItemNo)
        { 
        
        }



    }
}
