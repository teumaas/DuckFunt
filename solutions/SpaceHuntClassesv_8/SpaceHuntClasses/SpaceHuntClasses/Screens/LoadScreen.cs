using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Screens
{
    class LoadScreen : IScreen
    {
        private Main main;
        private ShapeSource firstPlanetShape;
        private ShapeSource secondPlanetShape;
        private Shape runnerShape;
        private Shape frameShape;

        private Texture2D planetsTexture;
        private Texture2D runnerTexture;
        private Texture2D frameTexture;

        public LoadScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            firstPlanetShape = new ShapeSource(graphics, planetsTexture, new Rectangle(0, 50, 0, 0));
            firstPlanetShape.rectangle.Width = 50;
            firstPlanetShape.rectangle.Height = 50;
            firstPlanetShape.rectangle.Y -= firstPlanetShape.rectangle.Height;

            secondPlanetShape = new ShapeSource(graphics, planetsTexture, new Rectangle(0, 50, 0, 0));
            secondPlanetShape.rectangle.Width = 50;
            secondPlanetShape.rectangle.Height = 50;
            secondPlanetShape.rectangle.Y -= secondPlanetShape.rectangle.Height;
            secondPlanetShape.rectangle.X = graphics.resolution.width - 100;

            runnerShape = new Shape(graphics, runnerTexture, new Rectangle(0, 54, 0, 0));
            runnerShape.rectangle.Y -= runnerShape.rectangle.Height;

            frameShape = new Shape(graphics, frameTexture, new Rectangle(0, 0, 0, 0));
        }

        public void LoadContent()
        {
            planetsTexture = main.Content.Load<Texture2D>("planetsSheet");
            frameTexture = main.Content.Load<Texture2D>("textures/backgrounds/backgroundLoadScreen");
            runnerTexture = main.Content.Load<Texture2D>("shuttle");
        }

        public void Update(InputState input, GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch batch)
        {
            frameShape.Draw(batch);
            firstPlanetShape.Draw(batch);
            secondPlanetShape.Draw(batch);
            runnerShape.Draw(batch);
        }

        public void Start(int levelIndex)
        {
            SetLevel(levelIndex);
        }

        public void AddValue()
        {
            int x = secondPlanetShape.rectangle.X / 100;

            if (runnerShape.rectangle.X <= secondPlanetShape.rectangle.X)
            {
                runnerShape.rectangle.X += x;
            }
        }

        public void SetLevel(int levelIndex)
        {
            int x = 0;
            int y = 0;

            //levelIndex = x * y;

            //x = levelIndex / y;

            //y = levelIndex / x;

            if (levelIndex > 1)
                x = 50;

            y = levelIndex / x;

            switch (levelIndex)
            {
                case 1:
                    secondPlanetShape.sourceRectangle = new Rectangle(0, 0, 100, 100);
                    break;

                case 2:
                    firstPlanetShape.sourceRectangle = new Rectangle(0, 0, 100, 100);
                    secondPlanetShape.sourceRectangle = new Rectangle(100, 0, 100, 100);
                    break;

                case 3:
                    firstPlanetShape.sourceRectangle = new Rectangle(100, 0, 100, 100);
                    secondPlanetShape.sourceRectangle = new Rectangle(100, 200, 100, 100);
                    break;

                case 4:
                    firstPlanetShape.sourceRectangle = new Rectangle(100, 200, 100, 100);
                    secondPlanetShape.sourceRectangle = new Rectangle(100, 100, 100, 100);
                    break;

                case 5:
                    firstPlanetShape.sourceRectangle = new Rectangle(100, 100, 100, 100);
                    secondPlanetShape.sourceRectangle = new Rectangle(0, 200, 100, 100);
                    break;

                case 6:
                    firstPlanetShape.sourceRectangle = new Rectangle(0, 200, 100, 100);
                    secondPlanetShape.sourceRectangle = new Rectangle(0, 100, 100, 100);
                    break;

                default:
                    break;
            }
        }
    }
}
