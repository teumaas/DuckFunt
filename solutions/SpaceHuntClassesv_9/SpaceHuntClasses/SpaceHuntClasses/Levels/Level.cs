using Microsoft.Xna.Framework.Graphics;
using SpaceHuntClasses.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Levels
{
    public class Level
    {
        public GameMode gameMode;
        private List<GameData> gameDatas;
        public int index;

        public string Story { get; private set; }
        public bool IsLocked { get; private set; }       
        public string Name { get; private set; }

        
        public Level(string story, int index, string name, bool isLocked)
        {
            this.Story = story;
            this.index = index;
            this.Name = name;
            this.IsLocked = isLocked;
        }

        public void UnLock()
        {
            IsLocked = false;
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
