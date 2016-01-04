using System;
using WiimoteLib;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace wii_mote_test
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font1;
        Wiimote mote;
        Rectangle enemyRec;
        Rectangle destRec;
        Rectangle crossRec;
        Vector2 v2;
        Texture2D enemy;
        Texture2D cross;
        WiimoteState ws;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mote = new Wiimote();
            enemyRec = new Rectangle(10, 10, 150, 100);
            ws = new WiimoteState();
            mote.WiimoteChanged += mote_WiimoteChanged;
            font1 = new SpriteFont();
            v2 = new Vector2(0, 0);
        }

        private void mote_WiimoteChanged(object sender, WiimoteChangedEventArgs e)
        {

        }


        protected override void Initialize()
        {
            enemy = Content.Load<Texture2D>("Ufo");
            cross = Content.Load<Texture2D>("Crosshair");
            crossRec = new Rectangle(200, 200, 50, 50);
            destRec = new Rectangle(0, 0, enemy.Width, enemy.Height);
            mote.Connect();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            mote.SetLEDs(true,false,false,false);
        
            mote.InitializeMotionPlus();
            ws.IRState.Mode = IRMode.Full;
            mote.SetReportType(InputReport.ReadData, 0, true);

            
            
            v2 += new Vector2(-1f, -1f);
            
            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(enemy, enemyRec, destRec,Color.White,0f,v2,SpriteEffects.None,0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
