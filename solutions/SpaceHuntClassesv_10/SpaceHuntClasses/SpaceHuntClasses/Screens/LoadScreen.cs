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
        private Shape firstPlanetShape;
        private Shape secondPlanetShape;
        private Shape runnerShape;
        private int unit;
        public event EventHandler Finish;

        private Texture2D runnerTexture;

        private Texture2D earthTexture;
        private Texture2D marsTexture;
        private Texture2D venusTexture;
        private Texture2D neptuneTexture;
        private Texture2D mercuryTexture;
        private Texture2D erisTexture;

        public LoadScreen(Main main, GraphicsInfos graphics)
        {
            this.main = main;
            LoadContent();
            Initialize(graphics);
        }

        public void Initialize(GraphicsInfos graphics)
        {
            unit = graphics.resolution.width / 100;
            runnerShape = new Shape(graphics, runnerTexture, new Rectangle(0, 50, 0, 0));
            runnerShape.rectangle.Y -= runnerShape.rectangle.Height / 2;

            firstPlanetShape = new Shape(graphics, earthTexture, new Rectangle(0, 50, 0, 0));
            firstPlanetShape.rectangle.Y -= firstPlanetShape.rectangle.Width / 2;

            secondPlanetShape = new Shape(graphics, earthTexture, new Rectangle(100, 50, 0, 0));
            secondPlanetShape.rectangle.X -= secondPlanetShape.rectangle.Width / 2;
            secondPlanetShape.rectangle.Y -= secondPlanetShape.rectangle.Height / 2;
        }

        public void LoadContent()
        {
            runnerTexture = main.Content.Load<Texture2D>("shuttle");

            earthTexture = main.Content.Load<Texture2D>("textures/buttons/earthButton");
            marsTexture = main.Content.Load<Texture2D>("textures/buttons/marsbutton");
            venusTexture = main.Content.Load<Texture2D>("textures/buttons/venusButton");
            neptuneTexture = main.Content.Load<Texture2D>("textures/buttons/neptuneButton");
            mercuryTexture = main.Content.Load<Texture2D>("textures/buttons/mercuryButton");
            erisTexture = main.Content.Load<Texture2D>("textures/buttons/erisButton");
        }

        public void InitializePlanets(int levelIndex)//always call the Initialize method first
        {
            var r1 = firstPlanetShape.rectangle;
            var r2 = secondPlanetShape.rectangle;

            var fakeGraphicsInfos = new GraphicsInfos(new Resolution(1, 1), false);

            if(levelIndex == 1)//TODO : simplify this condition after checking if each planet texture're working
            {
                firstPlanetShape = new Shape(fakeGraphicsInfos, GetPlanetsTextures()[0],new Rectangle(0,0,0,0)); //need to be recoded
                firstPlanetShape.rectangle = r1;

                secondPlanetShape = new Shape(fakeGraphicsInfos, GetPlanetsTextures()[levelIndex - 1], new Rectangle(0, 0, 0, 0));
                secondPlanetShape.rectangle = r2;
            }
            else
            {
                firstPlanetShape = new Shape(fakeGraphicsInfos, GetPlanetsTextures()[levelIndex - 2], new Rectangle(0, 0, 0, 0)); //need to be recoded
                firstPlanetShape.rectangle = r1;

                secondPlanetShape = new Shape(fakeGraphicsInfos, GetPlanetsTextures()[levelIndex - 1], new Rectangle(0, 0, 0, 0));
                secondPlanetShape.rectangle = r2;
            }
        }

        public void Update(InputState input, GameTime gameTime)
        {
            if (runnerShape.rectangle.X < secondPlanetShape.rectangle.X)
                runnerShape.rectangle.X += unit;
            else
                Finish(this, null);
        }

        public void Draw(SpriteBatch batch)
        {
            firstPlanetShape.Draw(batch);
            secondPlanetShape.Draw(batch);
            runnerShape.Draw(batch);
        }

        public void Start(int levelIndex)
        {
            InitializePlanets(levelIndex);
        }

        private Texture2D[] GetPlanetsTextures()
        {
            return new Texture2D[6] { earthTexture, marsTexture, venusTexture, neptuneTexture, mercuryTexture, erisTexture };
        }
    }
}
