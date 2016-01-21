using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Screens
{
    public class Levels
    {
        public Level levelEarth;
        public Level levelMars;
        public Level levelVenus;
        public Level levelNeptune;
        public Level levelMercury;
        public Level levelEris;

        public Levels()
        {
            levelEarth = new Level();
            levelMars = new Level();
            levelVenus = new Level();
            levelNeptune = new Level();
            levelMercury = new Level();
            levelEris = new Level();
        }

        public void InitializeLevelsDatas(List<GameData> gameDatas)
        {
            foreach(var gD in gameDatas)
            {
                GetArray()[gD.levelIndex].AddGameData(gD);
            }
        }

        public Level[] GetArray()
        {
            return new Level[6] {levelEarth, levelMars, levelVenus, levelNeptune, levelMercury, levelEris};
        }
    }
}
