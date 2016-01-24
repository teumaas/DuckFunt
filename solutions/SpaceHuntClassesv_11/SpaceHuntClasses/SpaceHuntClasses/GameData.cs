using SpaceHuntClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses
{
    public class GameData
    {
        public int levelIndex;
        public GameMode gameMode;
        public int kills;
        public int rounds;
        public int shotFired;
        public string playerName;

        //public GameData(int levelIndex, int kills, int rounds, int shotFired, string playerName)
        //{
        //}
       

        public GameData()
        {

        }
    }
}
