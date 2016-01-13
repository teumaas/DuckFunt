using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    class Utility
    {
        private static GraphicsDevice graphicsDevice;
        private static Texture2D blackTexture;

        public static void Init(GraphicsDevice graphicsDevicE)
        {
            graphicsDevice = graphicsDevicE;
            blackTexture = new Texture2D(graphicsDevice, 1, 1);
        }

        public static void DrawRectangleShadow(SpriteBatch batch, Rectangle rectangle, int margin, float transparency)
        {
            rectangle.X -= margin;
            rectangle.Y -= margin;
            rectangle.Width += 2 * margin;
            rectangle.Height += 2 * margin;

            //for(int x = 0; x < rectangle.Width; x++)
            //{
            //    for(int y = 0; y < rectangle.Height; y++)
            //    {
                    
            //    }
            //}

            blackTexture.SetData<Color>(new Color[] { Color.Black * transparency});

            batch.Draw(blackTexture, rectangle, Color.White);
        }

        public static Rectangle ResizeRectangle(Rectangle rectangle, Rectangle divisorRectangle)
        {
            return new Rectangle(rectangle.X / divisorRectangle.X,
                rectangle.Y / divisorRectangle.Y,
                rectangle.Width / divisorRectangle.Width,
                rectangle.Height / divisorRectangle.Height);
        }

        public static bool CheckBorders(Rectangle rectangle, int x, int y)
        {
            return x > rectangle.X && x < rectangle.X + rectangle.Width && y > rectangle.Y && y < y - rectangle.Width;
        }

        public static Texture2D GetBlackTexture()
        {
            return blackTexture;
        }

        public static Rectangle GetRectangleFromPercentage(Rectangle percentage, Resolution resolution)
        {
            int width = resolution.width * 100;
            int height = 1080 / resolution.height;

            return new Rectangle(percentage.X * height, percentage.Y * height, percentage.Width * height, percentage.Height * height);
        }
    }
}
