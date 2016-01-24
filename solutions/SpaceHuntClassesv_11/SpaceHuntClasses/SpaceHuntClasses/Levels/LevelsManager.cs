using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpaceHuntClasses.Levels
{
    public class LevelsManager
    {
        public Level levelEarth;
        public Level levelMars;
        public Level levelVenus;
        public Level levelNeptune;
        public Level levelMercury;
        public Level levelEris;

        private string earthStory;
        private string marsStory;
        private string venusStory;
        private string neptuneStory;
        private string mercuryStory;
        private string erisStory;

        public LevelsManager()
        {
            LoadStories(); 
            levelEarth = new Level(earthStory, 1, "Earth", false);
            levelMars = new Level(marsStory, 2, "Mars", false  );
            levelVenus = new Level(venusStory, 3, "Venus", true);
            levelNeptune = new Level(neptuneStory, 4, "Neptune", true);
            levelMercury = new Level(mercuryStory, 5, "Mercury", true);
            levelEris = new Level(erisStory, 6, "Eris", false);
        }

        public void LoadStories()
        {
            earthStory = File.ReadAllText("strings/level_1_story.txt");
            marsStory = File.ReadAllText("strings/level_2_story.txt");
            venusStory = File.ReadAllText("strings/level_3_story.txt");
            neptuneStory = File.ReadAllText("strings/level_4_story.txt");
            mercuryStory = File.ReadAllText("strings/level_5_story.txt");
            erisStory = File.ReadAllText("strings/level_6_story.txt");
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
