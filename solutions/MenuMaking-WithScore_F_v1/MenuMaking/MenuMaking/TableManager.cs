using System.Security.Cryptography.X509Certificates;
using System.Threading;
using MenuMaking;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TableDrawer
{
    public class TableManager
    {
        private Game1 _game1;
        private GraphicsDeviceManager graphics;
        private Vector2 StartPos;
        private int TableWidth;
        private int offsetY;
        private int offsetX;
        public Texture2D borderTexture;
        private ContentManager lclContent;
        private SpriteBatch spriba;

        private SpriteFont font;
        public TableManager(GraphicsDeviceManager graph, ContentManager contentTable, SpriteBatch spriteBatch)
        {
            graphics = graph;
            lclContent = contentTable;
           spriba = spriteBatch;
            //
         //   graphics = new GraphicsDeviceManager(game1);
         //   TableWidth = tableWidth;
           // StartPos = startPos;
         //  _game1 = game1;
      //      borderTexture = graph. // game1.Content.Load<Texture2D>("ScoreBorder");
          //  lclContent = contentTable;
         //   borderTexture = _game1.Content.Load<Texture2D>("ScoreBorder"); //contentloadexception rest seems to be fine Game1 not passe
            borderTexture = lclContent.Load<Texture2D>("ScoreBorder");
            font = lclContent.Load<SpriteFont>("MenuFont");
        }

        public void DrawTables(Vector2 inStartLoc)
        {
           
            int timeswidth = 5;
            int timesheight = 6;
            int nameWidth = 3;
            int killWidth = 5;
            int roundWidth = 5;
            int timeWidth = 4;
            int firedWidth = 5;
            int stringlengthX = 0;
            int stringlengthY = 0;
            string testsign = "8";
            float correction = 0;
            string tempHighScoreItem="WTF";
            Vector2 adjustedV2 = inStartLoc;
            adjustedV2 = inStartLoc;
            int absMiddleint = graphics.GraphicsDevice.Viewport.Width / 2;
            spriba.Begin();
            for (int i = 0; i < timesheight; i++)
            {
                for (int j = 0; j < timeswidth; j++)
                {
                    switch (j)
                    {
                        case 0:
                            tempHighScoreItem = new string('S', nameWidth);
                            break;
                        case 1:
                            tempHighScoreItem = new string('S', killWidth);
                           
                            break;
                        case 2:
                            tempHighScoreItem = new string('S', roundWidth);
                            break;
                        case 3:
                            tempHighScoreItem = new string('S', timeWidth);
                            break; 

                        case 4:
                            tempHighScoreItem = new string('S', firedWidth);
                            break;
                        case 5:
                          
                            break;
                    }
                    
                    stringlengthX = (int)font.MeasureString(tempHighScoreItem).X;
                    stringlengthY = (int)font.MeasureString(tempHighScoreItem).Y;
                    
                    spriba.DrawString(font, tempHighScoreItem, adjustedV2, Color.Black);
                    spriba.Draw(borderTexture, new Rectangle((int)adjustedV2.X - 8, 0, 7, 9000 + 1), Color.White);
                    adjustedV2.X = adjustedV2.X + (stringlengthX + 10);
                }
                adjustedV2.Y = adjustedV2.Y + (stringlengthY + 2);
                spriba.Draw(borderTexture, new Rectangle((int)adjustedV2.X - 8, 0, 7, 9000 + 1), Color.White);
                if (correction == 0)
                {
                    //    correction = (StartPos.X - adjustedV2.X) / 2;
                }
             
                adjustedV2.X = inStartLoc.X;
            }
            spriba.End();

        }
    }
}