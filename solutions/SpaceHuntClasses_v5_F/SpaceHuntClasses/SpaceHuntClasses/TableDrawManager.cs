using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using MenuMaking;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Saveme = MenuMaking.SaveData;

namespace TableDrawer
{
    public class TableManager
    {

      //  private Game1 _game1;
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
        private Saveme hsd;
        private List<Saveme> hsList;
        private LeaderBoardMenu AskInput;

        public TableManager(GraphicsDeviceManager graph, ContentManager contentTable, SpriteBatch spriteBatch)
        {

            graphics = graph;
            lclContent = contentTable;
            spriba = spriteBatch;
            hsd = new Saveme();
            hsList = new List<Saveme>();
            borderTexture = lclContent.Load<Texture2D>("ScoreBorder");
            backButton = lclContent.Load<Texture2D>("BackArrow");
            scoreFont = lclContent.Load<SpriteFont>("ScoreFont");
        }
      //  private LeaderBoardMenu AskInput;
        public string AfterGameEnds(Vector2 Location)
        {
            AskInput = new LeaderBoardMenu(spriba,graphics,lclContent,Location);
            AskInput.Draw();
            DrawTables(new Vector2(45,45));
            return AskInput.result;

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
            int ScoreboardWidest = 0;
            float correction = 0;
            Rectangle backBtnSize;
            string tempHighScoreItem = "WTF";
            Vector2 adjustedV2 = inStartLoc;
           // adjustedV2 = inStartLoc;
            int screenwidth = graphics.GraphicsDevice.Viewport.Width;

           //#####Uitgecommente code is voorbeeld hoe je leaderboard opslaat
            //hsd.kills = 10;
            //hsd.playerName = "LOL";
            //hsd.shotsFired = 1233;
            //hsd.time = new TimeSpan(0, 1, 2);
            //hsd.rounds = 13;

            //for (int i = 0; i < 15; i++)
            //{
            //    hsd.kills = i;
            //    hsList.Add(hsd);
            //}


            HighScoresSaveManager ScoreDevice = new HighScoresSaveManager("LeaderBoard_Savedata.1337");
          //  ScoreDevice.Save(hsList);
            hsList.Clear();
            hsList = ScoreDevice.LoadHighScores("LeaderBoard_Savedata.1337");
            spriba.Begin();

            spriba.DrawString(scoreFont, "Who", adjustedV2, Color.White);
            stringlengthX = (int)scoreFont.MeasureString("Who").X;
            adjustedV2.X = adjustedV2.X + stringlengthX + 10;
            spriba.DrawString(scoreFont, "Kills", adjustedV2, Color.White);
            stringlengthX = (int)scoreFont.MeasureString("Kills").X;
            adjustedV2.X = adjustedV2.X + stringlengthX + 10;
            spriba.DrawString(scoreFont, "Round", adjustedV2, Color.White);
            stringlengthX = (int)scoreFont.MeasureString("Round").X;
            adjustedV2.X = adjustedV2.X + stringlengthX + 10;
            spriba.DrawString(scoreFont, "Timer", adjustedV2, Color.White);
            stringlengthX = (int)scoreFont.MeasureString("Timer").X;
            adjustedV2.X = adjustedV2.X + stringlengthX + 10;
            spriba.DrawString(scoreFont, "Shots", adjustedV2, Color.White);
            stringlengthX = (int)scoreFont.MeasureString("Shots").X;
            stringlengthY = (int)scoreFont.MeasureString("Shots").Y;
            adjustedV2.X = adjustedV2.X + stringlengthX + 10;

          //  adjustedV2.Y = +stringlengthY;
            adjustedV2.Y = adjustedV2.Y+30;
            adjustedV2.X = inStartLoc.X;
            for (int i = 0; i < hsList.Count; i++)
            {
                int tempHSNumber = i + 1;
                Vector2 tempHSLocation = new Vector2(adjustedV2.X - (scoreFont.MeasureString("88").X + 10), adjustedV2.Y); // Zet nummers neer voor de highscore aka nummer 1
                spriba.DrawString(scoreFont, tempHSNumber.ToString(), tempHSLocation, Color.Black);

                for (int j = 0; j < timeswidth; j++)
                {

                    switch (j)
                    {
                        case 0:
                            tempHighScoreItem = hsList[i].playerName.ToUpper();
                            break;
                        case 1:
                            tempHighScoreItem = string.Format(hsList[i].kills.ToString("00000"));
                            break;
                        case 2:
                            tempHighScoreItem = string.Format(hsList[i].rounds.ToString("00") + "/15");

                            break;
                        case 3:
                            tempHighScoreItem = string.Format("{0:mm\\,ss}", hsList[i].time);
                            break;
                        case 4:
                            tempHighScoreItem = hsList[i].shotsFired.ToString("00000");
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
                    ScoreboardWidest = (int)adjustedV2.X;
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
            MenuForBG.BuildBG(MenuForBG.colorBG, ScoreboardWidest + 4, 4, backBtnSize.X + 4, backBtnSize.Y + 8);
            spriba.End();

        }
    }
}