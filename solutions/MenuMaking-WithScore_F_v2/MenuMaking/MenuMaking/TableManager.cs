using System;
using System.Collections.Generic;
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
        private struct HighScoreData
        {
            public string playerName;
            public decimal kills;
            public decimal shotsFired;
            public decimal rounds;
            public TimeSpan time;
        }
        private Game1 _game1;
        private GraphicsDeviceManager graphics;
        private Vector2 StartPos;
        private int TableWidth;
        private int offsetY;
        private int offsetX;
        public Texture2D borderTexture;
        private ContentManager lclContent;
        private SpriteBatch spriba;
        private Texture2D backButton; 
        private SpriteFont scoreFont;
        private HighScoreData hsd;
        private List<HighScoreData> hsList;
        public TableManager(GraphicsDeviceManager graph, ContentManager contentTable, SpriteBatch spriteBatch)
        {
            graphics = graph;
            lclContent = contentTable;
           spriba = spriteBatch;
            hsd = new HighScoreData();
            //List<HighScoreData> 
            hsList = new List<HighScoreData>();
            
         //   graphics = new GraphicsDeviceManager(game1);
         //   TableWidth = tableWidth;
           // StartPos = startPos;
         //  _game1 = game1;
      //      borderTexture = graph. // game1.Content.Load<Texture2D>("ScoreBorder");
          //  lclContent = contentTable;
         //   borderTexture = _game1.Content.Load<Texture2D>("ScoreBorder"); //contentloadexception rest seems to be fine Game1 not passe
            borderTexture = lclContent.Load<Texture2D>("ScoreBorder");
            backButton = lclContent.Load<Texture2D>("BackArrow");
            scoreFont = lclContent.Load<SpriteFont>("ScoreFont");
        }

        
        public void DrawTables(Vector2 inStartLoc)
        {
            int backButtonSize = 0;
            int timeswidth = 5;
            int timesheight = 15;
            int nameWidth = 3;
            int killWidth = 5;
            int roundWidth = 5;
            int timeWidth = 4;
            int firedWidth = 5;
            int stringlengthX = 0;
            int stringlengthY = 0;
            string testsign = "8";
            int ScoreboardWidest =0;
            float correction = 0;
            Rectangle backBtnSize;
            string tempHighScoreItem="WTF";
            Vector2 adjustedV2 = inStartLoc;
            adjustedV2 = inStartLoc;
            int screenwidth = graphics.GraphicsDevice.Viewport.Width;
          //EDITS#
          // SaveData tempSave = new SaveData();
            hsd.kills = 10;
            hsd.playerName = "KIL";
            hsd.shotsFired = 1233;
            hsd.time = new TimeSpan(0, 1, 2);
         //   hsd.rounds
            hsd.rounds = 13;
            for (int i = 0; i < 15; i++)
            {
                hsd.kills = i;
                hsList.Add(hsd); 
            }
           
            HighScores ScoreLoad = new HighScores("LeaderBoard_Savedata");
           // HighScores.Save(tempSave);
            
            
            spriba.Begin();
            

            //for(int i = 0 i < SavedataItem.Length; i++)
         //   for (int i = 0; i < timesheight; i++)
            for (int i = 0; i < hsList.Count; i++)
            {
                
            
                int tempHSNumber = i + 1;
                Vector2 tempHSLocation = new Vector2(adjustedV2.X - (scoreFont.MeasureString("88").X + 10), adjustedV2.Y); // Zet nummers neer voor de highscore aka nummer 1
                spriba.DrawString(scoreFont, tempHSNumber.ToString(), tempHSLocation, Color.Black);
                
                for (int j = 0; j < timeswidth; j++)
                {
                    
                    switch (j)
                    {
                            //tempHighScoreItem = SavadataItem[i, j];
                        case 0:
                            tempHighScoreItem = hsList[i].playerName.ToUpper();
                           // tempHighScoreItem = new string('S', nameWidth);
                            break;
                        case 1:
                         tempHighScoreItem = string.Format(hsList[i].kills.ToString("00000"));
                         //   tempHighScoreItem = new string('S', killWidth);
                            break;
                        case 2:
                            tempHighScoreItem = string.Format(hsList[i].rounds.ToString("00") + "/15"); //hsList[i].ToString("00") + "/15");
                         
                         //  tempHighScoreItem = hsList[i]
//                            tempHighScoreItem = new string('S', roundWidth);
                            break;
                        case 3:
                          //  tempHighScoreItem = new string(hsd.time.Minutes);
                            tempHighScoreItem = string.Format("{0:mm\\,ss}", hsList[i].time);
                            //tempHighScoreItem = new string('S', timeWidth);
                            break; 
                        case 4:
                            tempHighScoreItem = hsList[i].shotsFired.ToString("00000");   
                        // tempHighScoreItem = new string('S', firedWidth);
                            break;
                        case 5:
                          
                            break;
                    }
                    
                    stringlengthX = (int)scoreFont.MeasureString(tempHighScoreItem).X;
                    stringlengthY = (int)scoreFont.MeasureString(tempHighScoreItem).Y;
                    
                    spriba.DrawString(scoreFont, tempHighScoreItem, adjustedV2, Color.Black);
                    spriba.Draw(borderTexture, new Rectangle((int)adjustedV2.X - 8, 0, 7, 9000 + 1), Color.White);
                    adjustedV2.X = adjustedV2.X + (stringlengthX + 10);
                }
                adjustedV2.Y = adjustedV2.Y + (stringlengthY + 2);
                spriba.Draw(borderTexture, new Rectangle((int)adjustedV2.X - 8, 0, 7, 9000 + 1), Color.White);
                if (ScoreboardWidest < adjustedV2.X + stringlengthX)
                {
                    ScoreboardWidest = (int) adjustedV2.X;
                }
                adjustedV2.X = inStartLoc.X;
                
            }
            backBtnSize.Y = backButtonSize;
            backBtnSize.X = backButtonSize;
            Menu MenuForBG = new Menu(lclContent, graphics, spriba);
            if (screenwidth - ScoreboardWidest > 200)
            {
                backBtnSize.Y = 150;
                backBtnSize.X = 150;
            }
            else
            {
                backBtnSize.Y = (screenwidth - ScoreboardWidest) - 10;
                backBtnSize.X = (screenwidth - ScoreboardWidest) - 10;
            }
            spriba.Draw(backButton, new Rectangle(ScoreboardWidest + 8, 8, backBtnSize.X, backBtnSize.Y), Color.White);
            MenuForBG.BuildBG(MenuForBG.colorBG, ScoreboardWidest +4, 4, backBtnSize.X + 4, backBtnSize.Y + 8);
            spriba.End();

        }
    }
}