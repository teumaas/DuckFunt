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
    class Menu //: Microsoft.Xna.Framework.DrawableGameComponent
    {
        
        private SpriteFont font;
        int Lettersize;
        SpriteBatch sprites;
        bool BoolMenuEnabled = true;
        string[] MenuItems = { "Start game", "Local Leadeboard", "Settings", "Items" };
        GraphicsDeviceManager graphics;
        ContentManager content;
        public int MiddleX;
        public int StartLocY;
        public Menu(ContentManager content, GraphicsDeviceManager GraphDeviceManager, SpriteBatch spriteBatch)
        //public Menu(Game gotgame)
        {
            this.sprites = spriteBatch;
            this.graphics = GraphDeviceManager;
            this.content = content;
            LoadContent();
        }
        public void Draw()
        {
            //graphics.GraphicsDevice.DrawUserPrimitives
            //       (PrimitiveType.LineStrip, vertices, 0, vertices.Length - 1);
        }
        public void LoadContent()
        {
            
            sprites = new SpriteBatch(graphics.GraphicsDevice);
            font = content.Load<SpriteFont>("MenuFont");

            MiddleX = graphics.GraphicsDevice.Viewport.Width / 2; // Midden is het helft van de breedte van het beeldscherm
            StartLocY = graphics.GraphicsDevice.Viewport.Height  / 4; // Begin op 1 4de van het beeldscherms lengte met het menu
        }
       
        public void OnHover(int HoveringAbove)
        { 
        
        }
        public void LaunchItem(int OnClick)
        { 
        
        }
        int CurY;
        public void MenuEnabled(SpriteBatch spriteBatch)
        {
            
                for (int i = 0; i < MenuItems.Length; i++)
                {
                    //  spriteBatch.Begin();
                    sprites.Begin();
                    string TempMenuItem = MenuItems[i];
                    Vector2 size = font.MeasureString(TempMenuItem);
                    CurY = StartLocY + ((int)size.Y * i);
                    
                    sprites.DrawString(font, TempMenuItem, new Vector2(MiddleX - Convert.ToInt32(size.X / 2), CurY), Color.Black);
                    //   sprites.DrawString(font, TempMenuItem, new Vector2(0, 0), Color.Black);
                    //   spriteBatch.DrawString(font, TempMenuItem, new Vector2(MiddleX - Convert.ToInt32(size.X / 2), CurY), Color.Black);
                    Lettersize = (int)size.X;
                    sprites.End();
                    // spriteBatch.End();
                }
            
            
        }
        public void Effect(int ItemNo)
        { 
        
        }
        public string MenuItem(float x, float y, int radius)    
        {
            return "swf";
        }
    }
}
