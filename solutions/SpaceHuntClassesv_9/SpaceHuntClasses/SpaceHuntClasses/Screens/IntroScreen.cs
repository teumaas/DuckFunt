using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SpaceHuntClasses.MessageBoxs;
using SpaceHuntClasses.Shapes;
using SpaceHuntClasses.Shapes.Labels;
using System.IO;

namespace SpaceHuntClasses.Screens
{
    class IntroScreen : IScreen
    {
        private Main main;
        private ShapeAnimated heroShape;
        private Label label;
        private Timer textTimer;
        private Timer shapeTimer;
        private DarkBackgroundAnimation backgroundAnimation;
        private string text;
        private Texture2D heroTexture;


        public IntroScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            LoadContent();
            text = File.ReadAllText("story.txt");
            label = new Label(graphics, main.fontSize10, new Vector2(50, 50), "");
            textTimer = new Timer(50);
            textTimer.Tick += TextTimerOnTick;
            shapeTimer = new Timer(500);
            shapeTimer.Tick += ShapeTimerOnTick;

            //need to be recode by anthony
            heroShape = new ShapeAnimated(graphics, heroTexture, new Rectangle(50, 50, 0, 0), new Rectangle(0, 0, 78, 50));
            heroShape.rectangle.Width = 26;
            heroShape.rectangle.Height = 50;
            heroShape.sourceRectangle = new Rectangle(0, 0, 26, 50);
            backgroundAnimation = new DarkBackgroundAnimation(graphics, 0.001f);
            //.

            //Start();
        }

        public void LoadContent()
        {
            heroTexture = main.Content.Load<Texture2D>("textures/sprites/spritesIntro");
        }

        public void Update(InputState input, GameTime gameTime)
        {
            textTimer.Update(gameTime);
            shapeTimer.Update(gameTime);
            backgroundAnimation.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            backgroundAnimation.Draw(spriteBatch);
            label.Draw(spriteBatch);
            heroShape.Draw(spriteBatch);
            
        }

        public void TextTimerOnTick(object sender, EventArgs e)
        {
            if (label.text.Count() < text.Count())
            {
                if (text[label.text.Count()] == ' ')
                    label.text += text[label.text.Count()];
                label.text += text[label.text.Count()];
            }
            else
                Leave();

        }

        public void ShapeTimerOnTick(object sender, EventArgs e)
        {
            heroShape.NextClip();//Next frame
        }

        public void Start()
        {
            textTimer.Start();
            shapeTimer.Start();
            backgroundAnimation.Start();
        }

        private void Leave()//go to the main menu
        {
            main.StartMenu();
        }
    }
}
