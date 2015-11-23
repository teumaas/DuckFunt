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
using System.IO;


namespace intro_DuckFunt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle textBox;
        SpriteFont font;
        String text;
        String parsedText;
        String typedText;
        SoundEffect snd;
        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        SoundEffectInstance soundEffectInstance;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            textBox = new Rectangle(10, 10, 300, 300);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("spriteFont1");
            text = File.ReadAllText("story.txt");
            snd = Content.Load<SoundEffect>("click2");
            soundEffectInstance = snd.CreateInstance();
            parsedText = parseText(text);
            delayInMilliseconds = 50;
            isDoneDrawing = false;
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (!isDoneDrawing)
            {
                if (delayInMilliseconds == 0)
                {
                    typedText = parsedText;
                    isDoneDrawing = true;
                }
                else if (typedTextLength < parsedText.Length)
                {
                    typedTextLength = typedTextLength + gameTime.ElapsedGameTime.TotalMilliseconds / delayInMilliseconds;
                    if (typedTextLength >= parsedText.Length)
                    {
                        typedTextLength = parsedText.Length;
                        isDoneDrawing = true;
                    }
                    
                    typedText = parsedText.Substring(0, (int)typedTextLength);
                    
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, typedText, new Vector2(textBox.X, textBox.Y), Color.White);
            soundEffectInstance.Play();
            spriteBatch.End();
            

            base.Draw(gameTime);
        }

        private String parseText(String text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (font.MeasureString(line + word).Length() > textBox.Width)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }
            return returnString + line;
        }

    }
}