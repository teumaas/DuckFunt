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
using SpaceHunt.Classes;

namespace SpaceHunt
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch sb;
        Enemy enemy;
        ShapeInteractive ufoShapeInteractive;
        ShapeAnimated ufoDeadShapeAnimated, alienShapeAnimated;
        Texture2D tex2d;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            tex2d = Content.Load<Texture2D>("img_hostile_common_1");
            ufoShapeInteractive = new ShapeInteractive(tex2d, new Rectangle(50, 50, tex2d.Width, tex2d.Height));
            alienShapeAnimated = new ShapeAnimated(tex2d, ufoShapeInteractive.rectangle, ufoShapeInteractive.rectangle, 100, 100, null);
            ufoDeadShapeAnimated = new ShapeAnimated(tex2d, ufoShapeInteractive.rectangle, ufoShapeInteractive.rectangle, 100, 100, null
            enemy = new Enemy(100, 0.1f, ufoShapeInteractive, ufoDeadShapeAnimated, alienShapeAnimated);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            sb = new SpriteBatch(GraphicsDevice);
            
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
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            sb.Begin();
            
            sb.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
