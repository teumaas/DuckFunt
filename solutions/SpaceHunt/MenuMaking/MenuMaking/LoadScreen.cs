using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceHunt
{
    class LoadScreen
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch sprite;

        private Texture2D firstPlanetTX;
        private Texture2D secondPlanetTX;
        private Texture2D runnerTX;
        private Texture2D frameTX;

        private Vector2 firstPlanetPos;
        private Vector2 SecondPlanePos;
        private Vector2 runnerPos;
        private Vector2 framePos;

        private int runnerValue;

        public LoadScreen(GraphicsDeviceManager graphics, SpriteBatch sprite, Texture2D firstPlanetTX, Texture2D secondPlanetTX, Texture2D runnerTX, Texture2D frameTX)
        {
            this.graphics = graphics;
            this.sprite = sprite;

            this.firstPlanetTX = firstPlanetTX;
            this.secondPlanetTX = secondPlanetTX;
            this.runnerTX = runnerTX;
            this.frameTX = frameTX;
        }
        public void Initialize()
        {
            runnerValue = 20;

            firstPlanetPos = new Vector2(10, 10);
            SecondPlanePos = new Vector2(10, 10);

            runnerPos = new Vector2(10, 10);
            framePos = new Vector2(800, 500);
        }

        public void Draw()
        {
            sprite.Draw(frameTX, new Rectangle(0, 200, 1280, 100), Color.White);
            sprite.Draw(firstPlanetTX, new Rectangle(10, 215, 70, 70), Color.White);
            sprite.Draw(secondPlanetTX, new Rectangle(930, 215, 70, 70), Color.White);
            sprite.Draw(runnerTX, new Rectangle(runnerValue, 225, 50, 50), Color.White);
        }

        public void AddValue()
        {
            if (runnerValue < 940)
            {
                runnerValue += 10;
            }
        }
    }
}
