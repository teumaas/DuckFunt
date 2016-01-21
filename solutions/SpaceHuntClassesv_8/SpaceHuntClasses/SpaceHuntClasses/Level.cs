using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    public class Level
    {
        public GameMode gameMode;
        private List<GameData> gameDatas;
        private Texture2D texture;
        private Texture2D backgroundTexture;
        public string Story { get; private set; }
        public bool IsLocked { get; private set; }
        public int index;

        public Level()
        {

        }

        public void AddGameData(GameData gameData)
        {
            gameDatas.Add(gameData);

            gameMode = Utility.GetHighestGameMode(gameMode, gameData.gameMode);
        }

        //public string GetHighestGameModeName()
        //{
        //    if()
        //}
        
    }
}
