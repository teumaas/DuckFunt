using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TableDrawer;

namespace MenuMaking
{

   
    class LeaderBoardMenu
    {
        char[] ABC = {' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        int inCharArrray = 1;
        int OnChar = 0;
       // public string result ="   ";
        char temp;
        public string result;
        private string message;
        private SpriteBatch SpriteBam;
        private SpriteFont font;
        private float blinktime = 10;    
        private Vector2 Location;
        private GameTime gTime;
        private bool final = false;
        private ButtonState oldButtonState, currentButtonState;
        private TableManager TableDrawer;
        private HighScoresSaveManager HS;
        SaveData tempUserData;
        private List<SaveData> data;
        private bool done = false;
   //     private LeaderBoardMenu LeaderBoard;
      
        public LeaderBoardMenu(SpriteBatch spriteBoard, GraphicsDeviceManager graphDeviceMan, ContentManager contentMaster, Vector2 DrawLocation)
        {
            gTime = new GameTime();
            this.SpriteBam = spriteBoard;
            Location = DrawLocation;
            font = contentMaster.Load<SpriteFont>("ScoreFont");
            oldButtonState = currentButtonState; 
            TableDrawer = new TableManager(graphDeviceMan, contentMaster,SpriteBam);
            HS = new HighScoresSaveManager("LeaderBoard_Savedata.1337");
          //  LeaderBoard = new LeaderBoardMenu(SpriteBam,graphDeviceMan,contentMaster);


               
        }


        void CharUp()
        {
            if (inCharArrray != ABC.Length -1)
            {
                inCharArrray += 1;
            }
            else
            {
                inCharArrray = 0;
            }
           
        }

        void CharDown()
        {
            if (inCharArrray != 0)
            {
                inCharArrray -= 1;
            }
            else
            {
                inCharArrray = ABC.Length - 1;
            }
        }

        void Next()
        {
            bool tempbool = false;
           // result = result + temp;
            if (OnChar == 2)
            {

                Finalize();
                
                
                    if (result.Length != 3)
                    {
                        result = result + temp;
                    }

                if (!tempbool)
                {
                    message = @"'" + result + @"'" + " Press > again to confirm";
                    tempbool = true;

                 }
               
            }
            else
            {
                OnChar += 1;
                
            }
            if (!final)
            {

                result = result + temp;  
            }
            inCharArrray = 1;
        }

        void Finalize()
        {
            final = true;

        }

        string GetLastResult()
        {
            return result;
        }

        private KeyboardState after;
        public void Draw()
        {
            
            KeyboardState keybState = Keyboard.GetState();
            if (after != keybState)
            {
                if (keybState.IsKeyDown(Keys.Up))
                {
                    CharUp();
                }
                if (keybState.IsKeyDown(Keys.Down))
                {
                    CharDown();
                }

                if (keybState.IsKeyDown(Keys.Right))
                {
                    Next();
                } 
            }
         
           
            temp = ABC[inCharArrray];
          //  message = temp.ToString() + "," + (OnChar +1) + "/3";
            if (!final)
            {
                message = result + temp;  
            }
            
            SpriteBam.Begin();
            //if (blinktime > 0)
            //{
            //    blinktime -= (float) gTime.ElapsedGameTime.TotalSeconds;
            //    SpriteBam.DrawString(font, "afldkj", Location, Color.Red);
            //}
            //else
            //{
                SpriteBam.DrawString(font, message, Location, Color.Red);
          //  }
            SpriteBam.DrawString(font, message, Location, Color.Red);
            SpriteBam.End();
            after = Keyboard.GetState();
        }

        bool Finalized()
        {
            return final;
        }

        public void PromptSave(SaveData userScore) //DONT CALL WITHIN DRAW it wil make the save file grow for each fps used.
        {
            
           //this object.Draw(); HAS TO BE PRECALLED WITHIN A DRAW METHOD FOR THIS ONE TOT WORK
      
            if (final)
            {
                data = HS.LoadHighScores("LeaderBoard_Savedata.1337");
                userScore.playerName = result;
                data.Add(userScore);
                int templength = data.Count;
                for (int i = 0; i < templength; i++)
                {
                    for (int j = 0; j < templength; j++)
                    {
                        if (data[i].kills >= data[j].kills)
                        {
                            tempUserData = data[j];
                            data[j] = data[i];
                            data[i] = tempUserData;
                        }
                    }
                }
                HS.Save(data);

               // TableDrawer.DrawTables(new Vector2(90, 20)); // Toggle the leaderboard
                }
        }
    }
}
