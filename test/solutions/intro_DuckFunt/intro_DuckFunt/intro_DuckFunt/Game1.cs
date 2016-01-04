#define DELAY
#define PARSE

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
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace intro_DuckFunt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteBatch heroBatch;
        Rectangle textBox;
        Rectangle back;
        Rectangle destRec;
        Rectangle heroRec;
        Texture2D pic;
        Texture2D heroSheet;
        SpriteFont font;
        String text;
        String parsedText;
        String typedText;
        SoundEffect snd;
        Vector2 pos;
        SoundEffectInstance soundEffectInstance;
        Fade fade;
        Color color;

        double typedTextLength;
        int delayInMilliseconds;
        bool isDoneDrawing;
        float elapsed;
        float delay = 300f;
        int i;
        int frames;
        int oneFrame;
        int recWidth;
        int recHeight;
        int frameHeight;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            frames = 1;
            frameHeight = 50;
            heroSheet = Content.Load<Texture2D>("sprites");
            textBox = new Rectangle(100, 50, 32, 32);
            back = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            pos = new Vector2(0, 0);
            color = Color.White;
            oneFrame = heroSheet.Width / 3;

            recWidth = oneFrame / 3;
            recHeight = frameHeight / 3;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            heroBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("spriteFont1");
            text = File.ReadAllText("story.txt");
            snd = Content.Load<SoundEffect>("click2");
            pic = Content.Load<Texture2D>("earth");
            fade = new Fade(pic, pos, back);
            soundEffectInstance = snd.CreateInstance();
            parsedText = parseText(text);
            delayInMilliseconds = 25;
            isDoneDrawing = false;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            fade.DrawFade(gameTime, spriteBatch, elapsed);

            if (pos.Y >= -50 && typedTextLength >= 200 && i >= 154)
            {
                pos += new Vector2(-0.0f, -0.15f);

                if (elapsed >= delay)
                {
                    if (recHeight >= 46)
                    {
                        recHeight += 1;
                        recWidth += 1;
                    }
                    recWidth += 2;
                    recHeight += 3;
                    if (frames >= 2)
                    {
                        frames = 1;
                    }
                    else
                    {
                        frames++;
                    }
                    elapsed = 0;
                }
            }
            else
            {
                frames = 0;
            }


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



            if (typedTextLength >= 250 && typedTextLength <= 400)
            {
                textBox.Y--;
            }

            heroRec = new Rectangle(GraphicsDevice.Viewport.Width / 2, 300, recWidth, recHeight);
            destRec = new Rectangle(oneFrame * frames, 0, oneFrame, frameHeight);

            fade.DeleteDraw(spriteBatch);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(pic, back, color);
            spriteBatch.DrawString(font, typedText, new Vector2(textBox.X, textBox.Y), Color.White);
            spriteBatch.End();

            heroBatch.Begin();
            heroBatch.Draw(heroSheet, heroRec, destRec, Color.White, 0f, pos, SpriteEffects.None, 0f); //    new rectangle instance magic numbers
            heroBatch.End();

            base.Draw(gameTime);
        }



#if PARSE
        private String parseText(String text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (font.MeasureString(line + word).Length() > textBox.Width)
                {
                    returnString = returnString + line;
                    line = String.Empty;
                }

                line = line + word + ' ';
            }
            return returnString + line;
        }
#endif

#if DELAY
        public static Task Delay(double milliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += (o, e) => tcs.TrySetResult(true);
            timer.Interval = milliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
#endif
    }
}