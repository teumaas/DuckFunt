using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SplashScreen
{
    public class SplashScreen
    {
        private Game1 _game1;
        public Texture2D logo;
        public Vector2 screenSize;
        private bool cycling = true;
        private int offset = 1;
        private SpriteBatch sb;
        private GraphicsDeviceManager graph;
        private Texture2D screen;
        private ContentManager content;
       // Vector2 screenSize;
        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        private int offseteffect = 1;

        private int finaleffect;

        public SplashScreen(Game1 game1, SpriteBatch sb, Vector2 screenSize , ContentManager content, GraphicsDeviceManager grafisch)
        {
            _game1 = game1;
            this.sb = sb;
            this.content = content;
            this.graph = grafisch;
            this.screenSize = screenSize;
            logo = this.content.Load<Texture2D>("Splash_SpaceHunt");
            
            //graph = graphics;
            //   screenSize = new Vector2(graph.GraphicsDevice.Viewport.Width, graph.GraphicsDevice.Viewport.Height);
        }

        public bool done { get; set; }

        public void Draw()
        {
            var width = 2048;
            var height = 274;
            graph.GraphicsDevice.Clear(Color.Black);
         //   graph.GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            sb.Begin();
            if (offset > 2048 || offset == 0)
            {
                cycling = false;
                offset = 0;
            }
            if (offset != 0)
            {
                offset += 8;
            }

            if (cycling)
            {
                sb.Draw(logo, new Rectangle(0 - offset, 0, width, height), Color.White);
            }
            else if (!done && !cycling)
            {
                if (offseteffect != 0)
                {
                    sb.Draw(logo,
                        new Rectangle(0 - offset, 0, graph.GraphicsDevice.Viewport.Width - offseteffect, graph.GraphicsDevice.Viewport.Height - offseteffect), Color.White);
                    offseteffect += 4;
                    finaleffect = offseteffect;
                }
                if (offseteffect > graph.GraphicsDevice.Viewport.Height/3)
                {
                    offseteffect = 0;
                }
                if (offseteffect == 0)
                {
                    offset += 4;
                    sb.Draw(logo,
                        new Rectangle(0 + offset, 0, graph.GraphicsDevice.Viewport.Width - finaleffect, graph.GraphicsDevice.Viewport.Height - finaleffect), Color.White);
                    if (offset > 2000)
                    {
                        done = true;
                    }
                }
            }
           sb.End();

         //   _game1.Draw(gameTime);
        }
    }
}