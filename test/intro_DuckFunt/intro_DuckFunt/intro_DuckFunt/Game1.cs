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

namespace intro_DuckFunt
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Texture2D txt2d;
        Rectangle rect;
        Vector2 vec2;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            int i = 0;
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            string txt = System.IO.File.ReadAllText("story.txt");
            char[] text = new char[txt.Length];

            
            rect = new Rectangle(0,0,851, 1580);
            

            foreach (char letter in txt)
            {
                text[i] = letter;
                i++;

                spriteFont = Content.Load<SpriteFont>(letter.ToString());
        
                vec2 = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2,
                    graphics.GraphicsDevice.Viewport.Height / 2);
            }
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            base.Draw(gameTime);
        }
    }
}
