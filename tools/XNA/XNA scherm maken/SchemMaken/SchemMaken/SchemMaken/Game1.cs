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

namespace SchemMaken
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch; // The SpriteBatch class allow us to draw graphics.
        Texture2D texture; // a sample image
        Rectangle destinationRectangle; // a sample rectangle
        Color whiteColor;
        SpriteFont textFont;
        Vector2 vector;
        Sprite sprite;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            destinationRectangle = new Rectangle(0, 0, 300, 200);
            whiteColor = Color.White;
            vector = new Vector2(350, 350);
        }

        protected override void Initialize()
        {
            base.Initialize();
            sprite = new Sprite(texture, vector, 300, 200);
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("pngs/ImageTest"); //this method is really important, it load a image from the content pipeline
            textFont = Content.Load<SpriteFont>("fonts/SpriteFontTest");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            sprite.MoveToPosition(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue); //this method clear the screen and apply a new background

            spriteBatch.Begin(); // this method must be called before drawing graphics (already called by default)

            spriteBatch.Draw(texture, destinationRectangle, whiteColor); 
            //this method need : - a texture : this texture must first be loaded in the contentLoad method
            //                   - a destination rectangle : this rectangle set the object bound (x, y, with, height)
            //                   - a color : if the color of the texture dont need any changes, a white color is needed (Color.White)

            spriteBatch.DrawString(textFont, "test", vector, Color.Black); //Draw a simpple text (the text font need to be loaded first)

            sprite.Draw(spriteBatch);

            spriteBatch.End(); // this method must be called after drawing graphics (already called by default)

            base.Draw(gameTime);
        }
    }
}
